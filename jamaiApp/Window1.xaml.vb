﻿Public Class Window1




    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        user1.Header = usera
    End Sub

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





    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim second1 As New second
        second1.Show()
        Me.Hide()
    End Sub
End Class
