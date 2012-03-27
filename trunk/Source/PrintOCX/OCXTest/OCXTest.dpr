program OCXTest;

uses
  Forms,
  SlimRayPrintOCX_TLB in '..\OCXSource\SlimRayPrintOCX_TLB.pas',
  uSRReport in '..\OCXSource\uSRReport.pas',
  Unit1 in 'Unit1.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
