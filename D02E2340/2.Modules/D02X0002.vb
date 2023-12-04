Imports System.Text
''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>

Module D02X0002

    ''' <summary>
    ''' Cập nhật số thứ tự cho lưới
    ''' </summary>
    Public Sub UpdateOrderNum(ByVal TDBGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer)
        For i As Integer = 0 To TDBGrid.RowCount - 1
            TDBGrid(i, iCol) = i + 1
        Next
    End Sub

    ''' <summary>
    ''' Kiểm tra sự tồn tại của 1 giá trị trong 1 cột trên lưới với nguồn dữ liệu trong TDBDropdown
    ''' </summary>
    Public Function CheckExist(ByVal pTDBD As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal piCol As Integer, ByVal sText As String) As Boolean
        For i As Integer = 0 To pTDBD.RowCount - 1
            pTDBD.Row = i
            If pTDBD.Columns(piCol).Text = sText Then Return True
        Next
        Return False
    End Function

    Private Function FindSxType(ByVal nType As String, ByVal s As String) As String
        Select Case nType.Trim
            Case "1" ' Theo tháng
                Return giTranMonth.ToString("00")
            Case "2" ' Theo năm
                Return giTranYear.ToString
            Case "3" ' Theo loại chứng từ
                Return s
            Case "4" ' Theo đơn vị
                Return gsDivisionID
            Case "5" ' Theo hằng
                Return s
            Case Else
                Return ""
        End Select
    End Function
  
    ''' <summary>
    ''' Xác định ví trí hiện hành của lưới
    ''' </summary>
    Public Sub SetCurrentRow(ByVal TDBGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer, ByVal sText As String)
        If TDBGrid.RowCount > 0 Then
            For i As Integer = 0 To TDBGrid.RowCount - 1
                If TDBGrid(i, iCol).ToString() = sText Then
                    TDBGrid.Row = i
                    Exit Sub
                End If
            Next
            TDBGrid.Row = 0
        End If
    End Sub

    '''' <summary>
    '''' Tính tổng cho 1 cột tương ứng trên lưới
    '''' </summary>
    '''' <param name="ipCol"></param>
    '''' <param name="C1Grid"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>

    'Public Function Sum(ByVal ipCol As Integer, ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Double
    '    Dim lSum As Double = 0
    '    For i As Integer = 0 To C1Grid.RowCount - 1
    '        If C1Grid(i, ipCol) Is Nothing OrElse TypeOf (C1Grid(i, ipcol)) Is DBNull Then Continue For
    '        lSum += Convert.ToDouble(C1Grid(i, ipCol))
    '    Next
    '    Return lSum
    'End Function

   
    '#--------------------------------------------------------------------------
    '#CreateUser: Trần Thị Ái Trâm
    '#CreateDate: 04/09/2007
    '#ModifiedUser:
    '#ModifiedDate:
    '#Description: Hàm kiểm tra Audit log
    '#--------------------------------------------------------------------------
    Public Function PermissionAudit(ByVal sAuditCode As String) As Byte
        Dim sSQL As String
        Dim dt As DataTable

        sSQL = "Select Audit From D91T9200 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where AuditCode=" & SQLString(sAuditCode)

        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            If CByte(dt.Rows(0).Item("Audit")) = 1 Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD91P9106
    '# Created User: Trần Thị ÁiTrâm
    '# Created Date: 04/09/2007 11:30:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    'Private Function SQLStoreD91P9106(ByVal sAuditCode As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String, ByVal nIsAuditDetail As Integer, ByVal sAuditItemID As String) As String
    '    Dim sSQL As String = ""
    '    sSQL &= "Exec D91P9106 "
    '    sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
    '    sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
    '    sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
    '    sSQL &= SQLString("02") & COMMA 'ModuleID, varchar[2], NOT NULL
    '    sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
    '    sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
    '    sSQL &= SQLString(sDesc5) & COMMA 'Desc5, varchar[250], NOT NULL
    '    sSQL &= SQLNumber(nIsAuditDetail) & COMMA 'IsAuditDetail,tinyint
    '    sSQL &= SQLString(sAuditItemID)  'AuditItemID, varchar[50], NOT NULL

    '    Return sSQL
    'End Function

    '#--------------------------------------------------------------------------
    '#CreateUser: Trần Thị ÁiTrâm
    '#CreateDate: 04/09/2007
    '#ModifiedUser:
    '#ModifiedDate:
    '#Description: Thực thi store Audit Log
    '#--------------------------------------------------------------------------
    'Public Sub ExecuteAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, Optional ByVal sDesc1 As String = "", Optional ByVal sDesc2 As String = "", Optional ByVal sDesc3 As String = "", Optional ByVal sDesc4 As String = "", Optional ByVal sDesc5 As String = "", Optional ByVal nIsAuditDetail As Integer = 0, Optional ByVal sAuditItemID As String = "")
    '    Dim sSQL As String
    '    sSQL = SQLStoreD91P9106(sAuditCode, sEventID, sDesc1, sDesc2, sDesc3, sDesc4, sDesc5, nIsAuditDetail, sAuditItemID)
    '    ExecuteSQL(sSQL)
    'End Sub

    Public Function InsertFormat(ByVal ONumber As Object) As String
        Dim iNumber As Int16 = Convert.ToInt16(ONumber)
        Dim sRet As String = "#,##0"
        If iNumber = 0 Then
        Else
            sRet &= "." & Strings.StrDup(iNumber, "0")
        End If
        Return sRet
    End Function

    Public Function GetOriginalDecimal(ByVal sCurrencyID As String) As String

        Dim sSQL As String
        sSQL = "Select OriginalDecimal From D91V0010 Where CurrencyID = " & SQLString(sCurrencyID)
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            Return InsertFormat(dt.Rows(0).Item("OriginalDecimal"))
        Else
            Return DxxFormat.DecimalPlaces
        End If
    End Function

    Public Function InserZero(ByVal NumZero As Byte) As String
        '#------------------------------------------------------
        '#CreateUser: Nguyen Thi Minh Hoa
        '#CreateDate: 04/04/2006
        '#ModifiedUser:  Nguyen Thi Minh Hoa
        '#ModifiedDate:  04/04/2006
        '#Description: Format so theo D91
        '#------------------------------------------------------
        If NumZero = 0 Then
            InserZero = ""
        Else
            InserZero = "."
            InserZero &= StrDup(NumZero, "0")
        End If
    End Function

    Public Sub GetVoucherNo(ByVal tdbcVoucherTypeID As C1.Win.C1List.C1Combo, ByVal txtVoucherNo As TextBox, ByVal btnSetNewKey As Windows.Forms.Button)
        If tdbcVoucherTypeID.Text <> "" Then
            If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'Không tạo mã tự động
                txtVoucherNo.ReadOnly = False
                txtVoucherNo.TabStop = True
                btnSetNewKey.Enabled = False
                txtVoucherNo.Text = ""
            Else
                gnNewLastKey = 0
                txtVoucherNo.ReadOnly = True
                txtVoucherNo.TabStop = False
                btnSetNewKey.Enabled = True
                txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
            End If
        End If
    End Sub

    'Hàm ReturnTableFilter cải tiến
    Public Function ReturnTableFilter1(ByVal dt As DataTable, ByVal sWhereClause As String) As DataTable
        Dim dt1 As DataTable
        dt.DefaultView.RowFilter = sWhereClause
        dt1 = dt.DefaultView.ToTable
        Return dt1
    End Function

    Public Function SetGetDateSQL() As String
        Dim sSQL As String
        sSQL = "Select Getdate() as CreateDate "
        Return ReturnScalar(sSQL)
    End Function

    Public Sub Run1(ByVal sEXECHILD As String)
        If Not ExistFile(gsApplicationSetup & "\" & EXECHILD & ".exe") Then Exit Sub
        Dim pInfo As New System.Diagnostics.ProcessStartInfo(gsApplicationSetup & "\" & EXECHILD & ".exe")
        pInfo.Arguments = "/DigiNet Corporation"
        pInfo.WindowStyle = ProcessWindowStyle.Normal
        Process.Start(pInfo)
    End Sub

    ''' <summary>
    ''' Kiểm tra tồn tại exe con không ?
    ''' </summary>
    Private Function ExistFile(ByVal Path As String) As Boolean
        If System.IO.File.Exists(Path) Then Return True
        If geLanguage = EnumLanguage.Vietnamese Then
            D99C0008.MsgL3("Không tồn tại file " & EXECHILD & ".exe")
        Else
            D99C0008.MsgL3("Not exist file " & EXECHILD & ".exe")
        End If
        Return False
    End Function

    'Câu đổ nguồn chung cho SubReport
    Public Function SQLSubReport(ByVal sDivisionID As String) As String
        Dim sSQL As String = ""
        sSQL = "Select * From D91V0016" & vbCrLf
        sSQL &= "Where DivisionID = " & SQLString(sDivisionID)
        Return sSQL
    End Function

    Public Sub InsertD02T5558(ByVal sVoucherID As String, ByVal sOldVoucherNo As String, ByVal sNewVoucherNo As String)
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D02T5558(")
        sSQL.Append("BatchID, OldVoucherNo, NewVoucherNo, CreateUserID, CreateDate, ")
        sSQL.Append("TranMonth, TranYear, DivisionID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(sVoucherID) & COMMA) 'VoucherID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sOldVoucherNo) & COMMA) 'OldVoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLString(sNewVoucherNo) & COMMA) 'NewVoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear)) 'TranYear, int, NOT NULL
        sSQL.Append(COMMA & SQLString(gsDivisionID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append(")")

        ExecuteSQL(sSQL.ToString)
    End Sub

    '''' <summary>
    '''' Trả về tên báo cáo
    '''' </summary>
    '''' <param name="sReportTypeID">Tên form</param>
    '''' <param name="sStandardReportID">Standard Report</param>
    '''' <param name="sCustomizedReportID">Custom Report</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function GetReportPath(ByVal sReportTypeID As String, ByVal sStandardReportID As String, ByVal sCustomizedReportID As String) As String
    '    Dim sReturnReportID As String = ""
    '    Dim byViewPathReport As Boolean = CBool(D02Options.ShowReportPath)

    '    'Hien thi duong man hinh duong dan
    '    If byViewPathReport = True Then
    '        Dim frm As New D99F6666
    '        With frm
    '            .nReportLanguage = D02Options.ReportLanguage
    '            .sModuleID = "02"
    '            .ReportTypeID = sReportTypeID
    '            .StandardReportID = sStandardReportID
    '            .CustomizedReportID = sCustomizedReportID
    '            .ShowDialog()
    '            sReturnReportID = .ReturnReportID
    '            .Dispose()
    '        End With

    '    Else
    '        'Khong Hien thi duong man hinh duong dan
    '        If sCustomizedReportID <> "" Then
    '            gsReportPath = Application.StartupPath & PathCustomizedReport9 & sCustomizedReportID & ".rpt"
    '            sReturnReportID = sCustomizedReportID
    '        Else
    '            'gsReportPath = Application.StartupPath & PathReport9 & sStandardForm & ".rpt"
    '            gsReportPath = Application.StartupPath & "\XReports\"
    '            If D02Options.ReportLanguage = 0 Then
    '                gsReportPath = gsReportPath
    '            ElseIf D02Options.ReportLanguage = 1 Then
    '                gsReportPath = gsReportPath & "VE-XReports\"
    '            ElseIf D02Options.ReportLanguage = 2 Then
    '                gsReportPath = gsReportPath & "E-XReports\"
    '            End If
    '            gsReportPath = gsReportPath & sStandardReportID & ".rpt"
    '            sReturnReportID = sStandardReportID
    '        End If
    '    End If

    '    GetReportPath = sReturnReportID
    'End Function

#Region "Màn hình chọn đường dẫn báo cáo"

    'Public Function GetReportPath(ByVal ReportTypeID As String, ByVal ReportName As String, ByVal CustomReport As String, ByRef ReportPath As String, Optional ByRef ReportTitle As String = "", Optional ByVal ModuleID As String = "02") As String
    '    'Dim bShowReportPath As Boolean
    '    'Dim iReportLanguage As Byte
    '    ''Lấy giá trị PARA_ModuleID từ module gọi đến
    '    ''Nếu là exe chính (không có biến PARA_ModuleID) thì lấy Dxx 
    '    'bShowReportPath = CType(D99C0007.GetModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
    '    'iReportLanguage = CType(D99C0007.GetModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
    '    ''Lấy đường dẫn báo cáo từ module D99X0004
    '    'ReportPath = UnicodeGetReportPath(gbUnicode, iReportLanguage, "")
    '    'If bShowReportPath Then 'Hiển thị màn hình chọn đường dẫn báo cáo
    '    '    Dim frm As New D99F6666
    '    '    With frm
    '    '        .ModuleID = ModuleID '2 ký tự, tùy theo từng module có thể lấy theo module gốc chứa exe con hoặc module gọi đến.
    '    '        .ReportTypeID = ReportTypeID
    '    '        .ReportName = ReportName
    '    '        .CustomReport = CustomReport
    '    '        .ReportPath = ReportPath
    '    '        .ReportTitle = ReportTitle
    '    '        .ShowDialog()
    '    '        ReportName = .ReportName
    '    '        ReportPath = .ReportPath
    '    '        gsReportPath = ReportPath 'biến toàn cục đang dùng 
    '    '        ReportTitle = .ReportTitle
    '    '        SaveOptionReport(.ShowReportPath)
    '    '        .Dispose()
    '    '    End With
    '    'Else 'Không hiển thị thì lấy theo Loại nghiệp vụ (nếu có)
    '    '    If CustomReport <> "" Then
    '    '        ReportPath = gsApplicationSetup & "\XCustom\"
    '    '        ReportName = CustomReport
    '    '    End If
    '    'End If
    '    'ReportPath = ReportPath & ReportName & ".rpt"
    '    'Return ReportName
    '    Return Lemon3.Reports.GetReportPath(ReportTypeID, ReportName, CustomReport, ReportPath, ReportTitle, ModuleID, D02Options.ShowReportPath, D02Options.ReportLanguage)
    'End Function
    'Tùy thuộc từng module có biến lưu dưới Registry
    'Public Sub SaveOptionReport(ByVal bShowReportPath As Boolean)
    '    'D99C0007.SaveModulesSetting("D" & PARA_ModuleID, ModuleOption.lmOptions, "ShowReportPath", bShowReportPath)
    '    If "D" & PARA_ModuleID = D02 Then 'Module gốc
    '        'Nếu module nào có thêm code VB6 thì lưu thêm nhánh VB6
    '        'SaveSetting("Lemon3_D05", "Options", "NotShowDirectory", (Not bShowReportPath).ToString) 'Nhánh VB6
    '        D02Options.ShowReportPath = bShowReportPath 'Biến Tùy chọn
    '    End If
    'End Sub

#End Region

    Public Function ComboValue(ByVal tdbc As C1.Win.C1List.C1Combo) As String
        If tdbc.Text = "" Or tdbc.SelectedValue Is Nothing Then Return ""
        Return tdbc.SelectedValue.ToString
    End Function

   End Module