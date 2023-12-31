'#######################################################################################
'#                                     CHÚ Ý
'#--------------------------------------------------------------------------------------
'# Không được thay đổi bất cứ dòng code này trong module này, nếu muốn thay đổi bạn phải
'# liên lạc với Trưởng nhóm để được giải quyết.
'# Ngày cập nhật cuối cùng: 09/10/2009
'# Người cập nhật cuối cùng: Nguyễn Thị Minh Hòa
'#######################################################################################
''' <summary>
''' Module liên quan đến các vấn đề của hãng C1
''' </summary>
''' <remarks></remarks>
Module D99X0002

#Region "Đổ nguồn cho C1Combo"

    ''' <summary>
    ''' Đổ nguồn cho C1Combo
    ''' </summary>
    ''' <param name="C1Combo">Tên C1Combo cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    ''' <param name="Width">Mảng chiều rộng các cột tương ứng của C1Combo</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal sSQL As String, ByVal Width() As Integer)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1Combo, dt, Width)
    End Sub


    ''' <summary>
    ''' Đổ nguồn cho C1Combo nhập Unicode
    ''' </summary>
    ''' <param name="C1Combo">Tên C1Combo cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    ''' <param name="Width">Mảng chiều rộng các cột tương ứng của C1Combo</param>
    <DebuggerStepThrough()> _
   Public Sub LoadDataSource(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal sSQL As String, ByVal Width() As Integer, ByVal bUseUnicode As Boolean)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1Combo, dt, Width, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1Combo
    ''' </summary>
    ''' <param name="C1Combo">Tên C1Combo cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    ''' <param name="Width">Mảng chiều rộng các cột tương ứng của C1Combo</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal dt As DataTable, ByVal Width() As Integer)
        LoadDataSource(C1Combo, dt)
        For i As Integer = 0 To C1Combo.Splits(0).DisplayColumns.Count - 1
            C1Combo.Splits(0).DisplayColumns(i).Width = Width(i)
        Next
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1Combo nhập Unicode
    ''' </summary>
    ''' <param name="C1Combo">Tên C1Combo cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    ''' <param name="Width">Mảng chiều rộng các cột tương ứng của C1Combo</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal dt As DataTable, ByVal Width() As Integer, ByVal bUseUnicode As Boolean)
        LoadDataSource(C1Combo, dt, bUseUnicode)
        For i As Integer = 0 To C1Combo.Splits(0).DisplayColumns.Count - 1
            C1Combo.Splits(0).DisplayColumns(i).Width = Width(i)
        Next
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1Combo
    ''' </summary>
    ''' <param name="C1Combo">Tên C1Combo cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal sSQL As String)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1Combo, dt)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1Combo nhập Unicode
    ''' </summary>
    ''' <param name="C1Combo">Tên C1Combo cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal sSQL As String, ByVal bUseUnicode As Boolean)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1Combo, dt, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1Combo
    ''' </summary>
    ''' <param name="C1Combo">Tên C1Combo cần đổ nguồn</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal dt As DataTable)
        LoadDataSource(C1Combo, dt, False)
    End Sub


    ''' <summary>
    ''' Đổ nguồn cho C1Combo nhập Unicode
    ''' </summary>
    ''' <param name="C1Combo">Tên C1Combo cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal dt As DataTable, ByVal bUseUnicode As Boolean)
        Dim iMaxDropdownItems As Integer = 8
        Dim iColumnsCount As Integer = dt.Columns.Count - 1
        For i As Integer = iColumnsCount To 0 Step -1
            If IsExistDataField(C1Combo, dt.Columns(i).ColumnName) = False Then dt.Columns.RemoveAt(i)
        Next
        If dt.Rows.Count < iMaxDropdownItems Then
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To iMaxDropdownItems - dt.Rows.Count - 1
                dr = dt.NewRow
                dt.Rows.Add(dr)
            Next
        End If
        Dim arrWidth(C1Combo.Splits(0).DisplayColumns.Count - 1) As Integer
        Dim arrVisible(C1Combo.Splits(0).DisplayColumns.Count - 1) As Boolean
        Dim arrHorizontalAlignment(C1Combo.Splits(0).DisplayColumns.Count - 1) As C1.Win.C1List.AlignHorzEnum
        For i As Integer = 0 To C1Combo.Splits(0).DisplayColumns.Count - 1
            arrWidth(i) = C1Combo.Splits(0).DisplayColumns(i).Width
            arrVisible(i) = C1Combo.Splits(0).DisplayColumns(i).Visible
            arrHorizontalAlignment(i) = C1Combo.Splits(0).DisplayColumns(i).Style.HorizontalAlignment
        Next
        Dim arrCaption(C1Combo.Columns.Count - 1) As String
        For i As Integer = 0 To C1Combo.Columns.Count - 1
            arrCaption(i) = C1Combo.Columns(i).Caption
        Next
        C1Combo.DataSource = dt
        C1Combo.DisplayMember = C1Combo.DisplayMember
        C1Combo.ValueMember = C1Combo.ValueMember
        If bUseUnicode Then
            C1Combo.Font = New Font("Microsoft Sans Serif", 8.25)
            C1Combo.EditorFont = New Font("Microsoft Sans Serif", 8.25)
        Else
            C1Combo.Font = New Font("Lemon3", 8.249999!)
            C1Combo.EditorFont = New Font("Lemon3", 8.249999!)
        End If

        For i As Integer = 0 To C1Combo.Columns.Count - 1
            C1Combo.Columns(i).Caption = arrCaption(i)
        Next
        For i As Integer = 0 To C1Combo.Splits(0).DisplayColumns.Count - 1
            With C1Combo.Splits(0).DisplayColumns(i)
                .HeadingStyle.HorizontalAlignment = C1.Win.C1List.AlignHorzEnum.Center
                .Width = arrWidth(i)
                .Visible = arrVisible(i)
                .Style.HorizontalAlignment = arrHorizontalAlignment(i)
            End With
        Next
        C1Combo.HeadingStyle.Font = New Font("Microsoft Sans Serif", 8.25)
        C1Combo.HighLightRowStyle.BackColor = Color.Green
        C1Combo.HighLightRowStyle.ForeColor = SystemColors.HighlightText
        C1Combo.SelectedStyle.BackColor = Color.Green
        C1Combo.SelectedStyle.ForeColor = SystemColors.HighlightText
    End Sub

