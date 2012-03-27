unit Unit1;

interface

uses
    Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
    Dialogs, StdCtrls,
    uSRReport,
    SlimRayPrintOCX_TLB
    ;

type
    TForm1 = class(TForm)
        Button1: TButton;
        Edit1: TEdit;
        Edit2: TEdit;
        Label1: TLabel;
        Label2: TLabel;

        procedure Button1Click(Sender: TObject);
    private
        { Private declarations }
    public
        { Public declarations }
    end;

var
    Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
    r: TSRReport;
    s: TSQLGroup;
begin

    r := TSRReport.Create(self);

    r.ConnectionString := 'Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;Initial Catalog=CardServer;Data Source=10.130.0.24';
    r.ReportFileName := self.Edit1.Text;

    s.UserDataSetName := 'frdd';
    s.SQLText := self.Edit2.Text;

    r.AddSQL(s);

    r.AddVariant('PrintUser', 'Tom..', vtString);
    r.AddVariant('UserAge', 29, vtInt);
    r.AddVariant('isNormal', true, vtBoolean);
    r.AddVariant('BirthDay', StrToDateTime('1980-2-13'), vtDateTime);
    r.AddVariant('TotalMoney', 1000.24, vtInt);

    r.Preview();

    {
    r.Design;
    r.Print;
    }
    r.Destroy;
end;

end.

