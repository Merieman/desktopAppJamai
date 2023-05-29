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
Imports System.Windows.Forms

Public Class CreationCharge


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
    Private Sub Button2_Copy_Click(sender As Object, e As RoutedEventArgs) Handles Button2_Copy.Click
        Dim charge As New CreationCharge

        charge.Show()
        Me.Hide()
    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As RoutedEventArgs)
        Dim openFileDialog As New OpenFileDialog()
        If openFileDialog.ShowDialog() = True Then
            Dim selectedFilePath As String = openFileDialog.FileName
            ' Do something with the selected file path
            ' For example, display it in a TextBox or Label

        End If
    End Sub
    Private Sub HourComboBox_Loaded(sender As Object, e As RoutedEventArgs)
        Dim currentHour As Integer = DateTime.Now.Hour
        hourComboBox.ItemsSource = {currentHour}
        hourComboBox.SelectedIndex = 0

    End Sub
    Private Sub MinuteComboBox_Loaded(sender As Object, e As RoutedEventArgs)
        Dim currentMinute As Integer = DateTime.Now.Minute
        minuteComboBox.ItemsSource = {currentMinute.ToString("D2")}
        minuteComboBox.SelectedIndex = 0
    End Sub
End Class