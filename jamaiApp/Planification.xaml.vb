Class Planification


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As RoutedEventArgs) Handles MenuItem1.Click
        Dim login As New MainWindow()
        login.Show()
        Me.Hide()
    End Sub



    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim second1 As New second
        second1.Show()
        Me.Hide()
    End Sub
End Class