#End Region

#Region "Đổ nguồn cho C1DropDown"

    ''' <summary>
    ''' Đổ nguồn cho C1DropDown
    ''' </summary>
    ''' <param name="C1DropDown">Tên C1DropDown cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sSQL As String)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1DropDown, dt)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1DropDown nhập Unicode
    ''' </summary>
    ''' <param name="C1DropDown">Tên C1DropDown cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sSQL As String, ByVal bUseUnicode As Boolean)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1DropDown, dt, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1DropDown
    ''' </summary>
    ''' <param name="C1DropDown">Tên C1DropDown cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dt As DataTable)
        Dim iMaxDropdownItems As Integer = 8

        'Modify date: 09/10/2009: Bỏ đoạn code dư này
        'Dim iColumnsCount As Integer = dt.Columns.Count - 1
        'For i As Integer = iColumnsCount To 0 Step -1
        '    If IsExistDataField(C1DropDown, dt.Columns(i).ColumnName) = False Then dt.Columns.RemoveAt(i)
        'Next
        If dt.Rows.Count < iMaxDropdownItems Then
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To iMaxDropdownItems - dt.Rows.Count - 1
                dr = dt.NewRow
                dt.Rows.Add(dr)
            Next
        End If
        'Modify date: 31/08/2006: Set màu khi chọn
        C1DropDown.Styles.Item("Selected").BackColor = Color.Green
        'Dim dt1 As DataTable = dt.Copy
        C1DropDown.SetDataBinding(dt, "", True)
        'CType(C1DropDown.DataSource, DataTable).DataSet.Clear()
        'CType(C1DropDown.DataSource, DataTable).DataSet.AcceptChanges()
        'CType(C1DropDown.DataSource, DataTable).DataSet.Merge(dt1)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1DropDown nhập Unicode
    ''' </summary>
    ''' <param name="C1DropDown">Tên C1DropDown cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dt As DataTable, ByVal bUseUnicode As Boolean)
        'Modify date: 30/07/2010: Set Font nhập Unicode
        If bUseUnicode Then C1DropDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        LoadDataSource(C1DropDown, dt)

    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1DropDown
    ''' </summary>
    ''' <param name="C1DropDown">Tên C1DropDown cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    ''' <param name="Width">Mảng chiều rộng các cột tương ứng của C1DropDown</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sSQL As String, ByVal Width() As Integer)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1DropDown, dt, Width)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1DropDown nhập Unicode
    ''' </summary>
    ''' <param name="C1DropDown">Tên C1DropDown cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    ''' <param name="Width">Mảng chiều rộng các cột tương ứng của C1DropDown</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal sSQL As String, ByVal Width() As Integer, ByVal bUseUnicode As Boolean)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1DropDown, dt, Width, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1DropDown
    ''' </summary>
    ''' <param name="C1DropDown">Tên C1DropDown cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    ''' <param name="Width">Mảng chiều rộng các cột tương ứng của C1DropDown</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dt As DataTable, ByVal Width() As Integer)
        LoadDataSource(C1DropDown, dt, Width, False)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1DropDown nhập Unicode
    ''' </summary>
    ''' <param name="C1DropDown">Tên C1DropDown cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    ''' <param name="Width">Mảng chiều rộng các cột tương ứng của C1DropDown</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dt As DataTable, ByVal Width() As Integer, ByVal bUseUnicode As Boolean)
        LoadDataSource(C1DropDown, dt, bUseUnicode)
        For i As Integer = 0 To C1DropDown.DisplayColumns.Count - 1
            C1DropDown.DisplayColumns(i).Width = Width(i)
        Next
    End Sub
