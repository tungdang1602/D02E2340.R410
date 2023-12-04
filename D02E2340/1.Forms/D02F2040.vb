Imports System.Windows.Forms
Public Class D02F2040

#Region "Const of tdbg"
    Private Const COL_IsSelect As Integer = 0          ' Chọn
    Private Const COL_AssetID As Integer = 1           ' Mã tài sản
    Private Const COL_AssetName As Integer = 2         ' Tên tài sản
    Private Const COL_ConvertedAmount As Integer = 3   ' Nguyên giá
    Private Const COL_DepAmount As Integer = 4         ' Hao mòn lũy kế
    Private Const COL_RemainAmount As Integer = 5      ' Giá trị còn lại
    Private Const COL_AssetAccountID As Integer = 6    ' TK tài sản
    Private Const COL_DepAccountID As Integer = 7      ' Tk khấu hao
    Private Const COL_ASeriNo As Integer = 8           ' Số Sêri
    Private Const COL_ARefNo As Integer = 9            ' Số hóa đơn
    Private Const COL_ARefDate As Integer = 10         ' Ngày hóa đơn
    Private Const COL_ANotes As Integer = 11           ' Diễn giải
    Private Const COL_AObjectTypeID As Integer = 12    ' Loại ĐT
    Private Const COL_AObjectID As Integer = 13        ' Đối tượng
    Private Const COL_ACurrencyID As Integer = 14      ' Loại tiền
    Private Const COL_ADecimalPlaces As Integer = 15   ' ADecimalPlaces
    Private Const COL_AOperator As Integer = 16        ' AOperator
    Private Const COL_AExchangeRate As Integer = 17    ' Tỷ giá
    Private Const COL_ADebitAccountID As Integer = 18  ' TK nợ
    Private Const COL_ACreditAccountID As Integer = 19 ' TK có
    Private Const COL_AOriginalAmount As Integer = 20  ' Nguyên tệ
    Private Const COL_AConvertedAmount As Integer = 21 ' Quy đổi
    Private Const COL_InventoryID As Integer = 22      ' Mã hàng
    Private Const COL_InventoryName As Integer = 23    ' Tên hàng
    Private Const COL_UnitID As Integer = 24           ' ĐVT
    Private Const COL_AAna01ID As Integer = 25         ' AAna01ID
    Private Const COL_AAna02ID As Integer = 26         ' AAna02ID
    Private Const COL_AAna03ID As Integer = 27         ' AAna03ID
    Private Const COL_AAna04ID As Integer = 28         ' AAna04ID
    Private Const COL_AAna05ID As Integer = 29         ' AAna05ID
    Private Const COL_AAna06ID As Integer = 30         ' AAna06ID
    Private Const COL_AAna07ID As Integer = 31         ' AAna07ID
    Private Const COL_AAna08ID As Integer = 32         ' AAna08ID
    Private Const COL_AAna09ID As Integer = 33         ' AAna09ID
    Private Const COL_AAna10ID As Integer = 34         ' AAna10ID
    Private Const COL_DSeriNo As Integer = 35          ' DSeriNo
    Private Const COL_DRefNo As Integer = 36           ' DRefNo
    Private Const COL_DRefDate As Integer = 37         ' DRefDate
    Private Const COL_DNotes As Integer = 38           ' DNotes
    Private Const COL_DObjectTypeID As Integer = 39    ' DObjectTypeID
    Private Const COL_DObjectID As Integer = 40        ' DObjectID
    Private Const COL_DCurrencyID As Integer = 41      ' DCurrencyID
    Private Const COL_DDecimalPlaces As Integer = 42   ' DDecimalPlaces
    Private Const COL_DOperator As Integer = 43        ' DOperator
    Private Const COL_DExchangeRate As Integer = 44    ' DExchangeRate
    Private Const COL_DDebitAccountID As Integer = 45  ' DDebitAccountID
    Private Const COL_DCreditAccountID As Integer = 46 ' DCreditAccountID
    Private Const COL_DOriginalAmount As Integer = 47  ' DOriginalAmount
    Private Const COL_DConvertedAmount As Integer = 48 ' DConvertedAmount
    Private Const COL_DAna01ID As Integer = 49         ' DAna01ID
    Private Const COL_DAna02ID As Integer = 50         ' DAna02ID
    Private Const COL_DAna03ID As Integer = 51         ' DAna03ID
    Private Const COL_DAna04ID As Integer = 52         ' DAna04ID
    Private Const COL_DAna05ID As Integer = 53         ' DAna05ID
    Private Const COL_DAna06ID As Integer = 54         ' DAna06ID
    Private Const COL_DAna07ID As Integer = 55         ' DAna07ID
    Private Const COL_DAna08ID As Integer = 56         ' DAna08ID
    Private Const COL_DAna09ID As Integer = 57         ' DAna09ID
    Private Const COL_DAna10ID As Integer = 58         ' DAna10ID
