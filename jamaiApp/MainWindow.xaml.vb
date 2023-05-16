Class MainWindow 

    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim choose As New Window1
        choose.Show()
        Me.Hide()

    End Sub
End Class