#End Region

#Region "Đổ nguồn cho C1Grid"

    ''' <summary>
    ''' Đổ nguồn cho C1Grid nhập Unicode
    ''' </summary>
    ''' <param name="C1Grid">Tên C1Grid cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dt As DataTable, ByVal bUseUnicode As Boolean)
        'Modify date: 17/03/2009: Set Font nhập Unicode
        'If bUseUnicode Then C1Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25)
        If bUseUnicode Then
            C1Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25)
            For Each dc As C1.Win.C1TrueDBGrid.C1DataColumn In C1Grid.Columns
                For i As Integer = 0 To C1Grid.Splits.ColCount - 1
                    C1Grid.Splits(i).DisplayColumns(dc.DataField).Style.Font = C1Grid.Font 'FontUnicode(bUseUnicode)
                Next
            Next
        End If
        LoadDataSource(C1Grid, dt)

    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1Grid nhập Unicode
    ''' </summary>
    ''' <param name="C1Grid">Tên C1Grid cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sSQL As String, ByVal bUseUnicode As Boolean)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1Grid, dt, bUseUnicode)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1Grid
    ''' </summary>
    ''' <param name="C1Grid">Tên C1Grid cần đổ nguồn</param>
    ''' <param name="sSQL">Lệnh SQL đổ nguồn</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sSQL As String)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        LoadDataSource(C1Grid, dt)
    End Sub

    ''' <summary>
    ''' Đổ nguồn cho C1Grid
    ''' </summary>
    ''' <param name="C1Grid">Tên C1Grid cần đổ nguồn</param>
    ''' <param name="dt">DataTable nguồn</param>
    <DebuggerStepThrough()> _
    Public Sub LoadDataSource(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dt As DataTable)
        'Modify date: 09/10/2009: Bỏ đoạn code dư này
        'Dim iColumnsCount As Integer = dt.Columns.Count - 1
        'For i As Integer = iColumnsCount To 0 Step -1
        '    If IsExistDataField(C1Grid, dt.Columns(i).ColumnName) = False Then dt.Columns.RemoveAt(i)
        'Next
        C1Grid.SetDataBinding(dt, "", True)
    End Sub

#End Region

    '#Region "Private sub"
    'Modify date: 09/10/2009: Bỏ đoạn code dư này
    <DebuggerStepThrough()> _
    Private Function IsExistDataField(ByVal C1Comobo As C1.Win.C1List.C1Combo, ByVal DataField As String) As Boolean
        For Each dc As C1.Win.C1List.C1DataColumn In C1Comobo.Columns
            If dc.DataField = DataField Then Return True
        Next
        Return False
    End Function

    '    <DebuggerStepThrough()> _
    '    Private Function IsExistDataField(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal DataField As String) As Boolean
    '        For Each dc As C1.Win.C1TrueDBGrid.C1DataColumn In C1DropDown.Columns
    '            If dc.DataField = DataField Then Return True
    '        Next
    '        Return False
    '    End Function

    '    <DebuggerStepThrough()> _
    '    Private Function IsExistDataField(ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal DataField As String) As Boolean
    '        For Each dc As C1.Win.C1TrueDBGrid.C1DataColumn In C1Grid.Columns
    '            If dc.DataField = DataField Then Return True
    '        Next
    '        Return False
    '    End Function

    '#End Region

End Module