#End Region

    Private dtGrid As DataTable

    Private Sub D02F2040_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ExecuteSQLNoTransaction(SQLDeleteD02T5012)
    End Sub

    Private Sub D02F2040_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        Dim dtAnaCaption As DataTable = Nothing
        Dim bUseAnaA As Boolean = LoadTDBGridAnalysisCaption(D02, tdbg, COL_AAna01ID, SPLIT2, , gbUnicode, dtAnaCaption)
        Dim bUseAnaD As Boolean = LoadTDBGridAnalysisCaption(D02, tdbg, COL_DAna01ID, SPLIT2, , gbUnicode, dtAnaCaption)

        optTransferMode0.Checked = True
        InputC1NumbericTDBGrid()
        tdbg_LockedColumns()
        SetBackColorObligatory()
        ResetFooterGrid(tdbg, 0, tdbg.Splits.Count - 1)
        InputDateInTrueDBGrid(tdbg, COL_ARefDate, COL_DRefDate)

        LoadTDBCombo()
        LoadTDBDropDown()
        LoadDefault()

        LoadLanguage()
        CheckIdTextBox(txtVoucherNo)
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D02F2040_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1 Then
                If btnAssetAccount.Enabled Then btnAssetAccount_Click(Nothing, Nothing)
            ElseIf e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2 Then
                If btnDepAccount.Enabled Then btnAccount_Click(Nothing, Nothing)
            End If
        Else
            Select Case e.KeyCode
                Case Keys.Enter
                    UseEnterAsTab(Me, True)
                Case Keys.F11
                    HotKeyF11(Me, tdbg)
                Case Keys.F5
                    btnFilter_Click(Nothing, Nothing)
            End Select
        End If
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rl3("Chuyen_doi_TSCDF") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'ChuyÓn ¢åi TSC˜
        '================================================================ 
        lblFromAssetID.Text = rl3("Tai_san") 'Tài sản
        lblCAmountFrom.Text = rl3("Nguyen_gia") 'Nguyên giá
        lblChangeNo.Text = rl3("Nghiep_vu") 'Nghiệp vụ
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblChangeDate.Text = rl3("Ngay_tac_dong") 'Ngày tác động
        lblNotes.Text = rl3("Ghi_chu") 'Ghi chú
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        '================================================================ 
        btnFilter.Text = rl3("Loc") & "  (F5)" 'Lọc
        btnAssetAccount.Text = "1. " & rl3("TK_tai_san") '1. TK tài sản
        btnDepAccount.Text = "2. " & rl3("TK_khau_haoU")  '2. TK khấu hao
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        '================================================================ 
        chkShowSelected.Text = rl3("Chi_hien_thi_nhung_dong_da_chon") 'Chỉ hiển thị những dòng đã chọn
        chkShowZero.Text = rl3("Hien_thi_TS_co_gia_tri_con_lai_bang_0")
        '================================================================ 
        optTransferMode1.Text = rl3("Chuyen_sang_Cong_cu_dung_cu") 'Chuyển sang Công cụ dụng cụ
        optTransferMode0.Text = rl3("Chuyen_sang_Chi_phi_tra_truoc") 'Chuyển sang Chi phí trả trước
        '================================================================ 
        grpInfo.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        grpFilter.Text = rl3("Dieu_kien_loc") 'Điều kiện lọc
        grpInfo.Text = rl3("Thong_tin_phieu") 'Thông tin phiếu
        '================================================================ 
        tdbcToAssetID.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcToAssetID.Columns("AssetName").Caption = rl3("Ten") 'Tên
        tdbcFromAssetID.Columns("AssetID").Caption = rl3("Ma") 'Mã
        tdbcFromAssetID.Columns("AssetName").Caption = rl3("Ten") 'Tên
        tdbcChangeNo.Columns("ChangeNo").Caption = rl3("Ma") 'Mã
        tdbcChangeNo.Columns("ChangeName").Caption = rl3("Ten") 'Tên
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdInventoryID.Columns("InventoryID").Caption = rl3("Ma") 'Mã
        tdbdInventoryID.Columns("InventoryName").Caption = rl3("Ten") 'Tên
        tdbdInventoryID.Columns("UnitID").Caption = rl3("DVT") 'ĐVT
        tdbdObjectID.Columns("ObjectID").Caption = rl3("Ma") 'Mã
        tdbdObjectID.Columns("ObjectName").Caption = rl3("Ten") 'Tên
        tdbdObjectTypeID.Columns("ObjectTypeID").Caption = rl3("Ma") 'Mã
        tdbdObjectTypeID.Columns("ObjectTypeName").Caption = rl3("Ten") 'Tên
        tdbdCurrencyID.Columns("CurrencyID").Caption = rl3("Ma") 'Mã
        tdbdCurrencyID.Columns("CurrencyName").Caption = rl3("Ten") 'Tên
        tdbdCreditAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdCreditAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbdDebitAccountID.Columns("AccountID").Caption = rl3("Ma") 'Mã
        tdbdDebitAccountID.Columns("AccountName").Caption = rl3("Ten") 'Tên
        tdbdAna01ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna01ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna02ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna02ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna03ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna03ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna04ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna04ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna05ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna05ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna06ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna06ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna07ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna07ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna08ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna08ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna09ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna09ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdAna10ID.Columns("AnaID").Caption = rl3("Ma") 'Mã
        tdbdAna10ID.Columns("AnaName").Caption = rl3("Ten") 'Tên
        tdbdUnitID.Columns("UnitID").Caption = rl3("Ma") 'Mã
        tdbdUnitID.Columns("UnitName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns(COL_IsSelect).Caption = rl3("Chon") 'Chọn
        tdbg.Columns(COL_AssetID).Caption = rl3("Ma_tai_san") 'Mã tài sản
        tdbg.Columns(COL_AssetName).Caption = rl3("Ten_tai_san") 'Tên tài sản
        tdbg.Columns(COL_ConvertedAmount).Caption = rl3("Nguyen_gia") 'Nguyên giá
        tdbg.Columns(COL_DepAmount).Caption = rl3("Hao_mon_luy_ke") 'Hao mòn lũy kế
        tdbg.Columns(COL_RemainAmount).Caption = rl3("Gia_tri_con_lai") 'Giá trị còn lại
        tdbg.Columns(COL_AssetAccountID).Caption = rl3("TK_tai_san") ' TK tài sản
        tdbg.Columns(COL_DepAccountID).Caption = rl3("TK_khau_haoU")  ' TK khấu hao
        tdbg.Columns(COL_ASeriNo).Caption = rl3("So_Seri") 'Số Sêri
        tdbg.Columns(COL_ARefNo).Caption = rl3("So_hoa_don") 'Số hóa đơn
        tdbg.Columns(COL_ARefDate).Caption = rl3("Ngay_hoa_don") 'Ngày hóa đơn
        tdbg.Columns(COL_ANotes).Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_AObjectTypeID).Caption = rl3("Loai_DT") 'Loại ĐT
        tdbg.Columns(COL_AObjectID).Caption = rl3("Doi_tuong") 'Đối tượng
        tdbg.Columns(COL_ACurrencyID).Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_AExchangeRate).Caption = rl3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_ADebitAccountID).Caption = rl3("TK_no") 'TK nợ
        tdbg.Columns(COL_ACreditAccountID).Caption = rl3("TK_co") 'TK có
        tdbg.Columns(COL_AOriginalAmount).Caption = rl3("Nguyen_te") 'Nguyên tệ
        tdbg.Columns(COL_AConvertedAmount).Caption = rl3("Quy_doi") 'Quy đổi
        tdbg.Columns(COL_DSeriNo).Caption = rl3("So_Seri") 'Số Sêri
        tdbg.Columns(COL_DRefNo).Caption = rl3("So_hoa_don") 'Số hóa đơn
        tdbg.Columns(COL_DRefDate).Caption = rl3("Ngay_hoa_don") 'Ngày hóa đơn
        tdbg.Columns(COL_DNotes).Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns(COL_DObjectTypeID).Caption = rl3("Loai_DT") 'Loại ĐT
        tdbg.Columns(COL_DObjectID).Caption = rl3("Doi_tuong") 'Đối tượng
        tdbg.Columns(COL_DCurrencyID).Caption = rl3("Loai_tien") 'Loại tiền
        tdbg.Columns(COL_DExchangeRate).Caption = rl3("Ty_gia") 'Tỷ giá
        tdbg.Columns(COL_DDebitAccountID).Caption = rl3("TK_no") 'TK nợ
        tdbg.Columns(COL_DCreditAccountID).Caption = rl3("TK_co") 'TK có
        tdbg.Columns(COL_DOriginalAmount).Caption = rl3("Nguyen_te") 'Nguyên tệ
        tdbg.Columns(COL_DConvertedAmount).Caption = rl3("Quy_doi") 'Quy đổi
        tdbg.Columns(COL_InventoryID).Caption = rl3("Ma_hang") 'Mã hàng
        tdbg.Columns(COL_InventoryName).Caption = rl3("Ten_hang_") 'Tên hàng
        tdbg.Columns(COL_UnitID).Caption = rl3("DVT") 'ĐVT
    End Sub

    Private Sub LoadDefault()
        c1dateChangeDate.Value = Now.Date
        c1dateVoucherDate.Value = Now.Date
        tdbcFromAssetID.SelectedValue = "%"
        tdbcToAssetID.SelectedValue = "%"
        ClickButton(Button.AssetAccount)
        btnSave.Enabled = (gbClosed = False) '28/4/2017, id 96484-Lỗi khóa sổ vẫn sáng menu thêm sửa xóa D02

        For i As Integer = 0 To dtVoucherTypeID.Rows.Count - 1
            If dtVoucherTypeID.Rows(i).Item("FormID").ToString = "D02F2040" Then
                Dim sFormID As String = dtVoucherTypeID.Rows(i).Item("VoucherTypeID").ToString
                tdbcVoucherTypeID.Text = sFormID
                Exit Sub
            End If
        Next
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcFromAssetID
        sSQL = "SELECT 		'%' AS AssetID, " & AllName & " As AssetName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "UNION ALL " & vbCrLf
        sSQL &= "SELECT 	Distinct N19.AssetID, N19.AssetName" & UnicodeJoin(gbUnicode) & " As AssetName, T01.AssignmentTypeID" & vbCrLf
        sSQL &= "FROM       D02N0019(" & giTranMonth & ", " & giTranYear & ") as N19 Left join D02T0001 as T01 WITH(NOLOCK) on T01.AssetID = N19.AssetID " & vbCrLf
        sSQL &= "WHERE 		N19.IsCompleted = 1 AND N19.Disabled = 0 " & vbCrLf
        sSQL &= "           AND N19.DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "           AND N19.TranMonth + N19.TranYear * 100 <= " & giTranMonth & " + " & giTranYear & " *100" & vbCrLf
        sSQL &= "           AND (N19.IsLiquidated = 0 )" & vbCrLf
        sSQL &= "ORDER BY   AssetID" & vbCrLf

        Dim dtAssetID As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(tdbcFromAssetID, dtAssetID, gbUnicode)
        LoadDataSource(tdbcToAssetID, dtAssetID.DefaultView.ToTable, gbUnicode)

        'Load tdbcChangeNo
        sSQL = "SELECT  DISTINCT T1.ChangeNo, T1.ChangeName" & UnicodeJoin(gbUnicode) & " As ChangeName, " & vbCrLf
        sSQL &= "           T1.Notes1" & UnicodeJoin(gbUnicode) & " As Notes, T2.VoucherTypeID " & vbCrLf
        sSQL &= "FROM       D02T0201 T1 WITH(NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN	D02T0204 T2 WITH(NOLOCK) ON T1.ChangeNo = T2.ChangeNo" & vbCrLf
        sSQL &= "WHERE 		IsEliminated = 1 AND [Disabled] = 0 AND UseAccount = 1"
        LoadDataSource(tdbcChangeNo, sSQL, gbUnicode)

        'Load tdbcVoucherTypeID
        dtVoucherTypeID = ReturnDataTable(ReturnTableVoucherTypeID("D02", gsDivisionID, "", gbUnicode))
        LoadDataSource(tdbcVoucherTypeID, dtVoucherTypeID, gbUnicode)
        'LoadVoucherTypeID(tdbcVoucherTypeID, "D02", , gbUnicode)
    End Sub
    Public Function ReturnTableVoucherTypeID(ByVal sModuleID As String, ByVal DivisionID As String, ByVal sEditTransTypeID As String, Optional ByVal bUseUnicode As Boolean = False) As String
        Dim sSQL As String = "--Do nguon cho combo loai phieu" & vbCrLf
        sSQL &= "Select T01.VoucherTypeID, " & IIf(bUseUnicode, "VoucherTypeNameU", "VoucherTypeName").ToString & " as VoucherTypeName, Auto, S1Type, S1, S2Type, S2, " & vbCrLf
        sSQL &= "S3, S3Type, OutputOrder, OutputLength, Separator, T40.FormID " & vbCrLf
        sSQL &= "From D91T0001 T01 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Left Join D02T0080 T40 WITH(NOLOCK) ON T01.VoucherTypeID = T40.VoucherTypeID" & vbCrLf
        sSQL &= "Where Use" & sModuleID & " = 1 And Disabled = 0 " & vbCrLf
        If DivisionID <> "" Then sSQL &= "AND( VoucherDivisionID='' Or VoucherDivisionID = " & SQLString(DivisionID) & ") " & vbCrLf
        'Load cho trường hợp Sửa, Xem
        If sEditTransTypeID <> "" Then
            sSQL &= "Or T01.VoucherTypeID = " & SQLString(sEditTransTypeID) & vbCrLf
        End If
        sSQL &= "Order By VoucherTypeID"
        Return sSQL
    End Function
    Dim dtObjectID As DataTable
    Dim dtAccountID As DataTable
    Dim dtVoucherTypeID As DataTable
    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdInventoryID
        'sSQL = "--Do nguon dropdown ma hang" & vbCrLf
        'sSQL &= "SELECT InventoryID, InventoryName" & UnicodeJoin(gbUnicode) & " As InventoryName, UnitID" & vbCrLf
        'sSQL &= "FROM 	D07T0002 WITH(NOLOCK)  " & vbCrLf
        'sSQL &= "WHERE 	IsService = 0 AND Disabled = 0 AND InventoryTypeID  =  'CC' " & vbCrLf
        'sSQL &= "ORDER  BY InventoryID  "
        '05/05/2017, Trần Hoàng Anh: id 96897-Sửa câu đổ nguồn mã CCDC thành store
        LoadDataSource(tdbdInventoryID, SQLStoreD02P2120, gbUnicode)

        'Load tdbdObjectID
        sSQL = "Select     ObjectID, ObjectName" & UnicodeJoin(gbUnicode) & " As ObjectName, ObjectTypeID " & vbCrLf
        sSQL &= "From       Object WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where      Disabled = 0 " & vbCrLf
        sSQL &= "Order By   ObjectID " & vbCrLf
        dtObjectID = ReturnDataTable(sSQL.ToString)
        'Load tdbdObjectTypeID
        LoadObjectTypeID(tdbdObjectTypeID, gbUnicode)
        'Load tdbdObjectID
        LoadtdbdObjectID("-1")

        'Load tdbdCurrencyID
        LoadCurrencyID(tdbdCurrencyID, gbUnicode)

        'Load tdbdDebitAccountID, tdbdCreditAccountID
        sSQL = "SELECT     AccountID,  AccountName" & UnicodeJoin(gbUnicode) & " As AccountName ,GroupID" & vbCrLf
        sSQL &= "FROM       D90T0001 WITH(NOLOCK)" & vbCrLf
        sSQL &= "WHERE      Disabled = 0 And AccountStatus = 0 AND OffAccount = 0" & vbCrLf
        sSQL &= "ORDER BY   AccountID" & vbCrLf
        dtAccountID = ReturnDataTable(sSQL)
        '  LoadDataSource(tdbdDebitAccountID, dtAccountID, gbUnicode)
        LoadDataSource(tdbdCreditAccountID, dtAccountID.DefaultView.ToTable, gbUnicode)

        sSQL = "--Do nguon dropdown Don vi tinh" & vbCrLf
        sSQL &= "SELECT 	UnitID, UnitName" & UnicodeJoin(gbUnicode) & "  as UnitName, DefaultOQty "
        sSQL &= "FROM D07T0005 WITH(NOLOCK) "
        sSQL &= "WHERE Disabled = 0 "
        sSQL &= "ORDER BY  UnitID"
        LoadDataSource(tdbdUnitID, sSQL, gbUnicode)

        LoadTDBDropDownAna(tdbdAna01ID, tdbdAna02ID, tdbdAna03ID, tdbdAna04ID, tdbdAna05ID, tdbdAna06ID, tdbdAna07ID, tdbdAna08ID, tdbdAna09ID, tdbdAna10ID, tdbg, COL_AAna01ID, gbUnicode)
    End Sub

    Private Sub LoadtdbdObjectID(ByVal ID As String)
        LoadDataSource(tdbdObjectID, ReturnTableFilter(dtObjectID, " ObjectTypeID = " & SQLString(ID), True), gbUnicode)
    End Sub

    Private Sub LoadtdbdDebitAccountID(Optional ByVal iTransferMode As Integer = -1)
        If iTransferMode = -1 Then
            LoadDataSource(tdbdDebitAccountID, dtAccountID.DefaultView.ToTable, gbUnicode)
        ElseIf iTransferMode = 0 Then
            LoadDataSource(tdbdDebitAccountID, ReturnTableFilter(dtAccountID, " GroupID = '20'", True), gbUnicode)
        ElseIf iTransferMode = 1 Then
            LoadDataSource(tdbdDebitAccountID, ReturnTableFilter(dtAccountID, " GroupID = '21'", True), gbUnicode)
        End If
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD02P2040()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        dtGrid.AcceptChanges()
        Dim sFilter As String = ""
        If chkShowSelected.Checked Then
            sFilter = "IsSelect=True"
        End If
        dtGrid.DefaultView.RowFilter = sFilter
        ResetGrid()
    End Sub

    Private Sub ResetGrid()
        FooterTotalGrid(tdbg, COL_AssetID)
        SUMFooter()
    End Sub

    Private Sub SUMFooter()
        FooterSumNew(tdbg, COL_ConvertedAmount, COL_DepAmount, COL_RemainAmount, COL_AOriginalAmount, COL_AConvertedAmount, COL_DOriginalAmount, COL_DConvertedAmount)
    End Sub

    Private Sub optTransferMode0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTransferMode0.CheckedChanged
        If optTransferMode0.Checked Then
            tdbg.Splits(2).DisplayColumns(COL_InventoryID).Locked = True
            tdbg.Splits(2).DisplayColumns(COL_UnitID).Locked = True
            tdbg.Splits(SPLIT2).DisplayColumns(COL_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT2).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        Else
            tdbg.Splits(2).DisplayColumns(COL_InventoryID).Locked = False
            tdbg.Splits(2).DisplayColumns(COL_UnitID).Locked = False
            tdbg.Splits(SPLIT2).DisplayColumns(COL_InventoryID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
            tdbg.Splits(SPLIT2).DisplayColumns(COL_UnitID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        End If
        If dtGrid Is Nothing Then Exit Sub
        btnFilter_Click(Nothing, Nothing)
        '        If dtGrid Is Nothing Then Exit Sub
        '        If optTransferMode1.Checked Then
        '            For i As Integer = 0 To tdbg.RowCount - 1
        '                tdbg(i, COL_ADebitAccountID) = ""
        '            Next
        '        End If
    End Sub

    Private Sub chkShowSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowSelected.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Sub chkShowZero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowZero.CheckedChanged
        If dtGrid Is Nothing Then Exit Sub
        ReLoadTDBGrid()
    End Sub

    Private Function AllowFilter() As Boolean
        If tdbcFromAssetID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tai_san"))
            tdbcFromAssetID.Focus()
            Return False
        End If
        If tdbcToAssetID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tai_san"))
            tdbcToAssetID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        If sender IsNot Nothing Then
            btnFilter.Focus()
            If btnFilter.Focused = False Then Exit Sub
        End If
        If Not AllowFilter() Then Exit Sub
        chkShowSelected.Checked = False
        Me.Cursor = Cursors.WaitCursor

        LoadTDBGrid()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        Dim dr() As DataRow = Nothing
        If Not AllowSave(dr) Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không
        'If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Text) Then c1dateVoucherDate.Focus() : Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL() As StringBuilder = Nothing
        sSQL = SQLInsertD02T5012Assets(dr)
        Dim sSQL1() As StringBuilder = SQLInsertD02T5012Deps(dr)
        If sSQL1 IsNot Nothing Then
            For i As Integer = 0 To sSQL1.Length - 1
                sSQL = AddValueInArrStringBuilder(sSQL, sSQL1(i).ToString, , True)
            Next
        End If
        sSQL = AddValueInArrStringBuilder(sSQL, SQLDeleteD02T5012() & vbCrLf, False)
        sSQL = AddValueInArrStringBuilder(sSQL, SQLStoreD02P2045, , True)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If

    End Sub

    Private Sub txtCAmountFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAmountFrom.KeyPress, txtCAmountTo.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
    End Sub

    Private Sub txtCAmountFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAmountFrom.LostFocus
        txtCAmountFrom.Text = SQLNumber(txtCAmountFrom.Text, DxxFormat.DefaultNumber2)
    End Sub

    Private Sub txtCAmountTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAmountTo.LostFocus
        txtCAmountTo.Text = SQLNumber(txtCAmountTo.Text, DxxFormat.DefaultNumber2)
    End Sub

#Region "Events tdbcFromAssetID"

    Private Sub tdbcFromAssetID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcFromAssetID.LostFocus
        If tdbcFromAssetID.FindStringExact(tdbcFromAssetID.Text) = -1 Then tdbcFromAssetID.Text = ""
    End Sub

#End Region

#Region "Events tdbcToAssetID"

    Private Sub tdbcToAssetID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcToAssetID.LostFocus
        If tdbcToAssetID.FindStringExact(tdbcToAssetID.Text) = -1 Then tdbcToAssetID.Text = ""
    End Sub

#End Region

#Region "Events tdbcChangeNo with txtNotes"

    Private Sub tdbcChangeNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcChangeNo.SelectedValueChanged
        If tdbcChangeNo.SelectedValue Is Nothing Then
            txtNotes.Text = ""
            tdbcVoucherTypeID.SelectedValue = ""
        Else
            txtNotes.Text = ReturnValueC1Combo(tdbcChangeNo, "Notes").ToString
            tdbcVoucherTypeID.SelectedValue = ReturnValueC1Combo(tdbcChangeNo, "VoucherTypeID").ToString
        End If

    End Sub

    Private Sub tdbcChangeNo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcChangeNo.LostFocus
        If tdbcChangeNo.FindStringExact(tdbcChangeNo.Text) = -1 Then
            tdbcChangeNo.Text = ""
        End If
        btnFilter_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "Events tdbcVoucherTypeID"

    '    Private Sub tdbcVoucherTypeID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.LostFocus
    '        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then tdbcVoucherTypeID.Text = ""
    '    End Sub

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        If tdbcVoucherTypeID.SelectedValue Is Nothing OrElse tdbcVoucherTypeID.Text = "" Then
            txtVoucherNo.Text = ""
            ReadOnlyControl(txtVoucherNo)
            Exit Sub
        End If

        If tdbcVoucherTypeID.Columns("Auto").Text = "1" Then 'Sinh tự động
            txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
            ReadOnlyControl(txtVoucherNo)
        Else 'Không sinh tự động
            txtVoucherNo.Text = ""
            UnReadOnlyControl(txtVoucherNo, True)
        End If

    End Sub


#End Region

    Private Sub btnAssetAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetAccount.Click
        ClickButton(Button.AssetAccount)
        tdbg.Focus()
        tdbg.SplitIndex = 2
        tdbg.Col = COL_ASeriNo
    End Sub

    Private Sub btnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepAccount.Click
        ClickButton(Button.DepAccount)
        tdbg.Focus()
        tdbg.SplitIndex = 2
        tdbg.Col = COL_DSeriNo
    End Sub

    Private Sub ClickButton(ByVal but As Button)
        btnAssetAccount.Enabled = Math.Abs(but - Button.AssetAccount) > 0
        btnDepAccount.Enabled = Math.Abs(but - Button.DepAccount) > 0

        '1.
        For i As Integer = COL_ASeriNo To COL_UnitID
            tdbg.Splits(SPLIT2).DisplayColumns(i).Visible = Math.Abs(but - Button.AssetAccount) = 0
        Next
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AOperator).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ADecimalPlaces).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna01ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna01ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna02ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna02ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna03ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna03ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna04ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna04ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna05ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna05ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna06ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna06ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna07ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna07ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna08ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna08ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna09ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna09ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AAna10ID).Visible = Math.Abs(but - Button.AssetAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_AAna10ID).Tag)

        '2.
        For i As Integer = COL_DSeriNo To COL_DConvertedAmount
            tdbg.Splits(SPLIT2).DisplayColumns(i).Visible = Math.Abs(but - Button.DepAccount) = 0
        Next
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DOperator).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DDecimalPlaces).Visible = False
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna01ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna01ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna02ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna02ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna03ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna03ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna04ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna04ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna05ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna05ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna06ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna06ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna07ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna07ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna08ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna08ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna09ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna09ID).Tag)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DAna10ID).Visible = Math.Abs(but - Button.DepAccount) = 0 And Convert.ToBoolean(tdbg.Columns(COL_DAna10ID).Tag)
    End Sub

