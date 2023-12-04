Imports System
'#---------------------------------------------------------------------------------------------------
'# Title: D99F6666
'# Created User: Nguyễn Thị Ánh
'# Created Date: 30/06/2010 14:33
'# Modified User: Nguyễn Thị Minh Hòa
'# Modified Date: 15/02/2011
'# Description: Viết thành Form chung: 
'                                   Đầu vào : _ModuleID, _pathReportID, _reportID, _reportTypeID
'                                   Đầu ra : _pathReportID, _reportID, _reportTitle
'#              Sau khi In gọi thêm hàm SaveOptionReport (tự Viết riêng tại DxxX0002 để lưu lại Tùy chọn)    
'#---------------------------------------------------------------------------------------------------
Public Class D99F6666

    Dim _pressClosed As Boolean = True

#Region "In - Out parameters"
    Private _reportTypeID As String = ""
    Public WriteOnly Property ReportTypeID() As String
        Set(ByVal Value As String)
            _reportTypeID = Value
        End Set
    End Property

    Private _customReport As String = ""
    Public WriteOnly Property CustomReport() As String
        Set(ByVal Value As String)
            _customReport = Value
        End Set
    End Property

    Private _ModuleID As String = "" 'Truyền XX
    Public WriteOnly Property ModuleID() As String
        Set(ByVal Value As String)
            _ModuleID = Value
        End Set
    End Property

    Private _reportPath As String = ""
    Public Property ReportPath() As String
        Get
            Return _reportPath
        End Get
        Set(ByVal Value As String)
            _reportPath = Value
        End Set
    End Property

    Private _reportName As String = ""
    Public Property ReportName() As String
        Get
            Return _reportName
        End Get
        Set(ByVal Value As String)
            _reportName = Value
        End Set
    End Property

    Private _reportTitle As String
    Public Property ReportTitle() As String
        Get
            Return _reportTitle
        End Get
        Set(ByVal Value As String)
            _reportTitle = Value
        End Set
    End Property

    Private _printVNI As Boolean = False
    Public ReadOnly Property PrintVNI() As Boolean 
        Get
            Return _printVNI
        End Get
    End Property

    Private _reportLanguge As Byte = 0
    Public WriteOnly Property ReportLanguge() As Byte 
        Set(ByVal Value As Byte )
            _reportLanguge = Value
        End Set
    End Property
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub D99F6666_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If _pressClosed Then _reportName = ""
    End Sub

    Private Sub D99F6666_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D99F6666_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadLanguage()
        chkIsPrintVNI.Visible = gbUnicode And gbPrintVNI
        InputbyUnicode(Me, gbUnicode)
        'Update 06/01/2011: Làm theo chuẩn, không lấy hết đường dẫn, chỉ lấy đường dẫn ngắn nhất \XReports\DxxRxxxx.rpt
        'txtStandardReportID.Text = _reportPath & _reportName & ".rpt"
        txtStandardReportID.Text = _reportPath.Substring(_reportPath.LastIndexOf("\"c, _reportPath.Length - 2)) & _reportName & ".rpt"

        LoadStandardReportName()
        LoadtdbcCustomizeReport(tdbcReportID, _ModuleID, _reportTypeID, txtReportName)
        tdbcReportID.SelectedValue = _customReport
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadStandardReportName()
        Dim sSQL As String = ""

        'sSQL = "Select " & IIf(geLanguage = EnumLanguage.Vietnamese, "ReportTypeName", " ReportTypeName01").ToString & " As ReportTypeName " & vbCrLf
        'sSQL &= " From D89T0010 Where ModuleID = " & SQLString(_ModuleID) & " And ReportTypeID = " & SQLString(_reportTypeID)

        'Update 15/02/2011: Làm theo chuẩn
        sSQL = "Select "
        If gbUnicode Then
            sSQL &= IIf(geLanguage = EnumLanguage.Vietnamese, "TitleU", "Title01U").ToString & " as Title " & vbCrLf
        Else
            sSQL &= IIf(geLanguage = EnumLanguage.Vietnamese, "Title", "Title01").ToString & " as Title " & vbCrLf
        End If
        sSQL &= " From D89T2000 WITH(NOLOCK) Where ModuleID = " & SQLString(_ModuleID) & " And ReportTypeID = " & SQLString(_reportTypeID)
        sSQL &= " And ReportID = " & SQLString(_reportName)

        txtStandardReportName.Text = ReturnScalar(sSQL)
    End Sub

#Region "Events tdbcReportID with txtReportName"

    Private Sub tdbcReportID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcReportID.SelectedValueChanged
        If tdbcReportID.SelectedValue Is Nothing Then
            txtReportName.Text = ""
        Else
            txtReportName.Text = tdbcReportID.Columns("Title").Value.ToString
        End If
    End Sub
#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        _pressClosed = False
        If tdbcReportID.Text <> "" Then
            _reportPath = Application.StartupPath & "\XCustom\"
            _reportName = tdbcReportID.Text
            _reportTitle = txtReportName.Text
        Else
            _reportTitle = txtStandardReportName.Text
        End If
        'định nghĩa thêm hàm này tại module dxxx0002
        SaveOptionReport(chkViewPathReport.Checked)
        _printVNI = chkIsPrintVNI.Checked
        Me.Close()
    End Sub

    Private Sub D99F6666_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        tdbcReportID.Focus()
    End Sub

    Private Sub LoadLanguage()
        Me.Text = r("Chon_duong_dan_bao_caoF") & UnicodeCaption(gbUnicode) 'Chãn ¢§éng dÉn bÀo cÀo
        If geLanguage = EnumLanguage.English Then
            Me.Text = "Select Path of Reports"
            lblStandardForm.Text = "Report Type of"
            lblReportID.Text = "Customized"

            btnPrint.Text = "&Print"
            btnClose.Text = "&Close"
            tdbcReportID.Columns("ReportID").Caption = "Code"
            tdbcReportID.Columns("Title").Caption = "Description"
        End If
        chkViewPathReport.Text = r("MSG000035")
        chkIsPrintVNI.Text = r("In_bao_cao_VNI") 'Bổ sung 22/02/2013
    End Sub

    'Bổ sung 22/02/2013 - Định lại đường dẫn in báo cáo
    Private Sub chkIsPrintVNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPrintVNI.Click
        _reportPath = UnicodeGetReportPath(Not chkIsPrintVNI.Checked, _reportLanguge, "")
        txtStandardReportID.Text = _reportPath.Substring(_reportPath.LastIndexOf("\"c, _reportPath.Length - 2)) & _reportName & ".rpt"
    End Sub
End Class