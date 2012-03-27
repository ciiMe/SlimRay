unit SlimRayPrintImpl;

{$WARN SYMBOL_PLATFORM OFF}

interface

uses
    Windows, ActiveX, Classes, Controls, Graphics, Menus, Forms, StdCtrls,
    ComServ, StdVCL, AXCtrls, SlimRayPrintOCX_TLB, ExtCtrls, dialogs,
    uTestForm,
    SysUtils,
    uSRReport
    ;

type
    TSlimRayPrint = class(TActiveXControl, ISlimRayPrint)
    private
        { Private declarations }

        _Report: TSRReport;

        FEvents: ISlimRayPrintEvents;
    protected
        { Protected declarations }
        procedure DefinePropertyPages(DefinePropertyPage: TDefinePropertyPage); override;
        procedure EventSinkChanged(const EventSink: IUnknown); override;
        procedure InitializeControl; override;

        function Get_ReportFileName: WideString; safecall;
        procedure Set_ReportFileName(const Value: WideString); safecall;

        procedure Preview; safecall;
        procedure Design; safecall;
        procedure Print; safecall;

        procedure AddVariant_Boolean(const name: WideString; val: WordBool); safecall;
        procedure AddVariant_DateTime(const name: WideString; val: TDateTime); safecall;
        procedure AddVariant_String(const name, val: WideString); safecall;

        procedure AddVariant_Double(const name: WideString; val: Double); safecall;
        procedure AddVariant_Int(const name: WideString; val: SYSINT); safecall;
        function Get_ConnectionString: WideString; safecall;
        procedure AddSQL(const DataSetName, sql: WideString); safecall;
        procedure Set_ConnectionString(const Value: WideString); safecall;
    published

    public

    end;

implementation

uses ComObj;

{ TSlimRayPrint }

procedure TSlimRayPrint.DefinePropertyPages(DefinePropertyPage: TDefinePropertyPage);
begin
    {TODO: Define property pages here.  Property pages are defined by calling
      DefinePropertyPage with the class id of the page.  For example,
        DefinePropertyPage(Class_SlimRayPrintPage); }
end;

procedure TSlimRayPrint.EventSinkChanged(const EventSink: IUnknown);
begin
    FEvents := EventSink as ISlimRayPrintEvents;
end;

procedure TSlimRayPrint.InitializeControl;
begin
    _Report := TSRReport.Create(nil);
end;

function TSlimRayPrint.Get_ReportFileName: WideString;
begin
    result := _Report.ReportFileName;
end;

procedure TSlimRayPrint.Set_ReportFileName(const Value: WideString);
begin
    _Report.ReportFileName := value;
end;

procedure TSlimRayPrint.Preview;
begin
    _Report.Preview();
end;

procedure TSlimRayPrint.Design;
begin
    _Report.Design();
end;

procedure TSlimRayPrint.Print;
begin
    _Report.Print;
end;

procedure TSlimRayPrint.AddVariant_Boolean(const name: WideString;
    val: WordBool);
begin
    _Report.AddVariant(name, val, vtBoolean);
end;

procedure TSlimRayPrint.AddVariant_DateTime(const name: WideString;
    val: TDateTime);
begin
    _Report.AddVariant(name, val, vtDateTime);
end;

procedure TSlimRayPrint.AddVariant_String(const name, val: WideString);
begin
    _Report.AddVariant(name, val, vtString);
end;

procedure TSlimRayPrint.AddVariant_Double(const name: WideString;
    val: Double);
begin
    _Report.AddVariant(name, val, vtDouble);
end;

procedure TSlimRayPrint.AddVariant_Int(const name: WideString;
    val: SYSINT);
begin
    _Report.AddVariant(name, val, vtInt);
end;

function TSlimRayPrint.Get_ConnectionString: WideString;
begin
    result := _Report.ConnectionString;
end;

procedure TSlimRayPrint.AddSQL(const DataSetName, sql: WideString);
var
    s: TSQLGroup;
begin
    s.UserDataSetName := DataSetName;
    s.SQLText := sql;

    _Report.AddSQL(s);
end;

procedure TSlimRayPrint.Set_ConnectionString(const Value: WideString);
begin
    _Report.ConnectionString := value;
end;

initialization
    TActiveXControlFactory.Create(
        ComServer,
        TSlimRayPrint,
        TPanel,
        Class_SlimRayPrint,
        1,
        '',
        OLEMISC_SIMPLEFRAME or OLEMISC_ACTSLIKELABEL,
        tmSingle);
end.

