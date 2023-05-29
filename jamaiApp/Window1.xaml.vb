Public Class Window1






    Private Sub Button1_Click_1(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        four = "SOLO"
        Dim homepage As New home()
        homepage.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button2.Click
        four = "IPSEN"
        Dim homepage As New home()
        homepage.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button3.Click
        four = "REVENU"
        Dim homepage As New home()
        homepage.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button4.Click
        four = "ALUMINIUM"
        Dim homepage As New home()
        homepage.Show()
        Me.Hide()
    End Sub

    Private Sub MenuItem1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles MenuItem1.Click
        Dim login As New MainWindow()
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Window1_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        solo_b.BorderBrush = New SolidColorBrush(Colors.Red)

    End Sub



    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim second1 As New second
        second1.Show()
        Me.Hide()
    End Sub
End Class
