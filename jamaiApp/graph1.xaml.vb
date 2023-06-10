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
            ElseIf test = 0 Then
                nCharge = tbSearch.Text
                test = 1
                Dim graphi As New graph2
                graphi.Show()
                Me.Hide()
            End If
        ElseIf rbDate.IsChecked Then
            dgResults.Visibility = Visibility.Visible
            ' Try to parse the date entered by the user
            If Not DateTime.TryParseExact(tbSearch.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, dateValue) Then

                MsgBox("Please enter a valid date in the format yyyy-MM-dd.")
            Else




                Dim dateval As DateTime = DateTime.ParseExact(dateValue.ToString("ddMMyyyy"), "ddMMyyyy", CultureInfo.InvariantCulture)

                ' Allow the user to select the directory where the CSV files are located
                'Dim dialog As New FolderBrowserDialog()
                'If dialog.ShowDialog() = True Then
                Dim directoryPath As String = "C:\reports"
                Dim csvFiles As String() = IO.Directory.GetFiles(directoryPath, "*.csv")

                Dim dataTable As New DataTable()
                dataTable.Columns.Add("Ncharge")
                For Each file As String In csvFiles
                    'Dim fileName As String = Path.GetFileName(file)

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
                        'Dim valueToCheck As Integer = 123
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



    Private Sub MenuItem1_Click(sender As Object, e As RoutedEventArgs) Handles MenuItem1.Click
        Dim decon As New MainWindow
        decon.Show()
        Me.Hide()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim homepage As New home()
        homepage.Show()
        Me.Hide()
    End Sub

    Private Sub dgResults_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dgResults.SelectionChanged
        If test = 0 Then
            Dim selectedItem As Object = dgResults.SelectedItem
            If TypeOf selectedItem Is System.Data.DataRowView Then
                ' Cast the selected item to System.Data.DataRowView
                Dim dataRowView As System.Data.DataRowView = DirectCast(selectedItem, System.Data.DataRowView)

                ' Access the desired property from the DataRowView
                Dim selectedValue As String = dataRowView("Ncharge").ToString()
                nCharge = selectedValue
                test = 1
                Dim graphi As New graph2
                graphi.Show()
                Me.Hide()
            End If
        End If
    End Sub
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        user1.Header = usera
    End Sub


End Class