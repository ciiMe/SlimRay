unit SlimRayPrintOCX_TLB;

// ************************************************************************ //
// WARNING                                                                    
// -------                                                                    
// The types declared in this file were generated from data read from a       
// Type Library. If this type library is explicitly or indirectly (via        
// another type library referring to this type library) re-imported, or the   
// 'Refresh' command of the Type Library Editor activated while editing the   
// Type Library, the contents of this file will be regenerated and all        
// manual modifications will be lost.                                         
// ************************************************************************ //

// PASTLWTR : 1.2
// File generated on 2012-3-27 15:12:47 from Type Library described below.

// ************************************************************************  //
// Type Lib: E:\Source\CardServer\Source\PrintDemo\OCXSource\SlimRayPrintOCX.tlb (1)
// LIBID: {6C97B077-7003-43C9-A26D-F5A80C5EECA2}
// LCID: 0
// Helpfile: 
// HelpString: SlimRayPrintOCX Library
// DepndLst: 
//   (1) v2.0 stdole, (C:\WINDOWS\system32\stdole2.tlb)
// ************************************************************************ //
{$TYPEDADDRESS OFF} // Unit must be compiled without type-checked pointers. 
{$WARN SYMBOL_PLATFORM OFF}
{$WRITEABLECONST ON}
{$VARPROPSETTER ON}
interface

uses Windows, ActiveX, Classes, Graphics, OleCtrls, StdVCL, Variants;
  

// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_xxxx                                      
//   CoClasses          : CLASS_xxxx                                      
//   DISPInterfaces     : DIID_xxxx                                       
//   Non-DISP interfaces: IID_xxxx                                        
// *********************************************************************//
const
  // TypeLibrary Major and minor versions
  SlimRayPrintOCXMajorVersion = 1;
  SlimRayPrintOCXMinorVersion = 0;

  LIBID_SlimRayPrintOCX: TGUID = '{6C97B077-7003-43C9-A26D-F5A80C5EECA2}';

  IID_ISlimRayPrint: TGUID = '{5619D063-ABF5-4F92-BD9F-C232E6CF2C46}';
  DIID_ISlimRayPrintEvents: TGUID = '{ED046E36-7393-4139-9909-3C718A6D1AE0}';
  CLASS_SlimRayPrint: TGUID = '{970CC720-3F40-447F-8565-275A71712833}';

// *********************************************************************//
// Declaration of Enumerations defined in Type Library                    
// *********************************************************************//
// Constants for enum TReportVariantType
type
  TReportVariantType = TOleEnum;
const
  vtInt = $00000000;
  vtString = $00000001;
  vtDateTime = $00000002;
  vtBoolean = $00000003;
  vtDouble = $00000004;

// Constants for enum TReportExportType
type
  TReportExportType = TOleEnum;
const
  etExcel = $00000000;
  etCSV = $00000001;
  etWord = $00000002;
  etPDF = $00000003;
  etHTML = $00000004;
  etBMP = $00000005;
  etJPG = $00000006;

type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  ISlimRayPrint = interface;
  ISlimRayPrintDisp = dispinterface;
  ISlimRayPrintEvents = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
// *********************************************************************//
  SlimRayPrint = ISlimRayPrint;


// *********************************************************************//
// Declaration of structures, unions and aliases.                         
// *********************************************************************//
  TSQLGroup = packed record
    UserDataSetName: WideString;
    SQLText: WideString;
  end;


// *********************************************************************//
// Interface: ISlimRayPrint
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {5619D063-ABF5-4F92-BD9F-C232E6CF2C46}
// *********************************************************************//
  ISlimRayPrint = interface(IDispatch)
    ['{5619D063-ABF5-4F92-BD9F-C232E6CF2C46}']
    function Get_ReportFileName: WideString; safecall;
    procedure Set_ReportFileName(const Value: WideString); safecall;
    procedure AddVariant_String(const name: WideString; const val: WideString); safecall;
    procedure AddVariant_Int(const name: WideString; val: SYSINT); safecall;
    procedure AddVariant_Double(const name: WideString; val: Double); safecall;
    procedure AddVariant_Boolean(const name: WideString; val: WordBool); safecall;
    procedure AddVariant_DateTime(const name: WideString; val: TDateTime); safecall;
    function Get_ConnectionString: WideString; safecall;
    procedure Set_ConnectionString(const Value: WideString); safecall;
    procedure AddSQL(const DataSetName: WideString; const sql: WideString); safecall;
    procedure Preview; safecall;
    procedure Print; safecall;
    procedure Design; safecall;
    property ReportFileName: WideString read Get_ReportFileName write Set_ReportFileName;
    property ConnectionString: WideString read Get_ConnectionString write Set_ConnectionString;
  end;

// *********************************************************************//
// DispIntf:  ISlimRayPrintDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {5619D063-ABF5-4F92-BD9F-C232E6CF2C46}
// *********************************************************************//
  ISlimRayPrintDisp = dispinterface
    ['{5619D063-ABF5-4F92-BD9F-C232E6CF2C46}']
    property ReportFileName: WideString dispid 226;
    procedure AddVariant_String(const name: WideString; const val: WideString); dispid 203;
    procedure AddVariant_Int(const name: WideString; val: SYSINT); dispid 204;
    procedure AddVariant_Double(const name: WideString; val: Double); dispid 205;
    procedure AddVariant_Boolean(const name: WideString; val: WordBool); dispid 206;
    procedure AddVariant_DateTime(const name: WideString; val: TDateTime); dispid 207;
    property ConnectionString: WideString dispid 201;
    procedure AddSQL(const DataSetName: WideString; const sql: WideString); dispid 202;
    procedure Preview; dispid 208;
    procedure Print; dispid 209;
    procedure Design; dispid 210;
  end;

