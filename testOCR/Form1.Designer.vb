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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.txtKaishamei = New System.Windows.Forms.TextBox()
        Me.txtTantou = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbbMonth = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSeikyusaki = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Bisque
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(16, 24)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "①請求書の名前へ変換"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Linen
        Me.GroupBox1.Controls.Add(Me.btnFile)
        Me.GroupBox1.Controls.Add(Me.txtKaishamei)
        Me.GroupBox1.Controls.Add(Me.txtTantou)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbbMonth)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.txtFile)
        Me.GroupBox1.Controls.Add(Me.txtAddress)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSeikyusaki)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(647, 234)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "②メール送信"
        '
        'btnFile
        '
        Me.btnFile.BackColor = System.Drawing.Color.Bisque
        Me.btnFile.ForeColor = System.Drawing.Color.Black
        Me.btnFile.Location = New System.Drawing.Point(3, 159)
        Me.btnFile.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(87, 26)
        Me.btnFile.TabIndex = 11
        Me.btnFile.Text = "添付ファイル"
        Me.btnFile.UseVisualStyleBackColor = False
        '
        'txtKaishamei
        '
        Me.txtKaishamei.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtKaishamei.Location = New System.Drawing.Point(180, 56)
        Me.txtKaishamei.MaxLength = 5
        Me.txtKaishamei.Name = "txtKaishamei"
        Me.txtKaishamei.Size = New System.Drawing.Size(348, 24)
        Me.txtKaishamei.TabIndex = 10
        '
        'txtTantou
        '
        Me.txtTantou.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTantou.Location = New System.Drawing.Point(96, 89)
        Me.txtTantou.MaxLength = 5
        Me.txtTantou.Name = "txtTantou"
        Me.txtTantou.Size = New System.Drawing.Size(533, 24)
        Me.txtTantou.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "担当者"
        '
        'cbbMonth
        '
        Me.cbbMonth.BackColor = System.Drawing.SystemColors.Control
        Me.cbbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbMonth.FormattingEnabled = True
        Me.cbbMonth.Items.AddRange(New Object() {"1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"})
        Me.cbbMonth.Location = New System.Drawing.Point(96, 9)
        Me.cbbMonth.Name = "cbbMonth"
        Me.cbbMonth.Size = New System.Drawing.Size(95, 25)
        Me.cbbMonth.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Bisque
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(522, 186)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 40)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "送信"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(96, 159)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(533, 24)
        Me.txtFile.TabIndex = 6
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(96, 122)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(533, 24)
        Me.txtAddress.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "メールアドレス"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "請求先CD"
        '
        'txtSeikyusaki
        '
        Me.txtSeikyusaki.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSeikyusaki.Location = New System.Drawing.Point(96, 56)
        Me.txtSeikyusaki.MaxLength = 5
        Me.txtSeikyusaki.Multiline = True
        Me.txtSeikyusaki.Name = "txtSeikyusaki"
        Me.txtSeikyusaki.Size = New System.Drawing.Size(78, 24)
        Me.txtSeikyusaki.TabIndex = 1
        '
        'txtLocation
        '
        Me.txtLocation.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLocation.Location = New System.Drawing.Point(179, 29)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(317, 24)
        Me.txtLocation.TabIndex = 1
        Me.txtLocation.Text = "C:\"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 321)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFile As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSeikyusaki As TextBox
    Friend WithEvents cbbMonth As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents txtTantou As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtKaishamei As TextBox
    Friend WithEvents btnFile As Button
End Class
