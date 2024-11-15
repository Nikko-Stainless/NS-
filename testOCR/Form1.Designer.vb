<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cbbShimei = New System.Windows.Forms.ComboBox()
        Me.cbbMonth = New System.Windows.Forms.ComboBox()
        Me.dgvMain = New System.Windows.Forms.DataGridView()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.colCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompany = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFiles = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colLink = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Bisque
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(12, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "①請求書の名前へ変換"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Linen
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.btnSend)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.cbbShimei)
        Me.GroupBox1.Controls.Add(Me.cbbMonth)
        Me.GroupBox1.Controls.Add(Me.dgvMain)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1121, 468)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "②メール送信"
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.BackColor = System.Drawing.Color.Bisque
        Me.btnSend.ForeColor = System.Drawing.Color.Black
        Me.btnSend.Location = New System.Drawing.Point(1008, 421)
        Me.btnSend.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(107, 40)
        Me.btnSend.TabIndex = 19
        Me.btnSend.Text = "送信"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.AutoSize = True
        Me.btnSearch.BackColor = System.Drawing.Color.DarkOrange
        Me.btnSearch.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(155, 27)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(92, 35)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "検 索"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cbbShimei
        '
        Me.cbbShimei.BackColor = System.Drawing.SystemColors.Control
        Me.cbbShimei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbShimei.FormattingEnabled = True
        Me.cbbShimei.Items.AddRange(New Object() {"", "15日", "20日", "末"})
        Me.cbbShimei.Location = New System.Drawing.Point(4, 33)
        Me.cbbShimei.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbbShimei.Name = "cbbShimei"
        Me.cbbShimei.Size = New System.Drawing.Size(60, 25)
        Me.cbbShimei.TabIndex = 8
        '
        'cbbMonth
        '
        Me.cbbMonth.BackColor = System.Drawing.SystemColors.Control
        Me.cbbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbMonth.FormattingEnabled = True
        Me.cbbMonth.Items.AddRange(New Object() {"1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"})
        Me.cbbMonth.Location = New System.Drawing.Point(64, 33)
        Me.cbbMonth.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbbMonth.Name = "cbbMonth"
        Me.cbbMonth.Size = New System.Drawing.Size(85, 25)
        Me.cbbMonth.TabIndex = 7
        '
        'dgvMain
        '
        Me.dgvMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMain.BackgroundColor = System.Drawing.Color.White
        Me.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheck, Me.Code, Me.colCompany, Me.colContact, Me.colEmail, Me.colFiles, Me.colLink})
        Me.dgvMain.Location = New System.Drawing.Point(4, 68)
        Me.dgvMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvMain.Name = "dgvMain"
        Me.dgvMain.RowHeadersVisible = False
        Me.dgvMain.RowTemplate.Height = 21
        Me.dgvMain.Size = New System.Drawing.Size(1111, 344)
        Me.dgvMain.TabIndex = 6
        '
        'txtLocation
        '
        Me.txtLocation.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLocation.Location = New System.Drawing.Point(175, 9)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(415, 24)
        Me.txtLocation.TabIndex = 1
        Me.txtLocation.Text = "file://192.168.1.208/受信fax/70_管理部/★請求書発行"
        '
        'colCheck
        '
        Me.colCheck.HeaderText = ""
        Me.colCheck.Name = "colCheck"
        Me.colCheck.Width = 50
        '
        'Code
        '
        Me.Code.DataPropertyName = "Code"
        Me.Code.HeaderText = "請求先CD"
        Me.Code.Name = "Code"
        Me.Code.Width = 80
        '
        'colCompany
        '
        Me.colCompany.DataPropertyName = "Company"
        Me.colCompany.HeaderText = "請求先名"
        Me.colCompany.Name = "colCompany"
        Me.colCompany.Width = 250
        '
        'colContact
        '
        Me.colContact.DataPropertyName = "Contact"
        Me.colContact.HeaderText = "担当者様"
        Me.colContact.Name = "colContact"
        Me.colContact.Width = 150
        '
        'colEmail
        '
        Me.colEmail.DataPropertyName = "Email"
        Me.colEmail.HeaderText = "メール"
        Me.colEmail.Name = "colEmail"
        Me.colEmail.Width = 250
        '
        'colFiles
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.NavajoWhite
        Me.colFiles.DefaultCellStyle = DataGridViewCellStyle5
        Me.colFiles.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.colFiles.HeaderText = "添付ファイル"
        Me.colFiles.Name = "colFiles"
        Me.colFiles.Text = "選 択"
        Me.colFiles.UseColumnTextForButtonValue = True
        Me.colFiles.Width = 80
        '
        'colLink
        '
        Me.colLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colLink.DataPropertyName = "AddFiles"
        Me.colLink.HeaderText = "ファイルリンク"
        Me.colLink.Name = "colLink"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(1034, 36)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(79, 17)
        Me.LinkLabel1.TabIndex = 20
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "メールマスター"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 547)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents cbbShimei As ComboBox
    Friend WithEvents cbbMonth As ComboBox
    Friend WithEvents dgvMain As DataGridView
    Friend WithEvents btnSend As Button
    Friend WithEvents colCheck As DataGridViewCheckBoxColumn
    Friend WithEvents Code As DataGridViewTextBoxColumn
    Friend WithEvents colCompany As DataGridViewTextBoxColumn
    Friend WithEvents colContact As DataGridViewTextBoxColumn
    Friend WithEvents colEmail As DataGridViewTextBoxColumn
    Friend WithEvents colFiles As DataGridViewButtonColumn
    Friend WithEvents colLink As DataGridViewTextBoxColumn
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
