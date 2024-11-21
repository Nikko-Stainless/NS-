Imports System.IO
Imports System.Text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports System.Text.RegularExpressions
Imports System.Net.Mail

Public Class Form1
    Dim fileINI = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentMonth As Integer = DateTime.Now.Month
        cbbMonth.SelectedIndex = currentMonth - 1
        fileINI = Application.StartupPath + "\settingApp\mailSetting.ini"
        cbbShimei.SelectedIndex = 0
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
        MessageBox.Show("変換しました。")
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
            Return companyCodeMatch.Value & " " & ConvertToHalfWidth(companyNameMatch.Value.Trim().Replace(" ", ""))
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
            Return companyCode.Substring(companyCode.Length - 5) & " " & ConvertToHalfWidth(companyNameMatch.Value.Trim().Replace(" ", ""))
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
        For Each invalidChar In IO.Path.GetInvalidFileNameChars()
            fileName = fileName.Replace(invalidChar, " "c)
        Next

        Return fileName
    End Function
#End Region
#Region "②送信"
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If IO.File.Exists(fileINI) Then
            Process.Start(fileINI)
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim data = LoadFileini(cbbShimei.SelectedItem.ToString)
        dgvMain.AutoGenerateColumns = False
        dgvMain.DataSource = data
    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim isFLGSend As Boolean = False
        For i = 0 To dgvMain.Rows.Count - 1
            If dgvMain.Rows(i).Cells("colCheck").Value = True Then
                Dim mail = dgvMain.Rows(i).Cells("colEmail").Value.ToString()
                If String.IsNullOrEmpty(mail) Then
                    MessageBox.Show("メールアドレスを入力してください")
                    Return
                End If

                Dim kaisha = dgvMain.Rows(i).Cells("colCompany").Value.ToString()
                If String.IsNullOrEmpty(kaisha) Then
                    MessageBox.Show("請求先名を入力してください")
                    Return
                End If

                Dim tantou = dgvMain.Rows(i).Cells("colContact").Value.ToString()
                Dim files = dgvMain.Rows(i).Cells("colLink").Value.ToString()
                If String.IsNullOrEmpty(files) Then
                    MessageBox.Show("ファイルを選択してください")
                    Return
                End If

                files = files.Substring(files.IndexOf("]") + 1)
                If sendMail(mail, kaisha, tantou, files) Then
                    dgvMain.Rows(i).Cells("colCheck").Value = False
                End If

                isFLGSend = True
            End If
        Next
        If isFLGSend Then MessageBox.Show("メールを送信しました。")
    End Sub

    Private Function LoadFileini(isKey As String) As DataTable
        If Not IO.File.Exists(fileINI) Then Return Nothing
        Dim lines As String() = IO.File.ReadAllLines(fileINI)
        Dim captureData As Boolean = False

        Dim dataTable As New DataTable()
        dataTable.Columns.Add("Code", GetType(String))
        dataTable.Columns.Add("Company", GetType(String))
        dataTable.Columns.Add("Contact", GetType(String))
        dataTable.Columns.Add("Email", GetType(String))

        For Each line As String In lines
            ' [15日], [20日], hoặc [末]
            If line.Trim().StartsWith("[") AndAlso line.Trim().EndsWith("]") Then
                captureData = (isKey = "" OrElse line.Trim() = "[" + isKey + "]")
            ElseIf captureData Then
                If Not String.IsNullOrWhiteSpace(line) Then

                    Dim values = line.Split("/"c)
                    If values.Length = 4 Then
                        dataTable.Rows.Add(values(0).Trim(), values(1).Trim(), values(2).Trim(), values(3).Trim())
                    End If
                End If
            End If
        Next

        Return If(dataTable.Rows.Count > 0, dataTable, Nothing)
    End Function

    Private Sub dgvMain_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMain.CellClick
        If e.ColumnIndex = dgvMain.Columns("colFiles").Index AndAlso e.RowIndex >= 0 Then
            Dim openFileDialog As New OpenFileDialog()

            openFileDialog.Multiselect = True
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
            openFileDialog.Title = "Chọn file PDF"
            If Not String.IsNullOrEmpty(txtLocation.Text) Then
                openFileDialog.InitialDirectory = txtLocation.Text

            End If

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedFiles As String() = openFileDialog.FileNames
                Dim fileLinks As String = "[Files: " + selectedFiles.Count.ToString() + "]" + String.Join(",", selectedFiles)

                dgvMain.Rows(e.RowIndex).Cells("colLink").Value = fileLinks
                dgvMain.Rows(e.RowIndex).Cells("colCheck").Value = True
            End If
        End If
    End Sub

    Public Function sendMail(isMail As String, isKaisha As String, isTantou As String, isFiles As String) As Boolean
        Try
            Dim MailAddress = "keiri@nikko-sus.co.jp"
            Dim password = "pegupegu1"
            Dim host = "smtp.nikko-sus.co.jp"

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(MailAddress, password)

            Smtp_Server.Port = 587
            Smtp_Server.Host = host

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(MailAddress)

            e_mail.To.Add(isMail)
            e_mail.Subject = "【日鋼ステンレス】" + isKaisha + " 様 請求書"

            e_mail.IsBodyHtml = False
            e_mail.Body = isKaisha + " 御中" + vbNewLine + isTantou.Replace(",", vbNewLine).Replace("、", vbNewLine) + vbNewLine + vbNewLine +
                         "いつも大変お世話になっております。" + vbNewLine + vbNewLine +
                         cbbMonth.SelectedItem.ToString() + "分請求書が発行できましたので送付致します。" + vbNewLine + "御確認宜しくお願い致します。" + vbNewLine + vbNewLine +
                 "□■━━━━━━━━━━━━━━━━━━
      日鋼ステンレス株式会社
      管 理 部　 　山本 洋子
      TEL：06-6475-0950
    　FAX：06-6475-0920
      Email:y.yamamoto@nikko-sus.co.jp
    ━━━━━━━━━━━━━━━━━━■□"
            Dim files() As String = isFiles.Split(",")

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


#End Region

End Class