#Region "tdbg event"
    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub


    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_ConvertedAmount, COL_DepAmount, COL_RemainAmount, COL_AExchangeRate, COL_AOriginalAmount, COL_AConvertedAmount
                If Not L3IsNumeric(tdbg.Columns(e.ColIndex).Text, EnumDataType.Number) Then e.Cancel = True
            Case COL_AObjectTypeID, COL_AObjectID, COL_ADebitAccountID, COL_ACreditAccountID, COL_ACurrencyID, COL_DObjectTypeID, COL_DObjectID, COL_DCurrencyID, COL_DDebitAccountID, COL_DCreditAccountID, COL_UnitID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_ASeriNo, COL_ARefNo, COL_DSeriNo, COL_DRefNo, COL_InventoryID
                e.Cancel = L3IsID(tdbg, e.ColIndex)
            Case COL_AAna01ID, COL_AAna02ID, COL_AAna03ID, COL_AAna04ID, COL_AAna05ID, COL_AAna06ID, COL_AAna07ID, COL_AAna08ID, COL_AAna09ID, COL_AAna10ID, COL_DAna01ID, COL_DAna02ID, COL_DAna03ID, COL_DAna04ID, COL_DAna05ID, COL_DAna06ID, COL_DAna07ID, COL_DAna08ID, COL_DAna09ID, COL_DAna10ID
                If Not CheckDropdownInList(tdbg.Columns(e.ColIndex).DropDown, tdbg.Columns(e.ColIndex).Value.ToString) Then
                    Dim index As Integer = L3Int(tdbg.Columns(e.ColIndex).DataField.Substring(4, 2))
                    If gbArrAnaValidate(index) Then 'Kiểm tra nhập trong danh sách
                        tdbg.Columns(e.ColIndex).Text = ""
                    Else
                        If tdbg.Columns(e.ColIndex).Text.Length > giArrAnaLength(index) Then ' Kiểm tra chiều dài nhập vào
                            tdbg.Columns(e.ColIndex).Text = ""
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub SetEmptyValue(ByVal iRow As Integer)
        For i As Integer = COL_ASeriNo To tdbg.Columns.Count - 1
            tdbg(iRow, i) = ""
        Next

    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_AObjectTypeID
                tdbg.Columns(COL_AObjectID).Text = ""

            Case COL_ACurrencyID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_ACurrencyID).Text = ""
                    tdbg.Columns(COL_AExchangeRate).Text = ""
                    tdbg.Columns(COL_ADecimalPlaces).Text = ""
                Else
                    tdbg.Columns(COL_ACurrencyID).Text = tdbdCurrencyID.Columns("CurrencyID").Text
                    tdbg.Columns(COL_AExchangeRate).Text = tdbdCurrencyID.Columns("ExchangeRate").Text
                    tdbg.Columns(COL_AOperator).Text = tdbdCurrencyID.Columns("Operator").Text
                    tdbg.Columns(COL_ADecimalPlaces).Text = tdbdCurrencyID.Columns("DecimalPlaces").Text
                End If
                'Cập nhât lại tỷ gia,  Quy đổi
                If tdbg.Columns(COL_ACurrencyID).ToString <> "" Then
                    If IsNumeric(tdbg.Columns(COL_AOriginalAmount).Text) Then
                        If tdbg.Columns(COL_AExchangeRate).Text <> "" Then 'Ty gia khac rong
                            tdbg.Columns(COL_AConvertedAmount).Value = CalCAmount(L3Int(tdbg.Columns(COL_AOperator).Text), Number(SQLMoney(tdbg.Columns(COL_AExchangeRate).Text, DxxFormat.ExchangeRateDecimals)), Number(SQLMoney(tdbg.Columns(COL_AOriginalAmount).Text, InsertFormat(L3Int(tdbg.Columns(COL_ADecimalPlaces).Value))))).ToString
                        Else
                            tdbg.Columns(COL_AConvertedAmount).Value = 0
                        End If
                    End If
                    SUMFooter()
                End If
            Case COL_AOriginalAmount
                'Cập nhât lại tỷ gia,  Quy đổi
                If tdbg.Columns(COL_ACurrencyID).ToString <> "" Then
                    If IsNumeric(tdbg.Columns(COL_AOriginalAmount).Text) Then
                        If tdbg.Columns(COL_AExchangeRate).Text <> "" Then 'Ty gia khac rong
                            tdbg.Columns(COL_AConvertedAmount).Value = CalCAmount(L3Int(tdbg.Columns(COL_AOperator).Text), Number(SQLMoney(tdbg.Columns(COL_AExchangeRate).Text, DxxFormat.ExchangeRateDecimals)), Number(SQLMoney(tdbg.Columns(COL_AOriginalAmount).Text, InsertFormat(L3Int(tdbg.Columns(COL_ADecimalPlaces).Value))))).ToString
                        Else
                            tdbg.Columns(COL_AConvertedAmount).Value = 0
                        End If
                    End If
                    SUMFooter()
                End If
            Case COL_AConvertedAmount
                'Cập nhât lại tỷ gia,  Quy đổi
                If tdbg.Columns(COL_ACurrencyID).ToString <> "" Then
                    If IsNumeric(tdbg.Columns(COL_AOriginalAmount).Text) Then
                        If tdbg.Columns(COL_AExchangeRate).Text <> "" Then 'Ty gia khac rong
                            tdbg.Columns(COL_AConvertedAmount).Value = CalCAmount(L3Int(tdbg.Columns(COL_AOperator).Text), Number(SQLMoney(tdbg.Columns(COL_AExchangeRate).Text, DxxFormat.ExchangeRateDecimals)), Number(SQLMoney(tdbg.Columns(COL_AOriginalAmount).Text, InsertFormat(L3Int(tdbg.Columns(COL_ADecimalPlaces).Value))))).ToString
                        Else
                            tdbg.Columns(COL_AConvertedAmount).Value = 0
                        End If
                    End If
                    SUMFooter()
                End If
            Case COL_InventoryID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_InventoryName).Text = ""
                    tdbg.Columns(COL_UnitID).Text = ""
                Else
                    If ReturnDataRow(tdbdInventoryID, "InventoryID=" & SQLString(tdbg.Columns(COL_InventoryID).Text)) Is Nothing Then
                        tdbg.Columns(COL_InventoryName).Text = ""
                        tdbg.Columns(COL_UnitID).Text = ""
                    Else
                        tdbg.Columns(COL_InventoryName).Text = tdbdInventoryID.Columns("InventoryName").Text
                        tdbg.Columns(COL_UnitID).Text = tdbdInventoryID.Columns("UnitID").Text
                    End If
                End If
            Case COL_DObjectTypeID
                tdbg.Columns(COL_DObjectID).Text = ""
            Case COL_DCurrencyID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_DCurrencyID).Text = ""
                    tdbg.Columns(COL_DExchangeRate).Text = ""
                    tdbg.Columns(COL_DDecimalPlaces).Text = ""
                Else
                    tdbg.Columns(COL_DCurrencyID).Text = tdbdCurrencyID.Columns("CurrencyID").Text
                    tdbg.Columns(COL_DExchangeRate).Text = tdbdCurrencyID.Columns("ExchangeRate").Text
                    tdbg.Columns(COL_DOperator).Text = tdbdCurrencyID.Columns("Operator").Text
                    tdbg.Columns(COL_DDecimalPlaces).Text = tdbdCurrencyID.Columns("DecimalPlaces").Text
                End If
                'Cập nhât lại tỷ gia,  Quy đổi
                If tdbg.Columns(COL_DCurrencyID).ToString <> "" Then
                    If IsNumeric(tdbg.Columns(COL_DOriginalAmount).Text) Then
                        If tdbg.Columns(COL_DExchangeRate).Text <> "" Then 'Ty gia khac rong
                            tdbg.Columns(COL_DConvertedAmount).Value = CalCAmount(L3Int(tdbg.Columns(COL_DOperator).Text), Number(SQLMoney(tdbg.Columns(COL_DExchangeRate).Text, DxxFormat.ExchangeRateDecimals)), Number(SQLMoney(tdbg.Columns(COL_DOriginalAmount).Text, InsertFormat(L3Int(tdbg.Columns(COL_DDecimalPlaces).Value))))).ToString
                        Else
                            tdbg.Columns(COL_DConvertedAmount).Value = 0
                        End If
                    End If
                    SUMFooter()
                End If
            Case COL_DExchangeRate
                If IsNumeric(tdbg.Columns(COL_DOriginalAmount).Text) Then
                    If tdbg.Columns(COL_DExchangeRate).Text <> "" Then 'Ty gia khac rong
                        tdbg.Columns(COL_DConvertedAmount).Value = CalCAmount(L3Int(tdbg.Columns(COL_DOperator).Text), Number(SQLMoney(tdbg.Columns(COL_DExchangeRate).Text, DxxFormat.ExchangeRateDecimals)), Number(SQLMoney(tdbg.Columns(COL_DOriginalAmount).Text, InsertFormat(L3Int(tdbg.Columns(COL_DDecimalPlaces).Value))))).ToString
                    Else
                        tdbg.Columns(COL_DConvertedAmount).Value = 0
                    End If
                End If
                SUMFooter()
            Case COL_DOriginalAmount
                If IsNumeric(tdbg.Columns(COL_DOriginalAmount).Text) Then
                    If tdbg.Columns(COL_DExchangeRate).Text <> "" Then 'Ty gia khac rong
                        tdbg.Columns(COL_DConvertedAmount).Value = CalCAmount(L3Int(tdbg.Columns(COL_DOperator).Text), Number(SQLMoney(tdbg.Columns(COL_DExchangeRate).Text, DxxFormat.ExchangeRateDecimals)), Number(SQLMoney(tdbg.Columns(COL_DOriginalAmount).Text, InsertFormat(L3Int(tdbg.Columns(COL_DDecimalPlaces).Value))))).ToString
                    Else
                        tdbg.Columns(COL_DConvertedAmount).Value = 0
                    End If
                End If
                SUMFooter()


        End Select
    End Sub

    Public Function CalCAmount(ByVal iOperator As Integer, ByVal nExchangeRate As Double, ByVal nOAmount As Double) As Double
        If iOperator = 0 Then 'ty gia nhan
            Return nExchangeRate * nOAmount
        Else
            If nExchangeRate <> 0 Then
                Return nOAmount / nExchangeRate
            Else
                Return 0
            End If
        End If
    End Function

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
  If e IsNot Nothing AndAlso e.LastRow = -1 Then Exit Sub
        '--- Đổ nguồn cho các Dropdown phụ thuộc
        Select Case tdbg.Col
            Case COL_AObjectID
                LoadtdbdObjectID(tdbg(tdbg.Row, COL_AObjectTypeID).ToString)
            Case COL_ADebitAccountID
                LoadtdbdDebitAccountID(L3Int(optTransferMode1.Checked))
            Case COL_DObjectID
                LoadtdbdObjectID(tdbg(tdbg.Row, COL_DObjectTypeID).ToString)
            Case COL_DDebitAccountID
                LoadtdbdDebitAccountID()
            Case COL_InventoryID, COL_UnitID
                tdbg.Splits(2).DisplayColumns(tdbg.Col).Button = Not tdbg.Splits(2).DisplayColumns(tdbg.Col).Locked
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        '--- Chỉ cho nhập số
        Select Case tdbg.Col
            Case COL_IsSelect
                e.Handled = CheckKeyPress(e.KeyChar)
            Case COL_ASeriNo, COL_ARefNo, COL_DSeriNo, COL_DRefNo, COL_InventoryID
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
        End Select
    End Sub

    Dim bselected As Boolean = False
    Private Sub HeadClick(ByVal iCol As Integer)
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case iCol
            Case COL_IsSelect
                L3HeadClick(tdbg, COL_IsSelect, bselected)
            Case COL_ASeriNo, COL_ARefNo, COL_ARefDate, COL_ANotes, COL_ADebitAccountID, COL_ACreditAccountID, COL_AAna01ID, COL_AAna02ID, COL_AAna03ID, COL_AAna04ID, COL_AAna05ID, COL_AAna06ID, COL_AAna07ID, COL_AAna08ID, COL_AAna09ID, COL_AAna10ID, COL_ANotes, COL_UnitID
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
            Case COL_DSeriNo, COL_DRefNo, COL_DRefDate, COL_DNotes, COL_DDebitAccountID, COL_DCreditAccountID, COL_DAna01ID, COL_DAna02ID, COL_DAna03ID, COL_DAna04ID, COL_DAna05ID, COL_DAna06ID, COL_DAna07ID, COL_DAna08ID, COL_DAna09ID, COL_DAna10ID, COL_DNotes
                CopyColumns(tdbg, iCol, tdbg.Columns(iCol).Text, tdbg.Bookmark)
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        HeadClick(e.ColIndex)
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control And e.KeyCode = Keys.S Then HeadClick(tdbg.Col) : Exit Sub
        Select Case e.KeyCode
            Case Keys.F7
                HotKeyF7(tdbg, COL_ASeriNo, COL_ARefNo, COL_ARefDate, COL_ANotes, COL_ADebitAccountID, COL_ACreditAccountID, COL_AAna01ID, COL_AAna02ID, COL_AAna03ID, COL_AAna04ID, COL_AAna05ID, COL_AAna06ID, COL_AAna07ID, COL_AAna08ID, COL_AAna09ID, COL_AAna10ID): Exit Sub
        End Select
        HotKeyDownGrid(e, tdbg, COL_IsSelect, 0, 2, , , , L3Int(IIf(btnAssetAccount.Enabled, COL_DNotes, COL_ANotes)), txtNotes.Text)
    End Sub

