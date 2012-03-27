unit uSRReport;

interface

uses
    SysUtils, Classes,
    SlimRayPrintOCX_TLB,

    frxClass, frxDBSet, frxvariables,

    frxBarcode, frxChart,

    frxExportCSV, frxExportImage, frxExportRTF, frxExportXLS,
    frxExportHTML, frxExportPDF,

    frxDesgn,
    DB, ADODB;

type
    //each group is a dataset in report..
    TOnReportErrMsgEventHandler = procedure(msg: string) of object;

    TReportVariantListItem = record
        Name: string;
        Value: variant;
        DataType: TReportExportType;
        //need to destroy
        varObject: TfrxVariable;
    end;

    TSQLGroupListItem = record
        SQLGroup: TSQLGroup;

        //need to destroy
        Query: TADOQuery;

        //need to destroy
        FrxDataSet: TfrxDBDataset;
    end;

    TSRReport = class
    private
        _Owner: TComponent;

        _OnErrMsg: TOnReportErrMsgEventHandler;

        _ConnectionString: string;
        _Conn: TADOConnection;
        _SQLGroupList: array of TSQLGroupListItem;

        _ReportFileName: string;
        _ReportVariantList: array of TReportVariantListItem;

        _FrxReport: TfrxReport;

        procedure _SetConnectionString(val: string);

        procedure _CallErrMsgHandler(errMsg: string);

        {
        加载报表步骤一：
        加载报表格式文件
        }
        function _LoadFromFileAndClear(fileName: string): boolean;

        function _PrepareConnection(): boolean;

        {
        加载报表步骤二：
        1、将_SQLGroupList 里面的ADOQuery的数据全部加载
        }
        function _FillDataGroupList(): boolean;

        {
        加载报表步骤三：
        将_ReportVariantList里面的变量加载到报表
        }
        function _FillVariantsToReport(): boolean;

        {
           调用前面步骤完成报表的准备
        }
        function _PrepareReport(): boolean;

        procedure _DestoryList();
    protected

    published
        //for control
        property Owner: TComponent read _Owner write _Owner;

        //for event
        property OnErrMsg: TOnReportErrMsgEventHandler read _OnErrMsg write _OnErrMsg;

        //for db..
        property ConnectionString: string read _ConnectionString write _SetConnectionString;

        //property for a report
        property ReportFileName: string read _ReportFileName write _ReportFileName;

        { proc for db..
        sql add in proc
        every sql-group is a dataset in report designer.
        }
        procedure AddSQL(sg: TSQLGroup);
        procedure RemoveSQL(userDataSetName: string);
        procedure ClearSQL();

        //procedure for a report
        procedure Preview();
        procedure Design();
        procedure Print();

        procedure ExportReport(fileName: string; exportType: TReportExportType);

        //for report variant
        procedure AddVariant(name: string; val: variant; vType: TReportVariantType);
        procedure RemoveVariant(name: string);
        procedure ClearVariant();

    public
        constructor Create(AOwner: TComponent);
        destructor Destroy();
    end;

implementation

constructor TSRReport.Create(AOwner: TComponent);
begin
    inherited Create();

    _Owner := aOwner;

    _ConnectionString := '';
    _ReportFileName := '';

    //init db..
    _Conn := TADOConnection.Create(nil);
    _Conn.LoginPrompt := false;

    setLength(_SQLGroupList, 0);

    setLength(_ReportVariantList, 0);

    _FrxReport := TfrxReport.Create(nil);

    _FrxReport.PreviewOptions.Buttons := [pbPrint, pbExport, pbZoom, pbNavigator, pbExportQuick];
end;

destructor TSRReport.Destroy();
begin
    _DestoryList();

    setLength(_SQLGroupList, 0);
    setLength(_ReportVariantList, 0);

    _Conn.Destroy;

    _FrxReport.Destroy;

    inherited;
end;

procedure TSRReport._DestoryList();
var
    i: integer;
begin
    for i := 0 to length(_SQLGroupList) - 1 do
    begin
        if Assigned(_SQLGroupList[i].Query) then
        begin
            _SQLGroupList[i].Query.Destroy;
        end;

        if Assigned(_SQLGroupList[i].FrxDataSet) then
        begin
            _SQLGroupList[i].FrxDataSet.Destroy;
        end;
    end;
    {
    Error: not null but  Destroy fail.. comfusing..

    for i := 0 to length(_ReportVariantList) - 1 do
    begin
        if Assigned(_ReportVariantList[i].varObject) then
        begin
            _ReportVariantList[i].varObject.Destroy;
        end;
    end;
    }
