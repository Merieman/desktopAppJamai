Imports System.Windows.Navigation
Class second
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        user1.Header = usera
        If fonct1 <> "admin" Then
            bt_perso.IsEnabled = False
            bt_plan.IsEnabled = False
            bt_qual.IsEnabled = False
        End If
    End Sub
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim four As New Window1
        four.Show()
        Me.Hide()

    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        Dim perso As New Personnel
        perso.Show()
        Me.Hide()
    End Sub

    Private Sub Button_Click_3(sender As Object, e As RoutedEventArgs)
        Dim planif As New Planification()
        planif.Show()
        Me.Hide()
    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As RoutedEventArgs) Handles MenuItem1.Click
        Dim login As New MainWindow()
        login.Show()
        Me.Hide()
    End Sub
End Class
