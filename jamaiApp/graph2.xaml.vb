Imports LiveCharts
Imports LiveCharts.Wpf
Imports Microsoft.VisualBasic.FileIO
Imports System.Data
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports LiveCharts.Configurations
Imports Npgsql

Public Class graph2
    Public Property DataPoints As New ChartValues(Of DataPoint)()
    Public Property DataPoints2 As New ChartValues(Of DataPoint)()

    Public Sub New()
        InitializeComponent()
        DataContext = Me
        Charting.For(Of DataPoint)(Mappers.Xy(Of DataPoint)().X(Function(dp) dp.X).Y(Function(dp) dp.Y))
        ' Pass the selected value to the method
        LoadDataFromCSV("\reports", nCharge)
    End Sub

    Private Sub LoadDataFromCSV(directoryPath As String, selectedValue As String)
        If cnx.State = ConnectionState.Closed Then
            cnx.Open()
        End If
        Dim nchargeValue As Integer
        If Integer.TryParse(nCharge, nchargeValue) Then
            str = "SELECT heure, temperature, consigne, ""numero de charge"" FROM public.testcsv WHERE ""numero de charge""::INTEGER = @ncharge"

            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If
            cmd = New NpgsqlCommand(str, cnx)
            cmd.Parameters.AddWithValue("@ncharge", nchargeValue)
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
        End If
        '' Get the list of CSV files in the directory
        'Dim csvFiles() As String = Directory.GetFiles(directoryPath, "*.csv")

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

        '            'Dim timeString As String = fields(heure)
        '            'Dim timeValue As Double = Double.Parse(heure)
        '            'Dim dateTimeValue As DateTime = DateTime.FromOADate(timeValue)

        '            n_charge.Content = "Numéro de charge: " + fields(nDeCharge)
        '            consigne1.Content = "Consigne: " + fields(consigne)
        '        End If
        '    End While




        'Next
    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As RoutedEventArgs) Handles MenuItem1.Click
        Dim decon As New MainWindow
        decon.Show()
        Me.Hide()
        test = 0
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim gr As New graph1
        gr.Show()
        Me.Hide()
        test = 0
    End Sub
End Class
Public Class DataPoint
    Public Property X As Double
    Public Property Y As Double

    Public Sub New(x As Double, y As Double)
        Me.X = x
        Me.Y = y
    End Sub
End Class
