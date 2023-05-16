Public Class home

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

    Private Sub Image1_ImageFailed(sender As System.Object, e As System.Windows.ExceptionRoutedEventArgs) Handles Image1.ImageFailed

    End Sub

    Private Sub MenuItem1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles MenuItem1.Click
        Dim login As New MainWindow()
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button3.Click
        Dim choose As New Window1()
        choose.Show()
        Me.Hide()
    End Sub
End Class
