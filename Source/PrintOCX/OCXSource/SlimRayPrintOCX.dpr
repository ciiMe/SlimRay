library SlimRayPrintOCX;

uses
  ComServ,
  SlimRayPrintOCX_TLB in 'SlimRayPrintOCX_TLB.pas',
  SlimRayPrintImpl in 'SlimRayPrintImpl.pas' {SlimRayPrint: CoClass},
  uTestForm in 'uTestForm.pas' {frmTestForm},
  uSRReport in 'uSRReport.pas';

{$E ocx}

exports
    DllGetClassObject,
    DllCanUnloadNow,
    DllRegisterServer,
    DllUnregisterServer;
{$R *.TLB}

{$R *.RES}

begin
end.

