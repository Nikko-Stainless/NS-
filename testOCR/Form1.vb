Imports System.IO
Imports System.Text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports System.Text.RegularExpressions
Imports System.Net.Mail

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSeikyusaki.Focus()

        Dim currentMonth As Integer = DateTime.Now.Month
        cbbMonth.SelectedIndex = currentMonth - 1
    End Sub

#Region "①PDF名変換"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim folderPath As String = txtLocation.Text
        Dim pdfFiles As String() = Directory.GetFiles(folderPath, "*.pdf")

        For Each pdfPath As String In pdfFiles
            ' PDFファイルの内容を読み込む
            Dim pdfContent As String = ReadPdfFile(pdfPath)

            Dim result As String = ""
            If pdfContent.StartsWith("発行日") Then
                result = SummaryInvoice(pdfContent)

            ElseIf pdfContent.StartsWith("登録番号") Then
                result = DetailInvoice(pdfContent)
            End If

            If Not String.IsNullOrEmpty(result) Then
                ' 新しいファイル名を生成（無効な文字は削除）
                result = ReplaceInvalidCharacters(result)
                Dim newFileName As String = result.Trim()
                Dim newFilePath As String = IO.Path.Combine(IO.Path.GetDirectoryName(pdfPath), newFileName & ".pdf")

                ' 新しいファイル名が既に存在する場合、番号を追加
                Dim counter As Integer = 1
                While File.Exists(newFilePath)
                    newFileName = result.Trim() & "(" & counter.ToString() & ")"
                    newFilePath = IO.Path.Combine(IO.Path.GetDirectoryName(pdfPath), newFileName & ".pdf")
                    counter += 1
                End While

                ' ファイルをリネーム（名前変更）
                Try
                    File.Move(pdfPath, newFilePath)
                Catch ex As Exception
                    Continue For
                End Try
            End If
        Next
    End Sub
    ' PDFファイルの内容を読み取る関数
    Function ReadPdfFile(pdfPath As String) As String
        Dim text As New StringBuilder()

        Try
            Using pdfReader As New PdfReader(pdfPath)
                ' 各ページの内容を取得（1ページのみを対象）
                text.AppendLine(PdfTextExtractor.GetTextFromPage(pdfReader, 1))
            End Using
        Catch ex As Exception
            MessageBox.Show("エラー: " & ex.Message)
        End Try

        Return text.ToString()
    End Function

    ' 詳細請求書の内容から5桁の会社コードと会社名を抽出する関数
    Function DetailInvoice(pdfContent As String) As String
        ' 余分な空白を除去
        pdfContent = Regex.Replace(pdfContent, "\s+", " ")

        ' 「請求書」前の5桁の番号を取得する正規表現
        Dim companyCodePattern As String = "(\d{5})(?=\s*請\s*求\s*書)"

        ' 「御 中」前の会社名を取得する正規表現
        Dim companyNamePattern As String = "(?<=分\)\s)(.*?)(?=\s*御\s*中)"

        ' 会社コードを抽出
        Dim companyCodeMatch As Match = Regex.Match(pdfContent, companyCodePattern)

        ' 会社名を抽出
        Dim companyNameMatch As Match = Regex.Match(pdfContent, companyNamePattern)

        ' 両方の情報が見つかった場合
        If companyCodeMatch.Success AndAlso companyNameMatch.Success Then
            ' 5桁の会社コードと会社名を返す
            Return companyCodeMatch.Value & " " & ConvertToHalfWidth(companyNameMatch.Value.Trim())
        Else
            ' 情報が見つからない場合
            Return String.Empty
        End If
    End Function

    ' サマリー請求書の内容から5桁の会社コードと会社名を抽出する関数
    Function SummaryInvoice(pdfContent As String) As String
        ' 余分な空白を除去
        pdfContent = Regex.Replace(pdfContent, "\s+", " ")

        ' 〒マークから始まり、5桁の数字で終わるコードを抽出
        Dim companyCodePattern As String = "(?<=〒)([0-9\s\-]+)(?=[\u4e00-\u9faf])"

        ' 「御 中」前の会社名を取得する正規表現
        Dim companyNamePattern As String = "(?<=（内消費税）)(.*?)(?=御\s*中)"

        ' 会社コードを抽出
        Dim companyCodeMatch As Match = Regex.Match(pdfContent, companyCodePattern)

        ' 会社名を抽出
        Dim companyNameMatch As Match = Regex.Match(pdfContent, companyNamePattern)

        ' 両方の情報が見つかった場合
        If companyCodeMatch.Success AndAlso companyNameMatch.Success Then
            ' 5桁の会社コードと会社名を返す
            Dim companyCode = companyCodeMatch.Value.Trim()
            Return companyCode.Substring(companyCode.Length - 5) & " " & ConvertToHalfWidth(companyNameMatch.Value.Trim())
        Else
            Return String.Empty
        End If
    End Function

    ' 全角文字を半角文字に変換する関数
    Function ConvertToHalfWidth(input As String) As String
        Return input.Normalize(NormalizationForm.FormKC)
    End Function

    ' 無効なファイル名の文字を置換する関数
    Private Function ReplaceInvalidCharacters(fileName As String) As String
        ' Windowsで使用できない文字をスペースに置換
        For Each invalidChar In IO.Path.GetInvalidFileNameChars()
            fileName = fileName.Replace(invalidChar, " "c)
        Next

        Return fileName
    End Function