end;

procedure TSRReport._SetConnectionString(val: string);
begin
    _ConnectionString := trim(val);
end;

procedure TSRReport._CallErrMsgHandler(errMsg: string);
begin
    if Assigned(_OnErrMsg) then
    begin
        _OnErrMsg(errMsg);
    end;
end;

function TSRReport._LoadFromFileAndClear(fileName: string): boolean;
begin
    result := false;

    if not FileExists(fileName) then
    begin
        _CallErrMsgHandler('报表格式文件不存在。' + char(13) + fileName);
        exit;
    end;

    _FrxReport.Clear;
    _FrxReport.LoadFromFile(fileName);

    result := true;
end;

function TSRReport._PrepareConnection(): boolean;
begin
    result := false;

    try
        if _Conn.State <> [stClosed] then
        begin
            _Conn.Close();
        end;

        _Conn.ConnectionString := _ConnectionString;

        _Conn.Open();

    except on e: exception do
        begin
            _CallErrMsgHandler('连接数据库发生错误：' + char(13) + e.Message);
            exit;
        end;
    end;

    result := true;
end;

function TSRReport._FillDataGroupList(): boolean;
var
    i: integer;
    aq: TADOQuery;
    FrxDS: TfrxDBDataset;
begin
    result := false;

    if length(_SQLGroupList) = 0 then
    begin
        result := true;
        exit;
    end;

    _FrxReport.DataSets.Clear;

    if not _PrepareConnection then
    begin
        exit;
    end;

    //create aq and exec sql
    for i := 0 to length(_SQLGroupList) - 1 do
    begin
        aq := TADOQuery.Create(nil);

        aq.Connection := _Conn;

        aq.SQL.Add(_SQLGroupList[i].SQLGroup.SQLText);

        try
            aq.Open;

        except on e: exception do
            begin
                _CallErrMsgHandler(
                    '加载数据发生错误：' + char(13) +
                    'UserDataSet:' + _SQLGroupList[i].SQLGroup.UserDataSetName + char(13) +
                    'SQL:' + _SQLGroupList[i].SQLGroup.SQLText + char(13) +
                    'Err:' + e.Message
                    );

                exit;
            end;
        end;

        FrxDS := TfrxDBDataset.Create(nil);
        frxds.DataSet := aq;
        frxds.UserName := _SQLGroupList[i].SQLGroup.UserDataSetName;

        _FrxReport.DataSets.Add(frxds);

        _SQLGroupList[i].Query := aq;
        _SQLGroupList[i].FrxDataSet := frxds;
    end;

    result := true;
end;

function TSRReport._FillVariantsToReport(): boolean;
var
    i: integer;
    va: TfrxVariable;
begin
    result := false;

    _FrxReport.Variables.Clear();

    for i := 0 to length(_ReportVariantList) - 1 do
    begin
        va := _FrxReport.Variables.Add;

        va.Name := _ReportVariantList[i].Name;

        if _ReportVariantList[i].DataType = vtString then
        begin
            va.Value := '''' + _ReportVariantList[i].Value + '''';
        end
        else if _ReportVariantList[i].DataType = vtDateTime then
        begin
            //va.Value := '''' + FormatDateTime('yyyy-mm-dd hh:mm:ss', _ReportVariantList[i].Value) + '''';
            va.Value := _ReportVariantList[i].Value;
        end
        else
        begin
            va.Value := _ReportVariantList[i].Value;
        end;

        _ReportVariantList[i].varObject := va;
    end;

    result := true;
end;

function TSRReport._PrepareReport(): boolean;
begin
    result := false;

    if not _LoadFromFileAndClear(_ReportFileName) then
    begin
        exit;
    end;

    if not _FillDataGroupList() then
    begin
        exit;
    end;

    if not _FillVariantsToReport() then
    begin
        exit;
    end;

    _FrxReport.PrepareReport(true);
    result := true;
end;

procedure TSRReport.AddSQL(sg: TSQLGroup);
var
    td: integer;
    item: TSQLGroupListItem;