// *********************************************************************//
// DispIntf:  ISlimRayPrintEvents
// Flags:     (4096) Dispatchable
// GUID:      {ED046E36-7393-4139-9909-3C718A6D1AE0}
// *********************************************************************//
  ISlimRayPrintEvents = dispinterface
    ['{ED046E36-7393-4139-9909-3C718A6D1AE0}']
    procedure OnCanResize(var NewWidth: Integer; var NewHeight: Integer; var Resize: WordBool); dispid 201;
    procedure OnReportErrMsg(const msg: WideString); dispid 206;
  end;


// *********************************************************************//
// OLE Control Proxy class declaration
// Control Name     : TSlimRayPrint
// Help String      : SlimRayPrint Control
// Default Interface: ISlimRayPrint
// Def. Intf. DISP? : No
// Event   Interface: ISlimRayPrintEvents
// TypeFlags        : (2) CanCreate
// *********************************************************************//
  TSlimRayPrintOnCanResize = procedure(ASender: TObject; var NewWidth: Integer; 
                                                         var NewHeight: Integer; 
                                                         var Resize: WordBool) of object;
  TSlimRayPrintOnReportErrMsg = procedure(ASender: TObject; const msg: WideString) of object;

  TSlimRayPrint = class(TOleControl)
  private
    FOnCanResize: TSlimRayPrintOnCanResize;
    FOnReportErrMsg: TSlimRayPrintOnReportErrMsg;
    FIntf: ISlimRayPrint;
    function  GetControlInterface: ISlimRayPrint;
  protected
    procedure CreateControl;
    procedure InitControlData; override;
  public
    procedure AddVariant_String(const name: WideString; const val: WideString);
    procedure AddVariant_Int(const name: WideString; val: SYSINT);
    procedure AddVariant_Double(const name: WideString; val: Double);
    procedure AddVariant_Boolean(const name: WideString; val: WordBool);
    procedure AddVariant_DateTime(const name: WideString; val: TDateTime);
    procedure AddSQL(const DataSetName: WideString; const sql: WideString);
    procedure Preview;
    procedure Print;
    procedure Design;
    property  ControlInterface: ISlimRayPrint read GetControlInterface;
    property  DefaultInterface: ISlimRayPrint read GetControlInterface;
  published
    property Anchors;
    property  Align;
    property  DragCursor;
    property  DragMode;
    property  ParentShowHint;
    property  PopupMenu;
    property  ShowHint;
    property  TabOrder;
    property  Visible;
    property  OnDragDrop;
    property  OnDragOver;
    property  OnEndDrag;
    property  OnEnter;
    property  OnExit;
    property  OnStartDrag;
    property ReportFileName: WideString index 226 read GetWideStringProp write SetWideStringProp stored False;
    property ConnectionString: WideString index 201 read GetWideStringProp write SetWideStringProp stored False;
    property OnCanResize: TSlimRayPrintOnCanResize read FOnCanResize write FOnCanResize;
    property OnReportErrMsg: TSlimRayPrintOnReportErrMsg read FOnReportErrMsg write FOnReportErrMsg;
  end;

procedure Register;

resourcestring
  dtlServerPage = 'Servers';

  dtlOcxPage = 'ActiveX';

implementation

uses ComObj;

procedure TSlimRayPrint.InitControlData;
const
  CEventDispIDs: array [0..1] of DWORD = (
    $000000C9, $000000CE);
  CControlData: TControlData2 = (
    ClassID: '{970CC720-3F40-447F-8565-275A71712833}';
    EventIID: '{ED046E36-7393-4139-9909-3C718A6D1AE0}';
    EventCount: 2;
    EventDispIDs: @CEventDispIDs;
    LicenseKey: nil (*HR:$00000000*);
    Flags: $00000000;
    Version: 401);
begin
  ControlData := @CControlData;
  TControlData2(CControlData).FirstEventOfs := Cardinal(@@FOnCanResize) - Cardinal(Self);
end;

procedure TSlimRayPrint.CreateControl;

  procedure DoCreate;
  begin
    FIntf := IUnknown(OleObject) as ISlimRayPrint;
  end;

begin
  if FIntf = nil then DoCreate;
end;

function TSlimRayPrint.GetControlInterface: ISlimRayPrint;
begin
  CreateControl;
  Result := FIntf;
end;

procedure TSlimRayPrint.AddVariant_String(const name: WideString; const val: WideString);
begin
  DefaultInterface.AddVariant_String(name, val);
end;

procedure TSlimRayPrint.AddVariant_Int(const name: WideString; val: SYSINT);
begin
  DefaultInterface.AddVariant_Int(name, val);
end;

procedure TSlimRayPrint.AddVariant_Double(const name: WideString; val: Double);
begin
  DefaultInterface.AddVariant_Double(name, val);
end;

procedure TSlimRayPrint.AddVariant_Boolean(const name: WideString; val: WordBool);
begin
  DefaultInterface.AddVariant_Boolean(name, val);
end;

procedure TSlimRayPrint.AddVariant_DateTime(const name: WideString; val: TDateTime);
begin
  DefaultInterface.AddVariant_DateTime(name, val);
end;

procedure TSlimRayPrint.AddSQL(const DataSetName: WideString; const sql: WideString);
begin
  DefaultInterface.AddSQL(DataSetName, sql);
end;

procedure TSlimRayPrint.Preview;
begin
  DefaultInterface.Preview;
end;

procedure TSlimRayPrint.Print;
begin
  DefaultInterface.Print;
end;

procedure TSlimRayPrint.Design;
begin
  DefaultInterface.Design;
end;

procedure Register;
begin
  RegisterComponents(dtlOcxPage, [TSlimRayPrint]);
end;

end.
