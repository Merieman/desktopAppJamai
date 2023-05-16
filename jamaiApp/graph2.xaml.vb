Imports LiveCharts
Imports LiveCharts.Wpf
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls

Public Class graph2
    Public Property DataPoints As New ChartValues(Of Double)()
    Public Property TimePoints As New ChartValues(Of DateTime)()

    Public Sub New()
        InitializeComponent()
        DataContext = Me

        ' Pass the selected value to the method
        LoadDataFromCSV("C:\\Users\\acer\\Downloads\\Reports", "10")
    End Sub

    Private Sub LoadDataFromCSV(directoryPath As String, selectedValue As String)
        ' Get the list of CSV files in the directory
        Dim csvFiles() As String = Directory.GetFiles(directoryPath, "*.csv")

        For Each csvFile As String In csvFiles
            ' Read the CSV file
            Dim lines() As String = File.ReadAllLines(csvFile)

            For Each line As String In lines
                Dim values() As String = line.Split(";"c)

                ' Check if the value matches the selected value
                If values(6) = selectedValue Then
                    ' Parse the temperature and time
                    Dim temperature As Double
                    Dim time As DateTime
                    If Double.TryParse(values(0), temperature) AndAlso DateTime.TryParseExact(values(5), "0.00E+00", Nothing, Globalization.DateTimeStyles.None, time) Then
                        ' Add the data points to the collections
                        DataPoints.Add(temperature)
                        TimePoints.Add(time)
                    End If
                End If
            Next
        Next
    End Sub
End Class
