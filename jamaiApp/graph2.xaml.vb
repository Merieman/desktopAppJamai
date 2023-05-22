Imports LiveCharts
Imports LiveCharts.Wpf
Imports Microsoft.VisualBasic.FileIO
Imports System.Data
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports LiveCharts.Configurations

Public Class graph2
    Public Property DataPoints As New ChartValues(Of DataPoint)()
    Public Property DataPoints2 As New ChartValues(Of DataPoint)()

    Public Sub New()
        InitializeComponent()
        DataContext = Me
        Charting.For(Of DataPoint)(Mappers.Xy(Of DataPoint)().X(Function(dp) dp.X).Y(Function(dp) dp.Y))
        ' Pass the selected value to the method
        LoadDataFromCSV("C:\\Users\\acer\\Downloads\\Report", nCharge)
    End Sub

    Private Sub LoadDataFromCSV(directoryPath As String, selectedValue As String)
        ' Get the list of CSV files in the directory
        Dim csvFiles() As String = Directory.GetFiles(directoryPath, "*.csv")

        For Each csvFile As String In csvFiles
            ' Detect the delimiter used in the file
            Dim parser As New TextFieldParser(csvFile)
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(";")
            Dim columnHeaders As String() = parser.ReadFields()
            ' Map the column headers to the correct columns in the DataTable
            Dim nDeCharge As Integer = Array.IndexOf(columnHeaders, "NUMERO DE CHARGE")
            Dim temperature As Integer = Array.IndexOf(columnHeaders, "TEMPERATURE PIECE")
            Dim heure As Integer = Array.IndexOf(columnHeaders, "HEURE")
            Dim consigne As Integer = Array.IndexOf(columnHeaders, "CONSIGNE1")


            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()
                Dim rowValue As Integer = Integer.Parse(fields(nDeCharge))
                If rowValue = selectedValue Then

                    Dim h As Double = Double.Parse(fields(heure)) / Double.Parse(1000000000)

                    DataPoints.Add(New DataPoint(h, Double.Parse(fields(temperature))))
                    DataPoints2.Add(New DataPoint(h, Double.Parse(fields(consigne))))

                    Dim timeString As String = fields(heure)
                    Dim timeValue As Double = Double.Parse(heure)
                    Dim dateTimeValue As DateTime = DateTime.FromOADate(timeValue)

                    n_charge.Content = "Numéro de charge: " + fields(nDeCharge)
                    consigne1.Content = "Consigne: " + fields(consigne)
                End If
            End While



            ' Read the CSV file
            'Dim lines() As String = File.ReadAllLines(csvFile)

            'For Each line As String In lines
            '    Dim values() As String = line.Split(";"c)

            '    ' check if the value matches the selected value
            '    If values(6) = selectedValue Then
            '        ' parse the temperature and time
            '        'dim temperature as double
            '        Dim time As DateTime
            '        If Double.TryParse(values(0), temperature) AndAlso DateTime.TryParseExact(values(5), "0.00e+00", Nothing, Globalization.DateTimeStyles.None, time) Then
            '            ' add the data points to the collections
            '            DataPoints.Add(temperature)
            '            TimePoints.Add(time)
            '        End If
            '    End If
            'Next
        Next
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