#End Region
#Region "②送信"
    ' Chỉ cho phép nhập số trong txtSeikyusaki
    Private Sub txtSeikyusaki_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSeikyusaki.KeyPress
        ' Kiểm tra nếu ký tự không phải là số hoặc không phải phím điều khiển như Backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Loại bỏ ký tự nếu không phải số
        End If
    End Sub

    ' Tự động thêm số 0 vào trước dãy số nếu không đủ 5 chữ số khi nhấn Enter
    Private Sub txtSeikyusaki_Validated() Handles txtSeikyusaki.Validated
        txtSeikyusaki.Text = txtSeikyusaki.Text.PadLeft(5, "0"c)
    End Sub

    Private Sub txtSeikyusaki_TextChanged(sender As Object, e As EventArgs) Handles txtSeikyusaki.TextChanged
        ' Kiểm tra nếu chuỗi đủ 5 ký tự
        If txtSeikyusaki.Text.Length = 5 Then
            ' Gọi hàm tìm kiếm với giá trị trong txtSeikyusaki
            Dim searchKey As String = txtSeikyusaki.Text
            SearchData(searchKey)
        End If
    End Sub

    Private Sub SearchData(searchKey As String)
        If LoadFileini() Is Nothing Then Return
        Dim result = LoadFileini()
        txtKaishamei.Text = result(1)
        txtTantou.Text = result(2)
        txtAddress.Text = result(3)
        txtFile.Text = ""
        Button2.Enabled = True
    End Sub
    Private Function LoadFileini() As String()
        Dim fileINI = Application.StartupPath + "\settingApp\mailSetting.ini"

        If Not IO.File.Exists(fileINI) Then Return Nothing

        Dim lines As String() = IO.File.ReadAllLines(fileINI)

        For Each line As String In lines
            Dim values = line.Split("/")
            Dim key = values(0)
            If txtSeikyusaki.Text = key Then
                Return values
            End If
        Next
        Return Nothing
    End Function

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.InitialDirectory = txtLocation.Text
        ' Lọc chỉ hiển thị file PDF
        openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
        openFileDialog.Title = "Chọn file PDF"

        ' Hiển thị hộp thoại và kiểm tra nếu người dùng đã chọn một file
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Lấy đường dẫn file đã chọn
            Dim selectedFilePath As String = openFileDialog.FileName
            txtFile.Text += selectedFilePath + ","
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrEmpty(txtKaishamei.Text) OrElse String.IsNullOrEmpty(txtAddress.Text) Then Return
        If sendNotificationOnly() Then
            MessageBox.Show("メールを送信しました。")
            Button2.Enabled = False
            txtSeikyusaki.Focus()
        End If
    End Sub
    Public Function sendNotificationOnly() As Boolean
        Try
            Dim MailAddress = "robot01@nikko-sus.co.jp"
            Dim password = "3Bi0x21Qea5qOPFu"
            Dim host = "smtp.nikko-sus.co.jp"

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(MailAddress, password)

            Smtp_Server.Port = 587
            Smtp_Server.Host = host

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(MailAddress)

            e_mail.To.Add(txtAddress.Text)
            e_mail.Subject = "【日鋼ステンレス】" + txtKaishamei.Text + " 様 請求書"

            '"分の納品書送信 日鋼ステンレス" 
            e_mail.IsBodyHtml = False
            e_mail.Body = txtKaishamei.Text + " 御中" + vbNewLine + txtTantou.Text.Replace(",", vbNewLine).Replace("、", vbNewLine) + vbNewLine + vbNewLine +
                         "いつも大変お世話になっております。" + vbNewLine + vbNewLine +
                         cbbMonth.SelectedItem.ToString() + "分請求書が発行できましたので送付致します。" + vbNewLine + "御確認宜しくお願い致します。" + vbNewLine + vbNewLine +
                 "□■━━━━━━━━━━━━━━━━━━
  日鋼ステンレス株式会社
  管 理 部　 　山本 洋子
  TEL：06-6475-0950
　FAX：06-6475-0920
  Email:y.yamamoto@nikko-sus.co.jp
━━━━━━━━━━━━━━━━━━■□"
            Dim files() As String = txtFile.Text.Split(",")
            If files.Count = 1 Then '添付ファイルがないとき送信なし
                MessageBox.Show("添付ファイルを選択してください。")
                Return False
            End If

            For Each sFile As String In files
                If String.IsNullOrEmpty(sFile) Then Continue For
                Dim AttachmentFile As Net.Mail.Attachment = New Net.Mail.Attachment(sFile)
                e_mail.Attachments.Add(AttachmentFile)
            Next

            Try
                Smtp_Server.Send(e_mail)
            Catch ex As SmtpFailedRecipientsException
                Dim i As Int32
                For i = 0 To i < ex.InnerExceptions.Length
                    Dim status As SmtpStatusCode = ex.InnerExceptions(i).StatusCode
                    If status = SmtpStatusCode.MailboxBusy Or status = SmtpStatusCode.MailboxUnavailable Then
                        System.Threading.Thread.Sleep(5000)
                        Smtp_Server.Send(e_mail)
                    Else
                        Return False
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                Return False
            Finally
                e_mail.Dispose()
            End Try

            Return True
        Catch error_t As Exception
            MessageBox.Show(error_t.ToString())
            Return False
        End Try
    End Function

    Private Sub txtSeikyusaki_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSeikyusaki.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.Focus()
            e.Handled = True
        End If
    End Sub
#End Region

End Class
