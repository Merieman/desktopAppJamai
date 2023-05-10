Class MainWindow 

    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim window2 As New Window2()
        window2.Show()
        Me.Hide()

    End Sub
End Class
