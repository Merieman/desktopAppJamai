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

Public Class home
    Public Property DataPoints As New ChartValues(Of DataPoint)()
    Public Property DataPoints2 As New ChartValues(Of DataPoint)()

    Public Sub New()
        InitializeComponent()
        DataContext = Me
        Charting.For(Of DataPoint)(Mappers.Xy(Of DataPoint)().X(Function(dp) dp.X).Y(Function(dp) dp.Y))
        ' Pass the selected value to the method

        LoadDataFromCSV("\Report")
    End Sub

    Private Sub LoadDataFromCSV(directoryPath As String)
        ' Get the list of CSV files in the directory
        Dim selectedValue As String
        Dim csvFiles() As String = Directory.GetFiles(directoryPath, "*.csv")

        ' Order the files by date in descending order
        Array.Sort(csvFiles, New Comparison(Of String)(Function(x, y) File.GetLastWriteTime(y).CompareTo(File.GetLastWriteTime(x))))

        ' Get the path of the last file (most recent file)
        Dim lastFile As String = csvFiles.FirstOrDefault()
        Dim parser1 As New TextFieldParser(lastFile)
        parser1.TextFieldType = FieldType.Delimited
        parser1.SetDelimiters(";")
        Dim columnHeaders1 As String() = parser1.ReadFields()
        ' Map the column headers to the correct columns in the DataTable
        Dim nDeCharge1 As Integer = Array.IndexOf(columnHeaders1, "NUMERO DE CHARGE")
        Dim fields1 As String() = parser1.ReadFields()
        Dim rowValue1 As Integer = Integer.Parse(fields1(nDeCharge1))
        selectedValue = rowValue1

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




        Next
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
