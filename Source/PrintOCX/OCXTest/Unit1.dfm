object Form1: TForm1
  Left = 267
  Top = 225
  Width = 383
  Height = 357
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 20
    Top = 52
    Width = 43
    Height = 13
    Caption = 'reportFile'
  end
  object Label2: TLabel
    Left = 28
    Top = 80
    Width = 13
    Height = 13
    Caption = 'sql'
  end
  object Button1: TButton
    Left = 152
    Top = 144
    Width = 75
    Height = 25
    Caption = 'Preview'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 72
    Top = 48
    Width = 261
    Height = 21
    TabOrder = 1
    Text = 'E:\Source\CardServer\Include\CardSave.fr3'
  end
  object Edit2: TEdit
    Left = 72
    Top = 76
    Width = 261
    Height = 21
    TabOrder = 2
    Text = 'exec cs_getcardsavewithdealid '#39'00004'#39
  end
end