begin
    if (trim(sg.UserDataSetName) = '') or (trim(sg.SQLText) = '') then
    begin
        exit;
    end;

    td := Length(_SQLGroupList);

    setLength(_SQLGroupList, td + 1);

    item.SQLGroup.UserDataSetName := trim(sg.UserDataSetName);
    item.SQLGroup.SQLText := trim(sg.SQLText);

    _SQLGroupList[td] := item;
end;

procedure TSRReport.RemoveSQL(userDataSetName: string);
var
    i, td: integer;
    ts: string;
begin
    ts := uppercase(trim(userDataSetName));

    if ts = '' then
    begin
        exit;
    end;

    td := Length(_SQLGroupList) - 1;

    if td < 0 then
    begin
        exit;
    end;

    for i := 0 to td do
    begin
        if ts <> UpperCase(_SQLGroupList[i].SQLGroup.UserDataSetName) then
        begin
            continue;
        end;

        //if not last ,copy last to current,
        if i < td then
        begin
            _SQLGroupList[i].SQLGroup.UserDataSetName := _SQLGroupList[td].SQLGroup.UserDataSetName;
            _SQLGroupList[i].SQLGroup.SQLText := _SQLGroupList[td].SQLGroup.SQLText;
        end;

        //remove last
        setLength(_SQLGroupList, td);

        exit;
    end;
end;

procedure TSRReport.ClearSQL();
begin
    setLength(_SQLGroupList, 0);
end;

procedure TSRReport.Preview();
begin
    if not _PrepareReport() then
    begin
        exit;
    end;

    try
        _FrxReport.ShowReport(true);
    except on e: exception do
        begin
            _CallErrMsgHandler('Error on Preivew:' + char(13) + e.Message);
            exit;
        end;
    end;
end;

procedure TSRReport.Design();
begin
    if not _PrepareReport() then
    begin
        exit;
    end;

    try
        _FrxReport.DesignReport(true);
    except on e: exception do
        begin
            _CallErrMsgHandler('Error on Preivew:' + char(13) + e.Message);
            exit;
        end;
    end;
end;

procedure TSRReport.Print();
begin
    if not _PrepareReport() then
    begin
        exit;
    end;

    try
        _FrxReport.Print();
    except on e: exception do
        begin
            _CallErrMsgHandler('Error on Preivew:' + char(13) + e.Message);
            exit;
        end;
    end;
end;

procedure TSRReport.ExportReport(fileName: string; exportType: TReportExportType);
{
var
    e: TfrxCustomExportFilter;
}
begin

    _CallErrMsgHandler('null ExportReport(,,)');

    if exportType = etExcel then
    begin
        //_FrxReport.Export()
    end
    else if exportType = etCSV then
    begin

    end
    else if exportType = etWord then
    begin

    end
    else if exportType = etPDF then
    begin

    end
    else if exportType = etHTML then
    begin

    end
    else if exportType = etBMP then
    begin

    end
    else if exportType = etJPG then
    begin

    end
    else
    begin

    end;
end;

procedure TSRReport.AddVariant(name: string; val: variant; vType: TReportVariantType);
var
    td: integer;
    item: TReportVariantListItem;
begin
    if trim(name) = '' then
    begin
        exit;
    end;

    td := Length(_ReportVariantList);

    setLength(_ReportVariantList, td + 1);

    item.Name := trim(name);
    item.Value := val;
    item.DataType := vType;

    _ReportVariantList[td] := item;
end;

procedure TSRReport.RemoveVariant(name: string);
var
    i, td: integer;
    ts: string;
begin
    ts := uppercase(trim(name));

    if ts = '' then
    begin
        exit;
    end;

    td := Length(_ReportVariantList) - 1;

    if td < 0 then
    begin
        exit;
    end;

    for i := 0 to td do
    begin
        if ts <> UpperCase(_ReportVariantList[i].Name) then
        begin
            continue;
        end;

        //if not last ,copy last to current,
        if i < td then
        begin
            _ReportVariantList[i].Name := _ReportVariantList[td].Name;
            _ReportVariantList[i].Value := _ReportVariantList[td].Value;
            _ReportVariantList[i].DataType := _ReportVariantList[td].DataType;
        end;

        //remove last
        setLength(_ReportVariantList, td);

        exit;
    end;
end;

procedure TSRReport.ClearVariant();
begin
    setLength(_ReportVariantList, 0);
end;

end.

