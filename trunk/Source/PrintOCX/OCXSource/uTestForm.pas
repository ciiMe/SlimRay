unit uTestForm;

interface

uses
    Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
    Dialogs,
    frxExportCSV, frxExportImage, frxExportRTF, frxExportXLS,
    frxExportHTML, frxExportPDF,
    frxClass, frxDBSet, frxDesgn,
    DB, ADODB;

type
    TfrmTestForm = class(TForm)
        ADOConnection1: TADOConnection;
        ADOQuery1: TADOQuery;
        frxReport1: TfrxReport;
        frxDesigner1: TfrxDesigner;
        frxDBDataset1: TfrxDBDataset;
        frxPDFExport1: TfrxPDFExport;
        frxHTMLExport1: TfrxHTMLExport;
        frxXLSExport1: TfrxXLSExport;
        frxRTFExport1: TfrxRTFExport;
        frxBMPExport1: TfrxBMPExport;
        frxJPEGExport1: TfrxJPEGExport;
        frxCSVExport1: TfrxCSVExport;
    private
        { Private declarations }
    public
        { Public declarations }
    end;

var
    frmTestForm: TfrmTestForm;

implementation

{$R *.dfm}

end.

