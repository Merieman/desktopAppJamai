Imports System.Data
Imports Microsoft.VisualBasic.FileIO
Imports System.Windows.Forms
Imports System.IO
Imports System.Globalization





Public Class graph1

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim value As Integer = 0
        Dim dateValue As DateTime = DateTime.MinValue

        ' Determine whether to search by value or date
        If rbValue.IsChecked Then
            ' Try to parse the value entered by the user
            If Not Integer.TryParse(tbSearch.Text, value) Then
                MessageBox.Show("Please enter a valid integer value.")

            End If
        ElseIf rbDate.IsChecked Then
            ' Try to parse the date entered by the user
            If Not DateTime.TryParseExact(tbSearch.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue) Then

                MsgBox("Please enter a valid date in the format yyyy-MM-dd.")
            Else




                Dim dateval As DateTime = DateTime.ParseExact(dateValue.ToString("ddMMyyyy"), "ddMMyyyy", CultureInfo.InvariantCulture)

                ' Allow the user to select the directory where the CSV files are located
                'Dim dialog As New FolderBrowserDialog()
                'If dialog.ShowDialog() = True Then
                Dim directoryPath As String = "C:\Users\acer\Downloads\Report"
                Dim csvFiles As String() = IO.Directory.GetFiles(directoryPath, "*.csv")

                Dim dataTable As New DataTable()
                dataTable.Columns.Add("Ncharge")
                For Each file As String In csvFiles
                    Dim fileName As String = Path.GetFileName(file)

                    ' Detect the delimiter used in the file
                    Dim parser As New TextFieldParser(file)
                    parser.TextFieldType = FieldType.Delimited
                    parser.SetDelimiters(";")
                    Dim columnHeaders As String() = parser.ReadFields()

                    ' Map the column headers to the correct columns in the DataTable
                    Dim nDeCharge As Integer = Array.IndexOf(columnHeaders, "NUMERO DE CHARGE")

                    While Not parser.EndOfData
                        Dim fields As String() = parser.ReadFields()
                        'Dim rowValue As Integer = Integer.Parse(fields(0))
                        Dim rowDate As DateTime = DateTime.ParseExact(fields(4), "ddMMyyyy", CultureInfo.InvariantCulture)
                        Dim valueToCheck As Integer = 123
                        Dim rows() As DataRow = dataTable.Select("Ncharge = " & fields(nDeCharge))

                        If rows.Length > 0 Then
                            ' The value already exists in the DataTable
                        Else
                            If rowDate = dateval Then
                                dataTable.Rows.Add(fields(nDeCharge))
                            End If
                        End If

                    End While

                    parser.Close()
                Next

                ' Display the results in the DataGridView
                dgResults.ItemsSource = dataTable.DefaultView
            End If
        End If

    End Sub




    Private Sub rbValue_Checked(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles rbValue.Checked

        btnSearch.IsEnabled = True

    End Sub

    Private Sub rbDate_Checked(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles rbDate.Checked
        btnSearch.IsEnabled = True
    End Sub

End Class