'#######################################################################################
'#                                     CHÚ Ý
'#--------------------------------------------------------------------------------------
'# Không được thay đổi bất cứ dòng code này trong module này, nếu muốn thay đổi bạn phải
'# liên lạc với Trưởng nhóm để được giải quyết.
'# Ngày tạo: 28/06/2012
'# Người tạo: Nguyễn Thị Ánh
'# Ngày cập nhật cuối cùng: 13/11/2012
'# Người cập nhật cuối cùng: Lê Phương
'# Bổ sung Đổ nguồn Dự án, Hạng mục
'# Bổ sung Đổ nguồn Mã XDCB
'#######################################################################################
''' <summary>
''' Module liên quan đến các vấn đề Load nguồn
''' </summary>
''' <remarks></remarks>
Module D99X0012

#Region "Đơn vị tính"
    Public Function ReturnTableUnitID(ByVal sInventoryID As String, Optional ByVal sOrderby As String = "") As DataTable
        Dim sSQL As String = ""
        sSQL &= "SELECT T1.UnitID,T2.UnitName" & UnicodeJoin(gbUnicode) & " as UnitName, IsNull(T1.ConversionFactor,1) As ConversionFactor, T1.Tolerance,T1.UseFormula,T1.Formula " & vbCrLf
        sSQL &= " FROM D07T0004 T1  " & vbCrLf
        sSQL &= "INNER JOIN  D07T0005 T2  ON  T1.UnitID=T2.UnitID" & vbCrLf
        sSQL &= "WHERE T1.Disabled=0 And T1.InventoryID=" & SQLString(sInventoryID)
        If sOrderby <> "" Then sSQL &= vbCrLf & "Order by " & sOrderby
        Return ReturnDataTable(sSQL)
    End Function

    Public Sub LoadtdbdUnitID(ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sInventoryID As String, Optional ByVal sOrderby As String = "")
        LoadDataSource(tdbd, ReturnTableUnitID(sInventoryID, sOrderby), gbUnicode)
    End Sub

    '#------------------------------------------------------------------------
    '#Title: SQLStoreD07P7004
    '#Create User: Nguyễn Thị Ánh
    '#Create Date: 25/12/2007 10:11:08
    '#Modified User:
    '#Modified Date:
    '#Description: Lấy ConversionFactor khi UseFormula=1
    '#------------------------------------------------------------------------
    Private Function SQLStoreD07P7004(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sFieldFormula As String) As String
        Dim sSQL As String = ""
        sSQL = "Exec D07P7004 "
        Try
            sSQL &= SQLString(tdbg.Columns("InventoryID").Text) & COMMA  ' InventoryID
            sSQL &= SQLString(tdbg.Columns("LocationNo").Text) & COMMA ' LocationNo
            sSQL &= SQLString(tdbg.Columns("Spec01ID").Text) & COMMA  ' Spec01ID
            sSQL &= SQLString(tdbg.Columns("Spec02ID").Text) & COMMA  ' Spec02ID
            sSQL &= SQLString(tdbg.Columns("Spec03ID").Text) & COMMA  ' Spec03ID
            sSQL &= SQLString(tdbg.Columns("Spec04ID").Text) & COMMA  ' Spec04ID
            sSQL &= SQLString(tdbg.Columns("Spec05ID").Text) & COMMA  ' Spec05ID
            sSQL &= SQLString(tdbg.Columns("Spec06ID").Text) & COMMA  ' Spec06ID
            sSQL &= SQLString(tdbg.Columns("Spec07ID").Text) & COMMA  ' Spec07ID
            sSQL &= SQLString(tdbg.Columns("Spec08ID").Text) & COMMA  ' Spec08ID
            sSQL &= SQLString(tdbg.Columns("Spec09ID").Text) & COMMA  ' Spec09ID
            sSQL &= SQLString(tdbg.Columns("Spec10ID").Text) & COMMA  ' Spec10ID
            sSQL &= SQLString(tdbg.Columns(sFieldFormula).Text)  ' Formula
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
        Return sSQL
    End Function

    ''' <summary>
    ''' Trả về Hệ số quy đổi theo D07P7004 khi UseConversionFormula =1
    ''' </summary>
    ''' <param name="tdbg"></param>
    ''' <param name="sFieldFormula">Field ConversionFormula trên lưới</param>
    ''' <returns>Hệ số quy đổi theo Result của D07P7004</returns>
    ''' <remarks>Mặc định trả về 1</remarks>
    Public Function ReturnConversionFactor(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sFieldFormula As String) As Object
        Dim dt As DataTable = ReturnDataTable(SQLStoreD07P7004(tdbg, sFieldFormula))
        If dt.Rows.Count > 0 Then Return dt.Rows(0).Item("Result")
        Return 1
    End Function
#End Region

#Region "Đổ nguồn Kho hàng"
    ''' <summary>
    ''' Trả về Table Kho hàng của tất cả Đơn vị
    ''' </summary>
    ''' <param name="bAll">Sử dụng Tất cả. Mặc định True</param>
    ''' <param name="sWhere">Điều kiện lọc. Mặc định ""</param>
    ''' <returns>Table Kho hàng</returns>
    ''' <remarks>Nghiệp vụ thêm sWhere = Disabled = 0. Ngược lại thì không có</remarks>
    Private Function ReturnTableWareHouseID(Optional ByVal bAll As Boolean = True, Optional ByVal sWhere As String = "") As DataTable
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon Kho hang" & vbCrLf)
        If bAll Then sSQL &= "Select " & AllCode & " as WareHouseID, " & AllName & " as WareHouseName, '%' as DivisionID, 0 as DisplayOrder " & vbCrLf & "Union All" & vbCrLf
        sSQL &= "Select WareHouseID, WareHouseName" & UnicodeJoin(gbUnicode) & " as WareHouseName, DivisionID,  1 as DisplayOrder " & vbCrLf
        sSQL &= "From D07T0007 " & vbCrLf
        sSQL &= "Where ( DAGroupID = '' OR DAGroupID IN (SELECT DAGroupID From LEMONSYS.DBO.D00V0080  WHERE UserID = " & SQLString(gsUserID) & ") OR 'LEMONADMIN' =" & SQLString(gsUserID) & ")" & vbCrLf
        If sWhere <> "" Then sSQL &= " And " & sWhere & vbCrLf
        sSQL &= "Order by DisplayOrder, WareHouseID"
        Return ReturnDataTable(sSQL)
    End Function

    ''' <summary>
    ''' Đổ nguồn cho nhiều combo Kho hàng phụ thuộc Đơn vị
    ''' </summary>
    ''' <param name="tdbc">Danh sách combo</param>
    ''' <param name="dtWareHouse">Có thể truyền Nothing</param>
    ''' <param name="bTransaction">Sử dụng Nghiệp vụ (True)/ Truy vấn/ Báo cáo (False). Nghiệp vụ thêm Disabled = 0. Ngược lại thì không có</param>
    ''' <param name="sDivsionID">Đơn vị. Mặc định rỗng</param>
    ''' <param name="bAll">Sử dụng Tất cả. Mặc định True</param>
    ''' <remarks>Có thể lấy được dtWareHouse nếu truyền Nothing. LoadtdbcWareHouseID(New C1.Win.C1List.C1Combo() {tdbcWareHouseIDFrom, tdbcWareHouseIDTo}, dtWareHouse, tdbcDivisionID.SelectedValue.ToString)</remarks>
    ''' 
    Public Sub LoadtdbcWareHouseID(ByVal tdbc() As C1.Win.C1List.C1Combo, ByRef dtWareHouse As DataTable, ByVal bTransaction As Boolean, Optional ByVal sDivsionID As String = "", Optional ByVal bAll As Boolean = True)
        If dtWareHouse Is Nothing Then dtWareHouse = ReturnTableWareHouseID(bAll, IIf(bTransaction, " Disabled = 0", "").ToString)

        Dim sFilter As String = ""
        If sDivsionID <> "%" And sDivsionID <> "" Then sFilter = " DivisionID = " & SQLString(sDivsionID) & " or DivisionID = '%'"
        Dim dtTemp As DataTable = ReturnTableFilter(dtWareHouse, sFilter, True)
        For i As Integer = 0 To tdbc.Length - 1
            LoadDataSource(tdbc(i), dtTemp.DefaultView.ToTable, gbUnicode)
            If bAll Then tdbc(i).SelectedIndex = 0
            Try
                tdbc(i).Columns("DivisionID").Caption = r("Don_vi")
                tdbc(i).Splits(0).DisplayColumns("DivisionID").Visible = sDivsionID = "%"
            Catch ex As Exception

            End Try
        Next
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho nhiều combo Kho hàng theo Đơn vị hiện tại
    ''' </summary>
    ''' <param name="tdbc">Danh sách combo</param>
    ''' <param name="bAll">Sử dụng Tất cả. Mặc định True</param>
    ''' <remarks>LoadtdbcWareHouseID(New C1.Win.C1List.C1Combo() {tdbcWareHouseIDFrom, tdbcWareHouseIDTo})</remarks>
    Public Sub LoadtdbcWareHouseID(ByVal tdbc() As C1.Win.C1List.C1Combo, ByVal bTransaction As Boolean, Optional ByVal bAll As Boolean = True)
        Dim dtWareHouse As DataTable = ReturnTableWareHouseID(bAll, " DivisionID = " & SQLString(gsDivisionID) & IIf(bTransaction, " And Disabled = 0", "").ToString)

        For i As Integer = 0 To tdbc.Length - 1
            LoadDataSource(tdbc(i), dtWareHouse.DefaultView.ToTable, gbUnicode)
            If bAll Then tdbc(i).SelectedIndex = 0
        Next
    End Sub