#End Region

    Private Function AllowSave(ByRef dr() As DataRow) As Boolean
        If tdbcFromAssetID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tai_san"))
            tdbcFromAssetID.Focus()
            Return False
        End If
        If tdbcToAssetID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Tai_san"))
            tdbcToAssetID.Focus()
            Return False
        End If
        If tdbcChangeNo.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Nghiep_vu"))
            tdbcChangeNo.Focus()
            Return False
        End If
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If
        If txtVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_phieu"))
            txtVoucherNo.Focus()
            Return False
        End If

        tdbg.UpdateData()
        dtGrid.AcceptChanges()
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        dr = dtGrid.Select("IsSelect = 1")
        If dr.Length <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = tdbg.Columns.IndexOf(tdbg.Columns(COL_IsSelect))
            tdbg.Bookmark = 0
            Return False
        End If
        For i As Integer = 0 To dr.Length - 1
            If dr(i).Item("ACurrencyID").ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Loai_tien"))
                ClickButton(Button.AssetAccount)
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_ACurrencyID
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                Return False
            End If
            If dr(i).Item("AExchangeRate").ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ty_gia"))
                ClickButton(Button.AssetAccount)
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_AExchangeRate
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                Return False
            End If
            If dr(i).Item("ADebitAccountID").ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("TK_no"))
                ClickButton(Button.AssetAccount)
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_ADebitAccountID
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                Return False
            End If
            If dr(i).Item("ACreditAccountID").ToString = "" Then '
                D99C0008.MsgNotYetEnter(rl3("TK_co"))
                ClickButton(Button.AssetAccount)
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_ACreditAccountID
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                Return False
            End If
            If dr(i).Item("AOriginalAmount").ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Nguyen_te"))
                ClickButton(Button.AssetAccount)
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT2
                tdbg.Col = COL_AOriginalAmount
                tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                Return False
            End If

            If optTransferMode1.Checked Then
                If dr(i).Item("InventoryID").ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("Ma_hang_"))
                    ClickButton(Button.AssetAccount)
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_InventoryID
                    tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                    Return False
                End If
                If dr(i).Item("UnitID").ToString = "" Then
                    D99C0008.MsgNotYetEnter(rL3("DVT"))
                    ClickButton(Button.AssetAccount)
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT2
                    tdbg.Col = COL_UnitID
                    tdbg.Bookmark = dtGrid.Rows.IndexOf(dr(i))
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub SetBackColorObligatory()
        tdbcFromAssetID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcChangeNo.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcToAssetID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ACurrencyID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AExchangeRate).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ADebitAccountID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_ACreditAccountID).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AOriginalAmount).Style.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT1).DisplayColumns(COL_AssetID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_AssetName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_ConvertedAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_RemainAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_AssetAccountID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_DepAccountID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_AConvertedAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_InventoryName).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_DConvertedAmount).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_InventoryID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT2).DisplayColumns(COL_UnitID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub InputC1NumbericTDBGrid()
        Dim arrCol() As FormatColumn = Nothing 'Mảng lưu trữ định dạng của cột số
        'Thêm cột số có kiểu dữ liệu là Decimal
        AddDecimalColumns(arrCol, tdbg.Columns(COL_ConvertedAmount).DataField, DxxFormat.DecimalPlaces, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_DepAmount).DataField, DxxFormat.DecimalPlaces, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_RemainAmount).DataField, DxxFormat.DecimalPlaces, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        AddDecimalColumns(arrCol, tdbg.Columns(COL_AExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_AOriginalAmount).DataField, DxxFormat.DecimalPlaces, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_AConvertedAmount).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        AddDecimalColumns(arrCol, tdbg.Columns(COL_DExchangeRate).DataField, DxxFormat.ExchangeRateDecimals, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_DOriginalAmount).DataField, DxxFormat.DecimalPlaces, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm
        AddDecimalColumns(arrCol, tdbg.Columns(COL_DConvertedAmount).DataField, DxxFormat.D90_ConvertedDecimals, 28, 8) 'Cột có DataType là Decimal(28,8), không cho nhập số âm

        'Định dạng các cột số trên lưới
        InputNumber(tdbg, arrCol)
    End Sub


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2040
    '# Created User: Hoàng Nhân
    '# Created Date: 03/07/2013 02:04:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2040() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Load luoi" & vbCrLf)
        sSQL &= "Exec D02P2040 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbcFromAssetID.Text) & COMMA 'AssetIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcToAssetID.Text) & COMMA 'AssetIDTo, varchar[20], NOT NULL
        sSQL &= SQLMoney(txtCAmountFrom.Text, DxxFormat.DefaultNumber2) & COMMA 'CAmountFrom, decimal, NOT NULL
        sSQL &= SQLMoney(txtCAmountTo.Text, DxxFormat.DefaultNumber2) & COMMA 'CAmountTo, decimal, NOT NULL
        sSQL &= SQLString(tdbcChangeNo.Text) & COMMA 'ChangeNo, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optTransferMode0.Checked, "19", "43")) & COMMA 'TransferMode, tinyint, NOT NULL
        sSQL &= SQLNumber(chkShowZero.Checked)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD02T5012
    '# Created User: Hoàng Nhân
    '# Created Date: 03/07/2013 11:51:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD02T5012() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Xoa bang tam" & vbCrlf)
        sSQL &= "Delete From D02T5012"
        sSQL &= " Where UserID = " & SQLString(gsUserID)
        sSQL &= " AND FormID = 'D02F2040'"

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T5012s
    '# Created User: Hoàng Nhân
    '# Created Date: 03/07/2013 11:53:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T5012Assets(ByVal dr() As DataRow) As StringBuilder()
        Dim sRet() As StringBuilder = Nothing
        Dim iCountSQL As Integer = 0
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            ' If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Inset bang tam" & vbCrLf)
            sSQL.Append("Insert Into D02T5012(")
            sSQL.Append("UserID, FormID, AssetID, SeriNo, RefNo, RefDate, " & vbCrLf)
            sSQL.Append("NotesU, ObjectTypeID, ObjectID, CurrencyID," & vbCrLf)
            sSQL.Append("ExchangeRate, DebitAccountID, CreditAccountID, OriginalAmount, ConvertedAmount, " & vbCrLf)
            sSQL.Append("Ana01ID, Ana02ID, Ana03ID, Ana04ID, Ana05ID, " & vbCrLf)
            sSQL.Append("Ana06ID, Ana07ID, Ana08ID, Ana09ID, Ana10ID, " & vbCrLf)
            sSQL.Append("InventoryID, UnitID" & vbCrLf)
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[50], NULL
            sSQL.Append(SQLString("D02F2040") & COMMA) 'FormID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AssetID")).ToString & COMMA) 'AssetID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item("ASeriNo")).ToString & COMMA) 'VoucherTypeID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item("ARefNo")).ToString & COMMA) 'VoucherNo, varchar[20], NULL
            sSQL.Append(SQLDateSave(dr(i).Item("ARefDate")).ToString & COMMA & vbCrLf) 'VoucherDate, datetime, NULL

            sSQL.Append(SQLStringUnicode(dr(i).Item("ANotes").ToString, gbUnicode, True) & COMMA) 'Description, varchar[500], NULL
            sSQL.Append(SQLString(dr(i).Item("AObjectTypeID")).ToString & COMMA) 'ObjectTypeID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item("AObjectID")).ToString & COMMA) 'ObjectID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item("ACurrencyID")).ToString & COMMA) 'CurrencyID, varchar[20], NULL

            sSQL.Append(SQLMoney(dr(i).Item("AExchangeRate"), DxxFormat.ExchangeRateDecimals) & COMMA) 'ExchangeRate, money, NULL
            sSQL.Append(SQLString(dr(i).Item("ADebitAccountID")).ToString & COMMA) 'DebitAccountID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item("ACreditAccountID")).ToString & COMMA) 'CreditAccountID, varchar[20], NULL
            sSQL.Append(SQLMoney(dr(i).Item("AOriginalAmount"), InsertFormat(L3Int(dr(i).Item("ADecimalPlaces")))) & COMMA) 'OriginalAmount, money, NULL
            sSQL.Append(SQLMoney(dr(i).Item("AConvertedAmount"), tdbg.Columns(COL_AConvertedAmount).NumberFormat) & COMMA) 'ConvertedAmount, money, NULL
            sSQL.Append(SQLString(dr(i).Item("AAna01ID")).ToString & COMMA) 'Ana01ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna02ID")).ToString & COMMA) 'Ana02ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna03ID")).ToString & COMMA) 'Ana03ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna04ID")).ToString & COMMA) 'Ana04ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna05ID")).ToString & COMMA) 'Ana05ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna06ID")).ToString & COMMA) 'Ana06ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna07ID")).ToString & COMMA) 'Ana07ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna08ID")).ToString & COMMA) 'Ana08ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna09ID")).ToString & COMMA) 'Ana09ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("AAna10ID")).ToString & COMMA) 'Ana10ID, varchar[50], NULL
            sSQL.Append(SQLString(dr(i).Item("InventoryID")).ToString & COMMA) 'InventoryID, varchar[20], NULL
            sSQL.Append(SQLString(dr(i).Item("UnitID")).ToString) 'UnitID, varchar[20], NULL
            sSQL.Append(")" & vbCrLf)

            '            sRet.Append(sSQL.ToString & vbCrLf)
            '            sSQL.Remove(0, sSQL.Length)
            iCountSQL += 1
            sRet = ReturnSQL(sRet, sSQL, iCountSQL, 30) 'Mặc định là 30 dòng Insert
        Next
        sRet = AddValueInArrStringBuilder(sRet, sSQL, True) 'Mặc định là thêm vào cuối mảng SQL
        Return sRet
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD02T5012s
    '# Created User: Hoàng Nhân
    '# Created Date: 03/07/2013 11:53:26
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD02T5012Deps(ByVal dr() As DataRow) As StringBuilder()
        Dim sRet() As StringBuilder = Nothing
        Dim sSQL As New StringBuilder
        Dim iCountSQL As Integer = 0
        For i As Integer = 0 To dr.Length - 1
            If Number(dr(i).Item("DOriginalAmount")) <> 0 OrElse Number(dr(i).Item("DConvertedAmount")) <> 0 Then
                '  If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Inset bang tam" & vbCrLf)
                sSQL.Append("Insert Into D02T5012(")
                sSQL.Append("UserID, FormID, AssetID, SeriNo, RefNo, RefDate, " & vbCrLf)
                sSQL.Append("NotesU, ObjectTypeID, ObjectID, CurrencyID," & vbCrLf)
                sSQL.Append("ExchangeRate, DebitAccountID, CreditAccountID, OriginalAmount, ConvertedAmount, " & vbCrLf)
                sSQL.Append("Ana01ID, Ana02ID, Ana03ID, Ana04ID, Ana05ID, " & vbCrLf)
                sSQL.Append("Ana06ID, Ana07ID, Ana08ID, Ana09ID, Ana10ID " & vbCrLf)
                sSQL.Append(") Values(" & vbCrLf)
                sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[50], NULL
                sSQL.Append(SQLString("D02F2040") & COMMA) 'FormID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("AssetID")).ToString & COMMA) 'AssetID, varchar[20], NULL
                sSQL.Append(SQLString(dr(i).Item("DSeriNo")).ToString & COMMA) 'VoucherTypeID, varchar[20], NULL
                sSQL.Append(SQLString(dr(i).Item("DRefNo")).ToString & COMMA) 'VoucherNo, varchar[20], NULL
                sSQL.Append(SQLDateSave(dr(i).Item("DRefDate")).ToString & COMMA & vbCrLf) 'VoucherDate, datetime, NULL

                sSQL.Append(SQLStringUnicode(dr(i).Item("DNotes"), gbUnicode, True) & COMMA) 'Description, varchar[500], NULL
                sSQL.Append(SQLString(dr(i).Item("DObjectTypeID")).ToString & COMMA) 'ObjectTypeID, varchar[20], NULL
                sSQL.Append(SQLString(dr(i).Item("DObjectID")).ToString & COMMA) 'ObjectID, varchar[20], NULL
                sSQL.Append(SQLString(dr(i).Item("DCurrencyID")).ToString & COMMA) 'CurrencyID, varchar[20], NULL

                sSQL.Append(SQLMoney(dr(i).Item("DExchangeRate"), DxxFormat.ExchangeRateDecimals) & COMMA) 'ExchangeRate, money, NULL
                sSQL.Append(SQLString(dr(i).Item("DDebitAccountID")).ToString & COMMA) 'DebitAccountID, varchar[20], NULL
                sSQL.Append(SQLString(dr(i).Item("DCreditAccountID")).ToString & COMMA) 'CreditAccountID, varchar[20], NULL
                sSQL.Append(SQLMoney(dr(i).Item("DOriginalAmount"), InsertFormat(L3Int(dr(i).Item("DDecimalPlaces")))) & COMMA) 'OriginalAmount, money, NULL
                sSQL.Append(SQLMoney(dr(i).Item("DConvertedAmount"), tdbg.Columns(COL_DConvertedAmount).NumberFormat) & COMMA) 'ConvertedAmount, money, NULL
                sSQL.Append(SQLString(dr(i).Item("DAna01ID")).ToString & COMMA) 'Ana01ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna02ID")).ToString & COMMA) 'Ana02ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna03ID")).ToString & COMMA) 'Ana03ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna04ID")).ToString & COMMA) 'Ana04ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna05ID")).ToString & COMMA) 'Ana05ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna06ID")).ToString & COMMA) 'Ana06ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna07ID")).ToString & COMMA) 'Ana07ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna08ID")).ToString & COMMA) 'Ana08ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna09ID")).ToString & COMMA) 'Ana09ID, varchar[50], NULL
                sSQL.Append(SQLString(dr(i).Item("DAna10ID")).ToString) 'Ana10ID, varchar[50], NULL
                sSQL.Append(")")

                '                sRet.Append(sSQL.ToString & vbCrLf)
                '                sSQL.Remove(0, sSQL.Length)
                iCountSQL += 1
                sRet = ReturnSQL(sRet, sSQL, iCountSQL, 30) 'Mặc định là 30 dòng Insert
            End If
        Next
        sRet = AddValueInArrStringBuilder(sRet, sSQL, True) 'Mặc định là thêm vào cuối mảng SQL
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2045
    '# Created User: Hoàng Nhân
    '# Created Date: 03/07/2013 01:50:22
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2045() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Luu du lieu" & vbCrlf)
        sSQL &= "Exec D02P2045 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(IIf(optTransferMode0.Checked, "19", "43")) & COMMA 'TransferMode, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(tdbcChangeNo.Text) & COMMA 'ChangeNo, varchar[20], NOT NULL
        sSQL &= SQLDateSave(c1dateChangeDate.Value) & COMMA 'ChangeDate, datetime, NOT NULL
        sSQL &= SQLString("") & COMMA 'Notes, varchar[250], NOT NULL
        sSQL &= SQLStringUnicode(txtNotes, True) & COMMA 'NotesU, nvarchar[250], NOT NULL
        sSQL &= SQLString(tdbcVoucherTypeID.Text) & COMMA 'VoucherTypeID, varchar[20], NOT NULL
        sSQL &= SQLString(txtVoucherNo.Text) & COMMA 'VoucherNo, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, varchar[20], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P2120
    '# Created User: NGOCTHOAI
    '# Created Date: 05/05/2017 03:34:41
    '05/05/2017, Trần Hoàng Anh: id 96897-Sửa câu đổ nguồn mã CCDC thành store
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD02P2120() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon dropdown Ma hang " & vbCrlf)
        sSQL &= "Exec D02P2120 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLNumber(0) 'Mode, tinyint, NOT NULL
        Return sSQL
    End Function



End Class