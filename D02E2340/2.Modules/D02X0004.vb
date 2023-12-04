''' <summary>
''' Các vấn đề liên quan đến Thông tin hệ thống và Tùy chọn
''' </summary>
Module D02X0004
    ''' <summary>
    ''' Load toàn bộ các thông số tùy chọn vào biến D02Options
    ''' </summary>

    Public Sub LoadOptions()
        With D02Options
            'Kiểm tra tồn tại đường dẫn mới lưu .Net thì lấy dữ liệu, ngược lại thì lấy theo đường dẫn cũ (Lemon3_Dxx)
            'Kiem tra ky cac ten luu xuong cua VB6 de gan vao NET

            Dim D02LocalOptionsLocations As String = "D02"
            Dim Options As String = "Options"

            If D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "MessageAskBeforeSave") = "" Then 'Lay duong dan cu VB6
                With D02Options
                    .DefaultDivisionID = GetSetting(D02LocalOptionsLocations, Options, "Division", "")
                    .MessageAskBeforeSave = CType(GetSetting(D02LocalOptionsLocations, Options, "AskBeforeSave", "True"), Boolean)
                    .MessageWhenSaveOK = CType(GetSetting(D02LocalOptionsLocations, Options, "MessageWhenSaveOK", "True"), Boolean)
                    .SaveLastRecent = CType(GetSetting(D02LocalOptionsLocations, Options, "SaveRecentValues", "False"), Boolean)
                    .RoundConvertedAmount = CType(GetSetting(D02LocalOptionsLocations, Options, "RoundConvertedAmount", "False"), Boolean)
                    .LockConvertedAmount = CType(GetSetting(D02LocalOptionsLocations, Options, "LockConvertedAmount", "False"), Boolean)
                    .ViewFormPeriodWhenAppRun = CType(GetSetting(D02LocalOptionsLocations, Options, "AcountingScreen", "False"), Boolean)
                    .ViewWorkflow = CType(GetSetting(D02LocalOptionsLocations, Options, "ShowDiagramTransaction", "False"), Boolean)
                    '.ReportLanguage = CType(GetSetting(D02LocalOptionsLocations, Options, "nRPLang", "0"), Integer)
                    '.ShowReportPath = CType(GetSetting(D02LocalOptionsLocations, Options, "ChoosePrintType", "True"), Boolean)
                End With
            Else 'Lấy đường dẫn mới .Net
                With D02Options
                    .DefaultDivisionID = D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "DefaultDivisionID", "")
                    .MessageAskBeforeSave = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"), Boolean)
                    .MessageWhenSaveOK = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"), Boolean)
                    .SaveLastRecent = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "SaveLastRecent", "False"), Boolean)
                    .RoundConvertedAmount = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "RoundConvertedAmount", "False"), Boolean)
                    .LockConvertedAmount = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "LockConvertedAmount", "False"), Boolean)
                    .ViewFormPeriodWhenAppRun = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"), Boolean)
                    .ViewWorkflow = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ViewWorkflow", "False"), Boolean)
                    '.ReportLanguage = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ReportLanguage", "0"), Integer)
                    '.ShowReportPath = CType(D99C0007.GetModulesSetting(D02, ModuleOption.lmOptions, "ChoosePrintType", "True"), Boolean)
                End With
            End If

            Dim Dxx As String = "D" & PARA_ModuleID 'PARA_ModuleID: lấy giá trị tại hàm GetAllParameter() : PARA_ModuleID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ModuleID", xx)
            With D02Options
                If D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ReportLanguage") = "" Then ' Lấy đường dẫn VB6
                    .ReportLanguage = CType(GetSetting(D02LocalOptionsLocations, "Options", "nRPLang", "0"), Byte)
                    'Luu gtri moi
                    D99C0007.SaveModulesSetting(Dxx, ModuleOption.lmOptions, "ReportLanguage", .ReportLanguage.ToString)
                Else 'Lấy đường dẫn VBNET
                    .ReportLanguage = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
                End If

                If D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ShowReportPath") = "" Then
                    .ShowReportPath = CType(GetSetting(D02LocalOptionsLocations, Options, "ViewPathReport", "True"), Boolean)
                    'Luu gtri moi
                    D99C0007.SaveModulesSetting(Dxx, ModuleOption.lmOptions, "ShowReportPath", .ShowReportPath)
                Else 'Lấy đường dẫn VBNET
                    .ShowReportPath = CType(D99C0007.GetModulesSetting(Dxx, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
                End If

            End With

        End With
    End Sub

    ''' <summary>
    ''' Hỏi trước khi lưu tùy thuộc vào thiết lập ở phần Tùy chọn
    ''' </summary>
    Public Function AskSave() As DialogResult
        If D02Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAskSave()
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo trước khi xóa
    ''' </summary>    
    Public Function AskDelete() As DialogResult
        If D02Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAskDelete
        Else
            Return DialogResult.Yes
        End If
    End Function

    ''' <summary>
    ''' Thông báo khi lưu thành công tùy theo phần thiết lập ở tùy chọn
    ''' </summary>
    Public Sub SaveOK()
        If D02Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    ''' <summary>
    ''' Thông báo sau khi xóa thành công
    ''' </summary>
    Public Sub DeleteOK()
        If D02Options.MessageWhenSaveOK Then D99C0008.MsgL3(rl3("MSG000008"))

    End Sub

    ''' <summary>
    ''' Thông báo không lưu được dữ liệu
    ''' </summary>
    Public Sub SaveNotOK()
        D99C0008.MsgSaveNotOK()
    End Sub

    ''' <summary>
    ''' Thông báo không xóa được dữ liệu
    ''' </summary>
    Public Sub DeleteNotOK()
        'D99C0008.MsgL3("Không xóa được dữ liệu")
        D99C0008.MsgCanNotDelete()
    End Sub
    ''' <summary>
    ''' Thông báo cột đã bị khóa khi nhấn phím nóng trên cột này để copy, xóa
    ''' </summary>
    Public Function MsgLockedColumn() As String
        Dim sMsg As String = ""
        sMsg = rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay") 'rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay")
        Return sMsg

    End Function

    'Public Sub SaveOptionReport(ByVal bChecked As Boolean)
    '    Dim D02LocalOptionsLocations As String = "D02"
    '    Dim Options As String = "Options"
    '    If bChecked = True Then
    '        SaveSetting(D02LocalOptionsLocations, Options, "ChoosePrintType", "True")
    '        D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "ChoosePrintType", "True")
    '        D02Options.ShowReportPath = True
    '    Else
    '        SaveSetting(D02LocalOptionsLocations, Options, "ChoosePrintType", "False")
    '        D99C0007.SaveModulesSetting(D02, ModuleOption.lmOptions, "ChoosePrintType", "False")
    '        D02Options.ShowReportPath = False
    '    End If
    'End Sub

End Module
