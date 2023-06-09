Imports LiveCharts
Imports LiveCharts.Wpf
Imports Microsoft.VisualBasic.FileIO
Imports System.Data
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports LiveCharts.Configurations
Imports MS.Internal.Xaml
Imports Npgsql
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class home
    Public Property DataPoints As New ChartValues(Of DataPoint)()
    Public Property DataPoints2 As New ChartValues(Of DataPoint)()

    Public Sub New()

        InitializeComponent()
        DataContext = Me
        Charting.For(Of DataPoint)(Mappers.Xy(Of DataPoint)().X(Function(dp) dp.X).Y(Function(dp) dp.Y))
        ' Pass the selected value to the method

        LoadDataFromDataBase("C:\rep")

    End Sub
    Private Sub insertdb()
        Dim csvFiles() As String = Directory.GetFiles("C:\rep", "*.csv")
        Dim i As Integer = 0


        cnx.Open()

        Dim transaction As NpgsqlTransaction = cnx.BeginTransaction()
        Try
            Dim cmd As New NpgsqlCommand()
            cmd.Connection = cnx
            cmd.Transaction = transaction
            cmd.CommandType = CommandType.Text
            For Each csvFile As String In csvFiles
                ' Read the CSV file using TextFieldParser
                Dim parser As New TextFieldParser(csvFile)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(";")
                Dim headerFields As String() = parser.ReadFields() ' Skip the header line

                While Not parser.EndOfData
                    Dim fields As String() = parser.ReadFields()

                    ' Insert data into PostgreSQL table
                    cmd.CommandText = "INSERT INTO public.testcsv (""numero de charge"", date, heure, consigne, temperature) VALUES (@Column1, @Column2, @Column3 , @Column4, @Column5)"

                    cmd.Parameters.AddWithValue("@Column1", fields(6))
                    cmd.Parameters.AddWithValue("@Column2", fields(4))
                    cmd.Parameters.AddWithValue("@Column3", fields(5))
                    cmd.Parameters.AddWithValue("@Column4", fields(2))
                    cmd.Parameters.AddWithValue("@Column5", fields(0))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()

                    i += 1
                End While

            Next
            transaction.Commit()
            MessageBox.Show("Data inserted successfully.")

        Catch ex As NpgsqlException
            transaction.Rollback()
            MessageBox.Show("PostgreSQL Error: " & ex.Message & vbCrLf & "SQL State: ")
        Catch ex As Exception
            transaction.Rollback()
            MessageBox.Show("Error inserting data: " & ex.Message)

        End Try


        cnx.Close()

    End Sub

    Private Sub LoadDataFromDataBase(directoryPath As String)
        insertdb()
        ' Get the list of CSV files in the directory
        If cnx.State = ConnectionState.Closed Then
            cnx.Open()
        End If
        str = "SELECT heure, temperature, consigne,""numero de charge"" FROM public.testcsv WHERE   ""numero de charge""::INTEGER = (    SELECT MAX(""numero de charge""::INTEGER) FROM public.testcsv);"
        If reader IsNot Nothing AndAlso Not reader.IsClosed Then
            reader.Close()
        End If
        cmd = New NpgsqlCommand(str, cnx)
        reader = cmd.ExecuteReader()
        Dim tempChange As String = "test temperature"
        While reader.Read()
            Dim heure As String = reader.GetString(0)
            Dim temperature As String = reader.GetString(1)
            Dim consigne As String = reader.GetString(2)
            Dim nDeCharge As String = reader.GetString(3)
            Dim h As Double = Double.Parse(heure) / Double.Parse(1000000000)
            If tempChange <> temperature Then
                DataPoints.Add(New DataPoint(h, Double.Parse(temperature)))
                DataPoints2.Add(New DataPoint(h, Double.Parse(consigne)))
                tempChange = temperature
            End If


            'Dim timeString As String = heure
            'Dim timeValue As Double = Double.Parse(heure)
            'Dim dateTimeValue As DateTime = DateTime.FromOADate(timeValue)
            consigne1.Content = "Consigne: " + consigne
            n_charge.Content = "Numéro de charge: " + nDeCharge
        End While
        reader.Close()
        cnx.Close()
        'Dim selectedValue As String
        'Dim csvFiles() As String = Directory.GetFiles(directoryPath, "*.csv")

        '' Order the files by date in descending order
        'Array.Sort(csvFiles, New Comparison(Of String)(Function(x, y) File.GetLastWriteTime(y).CompareTo(File.GetLastWriteTime(x))))

        '' Get the path of the last file (most recent file)
        'Dim lastFile As String = csvFiles.FirstOrDefault()
        'Dim parser1 As New TextFieldParser(lastFile)
        'parser1.TextFieldType = FieldType.Delimited
        'parser1.SetDelimiters(";")
        'Dim columnHeaders1 As String() = parser1.ReadFields()
        '' Map the column headers to the correct columns in the DataTable
        'Dim nDeCharge1 As Integer = Array.IndexOf(columnHeaders1, "NUMERO DE CHARGE")
        'Dim fields1 As String() = parser1.ReadFields()
        'Dim rowValue1 As Integer = Integer.Parse(fields1(nDeCharge1))
        'selectedValue = rowValue1

        'For Each csvFile As String In csvFiles
        '    ' Detect the delimiter used in the file
        '    Dim parser As New TextFieldParser(csvFile)
        '    parser.TextFieldType = FieldType.Delimited
        '    parser.SetDelimiters(";")
        '    Dim columnHeaders As String() = parser.ReadFields()
        '    ' Map the column headers to the correct columns in the DataTable
        '    Dim nDeCharge As Integer = Array.IndexOf(columnHeaders, "NUMERO DE CHARGE")
        '    Dim temperature As Integer = Array.IndexOf(columnHeaders, "TEMPERATURE PIECE")
        '    Dim heure As Integer = Array.IndexOf(columnHeaders, "HEURE")
        '    Dim consigne As Integer = Array.IndexOf(columnHeaders, "CONSIGNE1")


        '    While Not parser.EndOfData
        '        Dim fields As String() = parser.ReadFields()
        '        Dim rowValue As Integer = Integer.Parse(fields(nDeCharge))
        '        If rowValue = selectedValue Then

        '            Dim h As Double = Double.Parse(fields(heure)) / Double.Parse(1000000000)

        '            DataPoints.Add(New DataPoint(h, Double.Parse(fields(temperature))))
        '            DataPoints2.Add(New DataPoint(h, Double.Parse(fields(consigne))))

        '            Dim timeString As String = fields(heure)
        '            Dim timeValue As Double = Double.Parse(heure)
        '            Dim dateTimeValue As DateTime = DateTime.FromOADate(timeValue)
        '            n_charge.Content = "Numéro de charge: " + fields(nDeCharge)
        '            consigne1.Content = "Consigne: " + fields(consigne)

        '        End If
        '    End While




        'Next

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim graph As New graph1
        graph.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim Home As New home
        Home.Show()
        Me.Hide()

    End Sub

    Private Sub Window_Loaded(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Label1.Content = four

    End Sub


    Private Sub MenuItem1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles MenuItem1.Click
        Dim login As New MainWindow()
        login.Show()
        Me.Hide()
    End Sub


    Private Sub Button3_Click_1(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button3.Click
        Dim choose As New Window1()
        choose.Show()
        Me.Hide()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