#End Region

#Region "Đổ nguồn Dự án và Hạng mục"
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD54P9000
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 20/09/2012 10:33:32
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD54P9000() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon du an va hang muc" & vbCrLf)
        sSQL &= "Exec D54P9000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Public Function ReturnTableProject_TaskID() As DataTable
        Return ReturnDataTable(SQLStoreD54P9000)
    End Function

    Public Sub LoadProject(ByVal ctrlProject As Control, Optional ByRef dtSource As DataTable = Nothing)
        If dtSource Is Nothing Then dtSource = ReturnDataTable(SQLStoreD54P9000)
        Dim dtProject As DataTable = Nothing
        If dtSource.Rows.Count > 0 Then
            dtProject = dtSource.DefaultView.ToTable(True, New String() {"ProjectID", "ProjectName"})
        Else
            dtProject = dtSource
        End If
        If TypeOf (ctrlProject) Is C1.Win.C1List.C1Combo Then
            LoadDataSource(CType(ctrlProject, C1.Win.C1List.C1Combo), dtProject, gbUnicode)
        ElseIf TypeOf (ctrlProject) Is C1.Win.C1TrueDBGrid.C1TrueDBDropdown Then
            LoadDataSource(CType(ctrlProject, C1.Win.C1TrueDBGrid.C1TrueDBDropdown), dtProject, gbUnicode)
        End If
    End Sub

    Public Sub LoadTask(ByVal ctrlTask As Control, Optional ByRef dtSource As DataTable = Nothing, Optional ByVal sProjectID As String = "%")
        If dtSource Is Nothing Then dtSource = ReturnDataTable(SQLStoreD54P9000)
        Dim dtTaskID As DataTable = Nothing
        If sProjectID = "%" Then
            dtTaskID = dtSource
        Else
            Dim sFilter As String = "ProjectID=" & SQLString(sProjectID)
            dtTaskID = ReturnTableFilter(dtSource, sFilter, True)
        End If
        If TypeOf (ctrlTask) Is C1.Win.C1List.C1Combo Then
            LoadDataSource(CType(ctrlTask, C1.Win.C1List.C1Combo), dtTaskID, gbUnicode)
        ElseIf TypeOf (ctrlTask) Is C1.Win.C1TrueDBGrid.C1TrueDBDropdown Then
            LoadDataSource(CType(ctrlTask, C1.Win.C1TrueDBGrid.C1TrueDBDropdown), dtTaskID, gbUnicode)
        End If
    End Sub
#End Region

#Region "Đổ nguồn cho Mã XDCB"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P9000
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 13/11/2012 02:52:06
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P9000() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon XDCB" & vbCrlf)
        sSQL &= "Exec D02P9000 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Public Function ReturnTableCIP() As DataTable
        Return ReturnDataTable(SQLStoreD02P9000)
    End Function

    'Update 13/11/2012 by Lê Phương
    Public Sub LoadCIP(ByVal ctrlCIP As Control, Optional ByRef dtCIP As DataTable = Nothing)
        If dtCIP Is Nothing Then dtCIP = ReturnTableCIP()
        If TypeOf (ctrlCIP) Is C1.Win.C1List.C1Combo Then
            LoadDataSource(CType(ctrlCIP, C1.Win.C1List.C1Combo), dtCIP, gbUnicode)
        ElseIf TypeOf (ctrlCIP) Is C1.Win.C1TrueDBGrid.C1TrueDBDropdown Then
            LoadDataSource(CType(ctrlCIP, C1.Win.C1TrueDBGrid.C1TrueDBDropdown), dtCIP, gbUnicode)
        End If
    End Sub

#End Region

End Module
