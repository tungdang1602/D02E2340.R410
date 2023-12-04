<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D99F6666
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D99F6666))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.txtStandardReportID = New System.Windows.Forms.TextBox
        Me.lblStandardForm = New System.Windows.Forms.Label
        Me.tdbcReportID = New C1.Win.C1List.C1Combo
        Me.lblReportID = New System.Windows.Forms.Label
        Me.lblPrefixReport = New System.Windows.Forms.Label
        Me.chkViewPathReport = New System.Windows.Forms.CheckBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtReportName = New System.Windows.Forms.TextBox
        Me.txtStandardReportName = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkIsPrintVNI = New System.Windows.Forms.CheckBox
        CType(Me.tdbcReportID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtStandardReportID
        '
        Me.txtStandardReportID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtStandardReportID.Location = New System.Drawing.Point(88, 19)
        Me.txtStandardReportID.Name = "txtStandardReportID"
        Me.txtStandardReportID.ReadOnly = True
        Me.txtStandardReportID.Size = New System.Drawing.Size(155, 22)
        Me.txtStandardReportID.TabIndex = 1
        '
        'lblStandardForm
        '
        Me.lblStandardForm.AutoSize = True
        Me.lblStandardForm.Location = New System.Drawing.Point(10, 24)
        Me.lblStandardForm.Name = "lblStandardForm"
        Me.lblStandardForm.Size = New System.Drawing.Size(61, 13)
        Me.lblStandardForm.TabIndex = 0
        Me.lblStandardForm.Text = "Mẫu chuẩn"
        Me.lblStandardForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcReportID
        '
        Me.tdbcReportID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcReportID.AllowColMove = False
        Me.tdbcReportID.AllowSort = False
        Me.tdbcReportID.AlternatingRows = True
        Me.tdbcReportID.AutoCompletion = True
        Me.tdbcReportID.AutoDropDown = True
        Me.tdbcReportID.Caption = ""
        Me.tdbcReportID.CaptionHeight = 17
        Me.tdbcReportID.CaptionStyle = Style1
        Me.tdbcReportID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcReportID.ColumnCaptionHeight = 17
        Me.tdbcReportID.ColumnFooterHeight = 17
        Me.tdbcReportID.ColumnWidth = 100
        Me.tdbcReportID.ContentHeight = 17
        Me.tdbcReportID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcReportID.DisplayMember = "ReportID"
        Me.tdbcReportID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcReportID.DropDownWidth = 350
        Me.tdbcReportID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcReportID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcReportID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcReportID.EditorHeight = 17
        Me.tdbcReportID.EmptyRows = True
        Me.tdbcReportID.EvenRowStyle = Style2
        Me.tdbcReportID.ExtendRightColumn = True
        Me.tdbcReportID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcReportID.FooterStyle = Style3
        Me.tdbcReportID.HeadingStyle = Style4
        Me.tdbcReportID.HighLightRowStyle = Style5
        Me.tdbcReportID.Images.Add(CType(resources.GetObject("tdbcReportID.Images"), System.Drawing.Image))
        Me.tdbcReportID.ItemHeight = 15
        Me.tdbcReportID.Location = New System.Drawing.Point(88, 48)
        Me.tdbcReportID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcReportID.MaxDropDownItems = CType(8, Short)
        Me.tdbcReportID.MaxLength = 32767
        Me.tdbcReportID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcReportID.Name = "tdbcReportID"
        Me.tdbcReportID.OddRowStyle = Style6
        Me.tdbcReportID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcReportID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcReportID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcReportID.SelectedStyle = Style7
        Me.tdbcReportID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcReportID.Style = Style8
        Me.tdbcReportID.TabIndex = 4
        Me.tdbcReportID.ValueMember = "ReportID"
        Me.tdbcReportID.PropBag = resources.GetString("tdbcReportID.PropBag")
        '
        'lblReportID
        '
        Me.lblReportID.AutoSize = True
        Me.lblReportID.Location = New System.Drawing.Point(10, 53)
        Me.lblReportID.Name = "lblReportID"
        Me.lblReportID.Size = New System.Drawing.Size(45, 13)
        Me.lblReportID.TabIndex = 3
        Me.lblReportID.Text = "Đặc thù"
        Me.lblReportID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrefixReport
        '
        Me.lblPrefixReport.AutoSize = True
        Me.lblPrefixReport.Location = New System.Drawing.Point(222, 53)
        Me.lblPrefixReport.Name = "lblPrefixReport"
        Me.lblPrefixReport.Size = New System.Drawing.Size(22, 13)
        Me.lblPrefixReport.TabIndex = 5
        Me.lblPrefixReport.Text = ".rpt"
        Me.lblPrefixReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkViewPathReport
        '
        Me.chkViewPathReport.AutoSize = True
        Me.chkViewPathReport.Checked = True
        Me.chkViewPathReport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewPathReport.Location = New System.Drawing.Point(13, 90)
        Me.chkViewPathReport.Name = "chkViewPathReport"
        Me.chkViewPathReport.Size = New System.Drawing.Size(263, 17)
        Me.chkViewPathReport.TabIndex = 7
        Me.chkViewPathReport.Text = "Hiển thị màn hình đường dẫn báo cáo cho lần sau"
        Me.chkViewPathReport.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(364, 122)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(70, 22)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&In"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(440, 122)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(70, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtReportName
        '
        Me.txtReportName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtReportName.Location = New System.Drawing.Point(247, 48)
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.ReadOnly = True
        Me.txtReportName.Size = New System.Drawing.Size(250, 22)
        Me.txtReportName.TabIndex = 6
        '
        'txtStandardReportName
        '
        Me.txtStandardReportName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtStandardReportName.Location = New System.Drawing.Point(247, 19)
        Me.txtStandardReportName.Name = "txtStandardReportName"
        Me.txtStandardReportName.ReadOnly = True
        Me.txtStandardReportName.Size = New System.Drawing.Size(250, 22)
        Me.txtStandardReportName.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkIsPrintVNI)
        Me.GroupBox1.Controls.Add(Me.txtStandardReportID)
        Me.GroupBox1.Controls.Add(Me.lblPrefixReport)
        Me.GroupBox1.Controls.Add(Me.txtStandardReportName)
        Me.GroupBox1.Controls.Add(Me.tdbcReportID)
        Me.GroupBox1.Controls.Add(Me.lblReportID)
        Me.GroupBox1.Controls.Add(Me.chkViewPathReport)
        Me.GroupBox1.Controls.Add(Me.lblStandardForm)
        Me.GroupBox1.Controls.Add(Me.txtReportName)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 114)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkIsPrintVNI
        '
        Me.chkIsPrintVNI.AutoSize = True
        Me.chkIsPrintVNI.Location = New System.Drawing.Point(299, 90)
        Me.chkIsPrintVNI.Name = "chkIsPrintVNI"
        Me.chkIsPrintVNI.Size = New System.Drawing.Size(98, 17)
        Me.chkIsPrintVNI.TabIndex = 8
        Me.chkIsPrintVNI.Text = "In báo cáo VNI"
        Me.chkIsPrintVNI.UseVisualStyleBackColor = True
        '
        'D99F6666
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 152)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D99F6666"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chãn ¢§éng dÉn bÀo cÀo"
        CType(Me.tdbcReportID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtStandardReportID As System.Windows.Forms.TextBox
    Private WithEvents lblStandardForm As System.Windows.Forms.Label
    Private WithEvents tdbcReportID As C1.Win.C1List.C1Combo
    Private WithEvents lblReportID As System.Windows.Forms.Label
    Private WithEvents lblPrefixReport As System.Windows.Forms.Label
    Private WithEvents chkViewPathReport As System.Windows.Forms.CheckBox
    Private WithEvents btnPrint As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents txtReportName As System.Windows.Forms.TextBox
    Private WithEvents txtStandardReportName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents chkIsPrintVNI As System.Windows.Forms.CheckBox
End Class
