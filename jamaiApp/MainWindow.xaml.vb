Imports System.Data
Imports Npgsql

Class MainWindow
    Dim cnx As New NpgsqlConnection("Host=localhost;Port=5432;Database=testJamai;Username=postgres;Password=testjamai")
    Dim cmd As NpgsqlCommand
    Dim reader As NpgsqlDataReader ' Declare the reader outside the Button1_Click method

    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim email1 As String = email.Text.Replace("'", "\'")

        If email.Text = "" Then
            MsgBox("Veuillez entrer votre e-mail")
        ElseIf password.Password = "" Then
            MsgBox("Veuillez entrer votre mot de passe")
        Else
            If cnx.State = ConnectionState.Closed Then
                cnx.Open()
            End If

            Dim str As String = "SELECT * FROM public.users WHERE email='" & email1 & "'"

            ' Check if there is an existing reader and close it
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If

            cmd = New NpgsqlCommand(str, cnx)
            reader = cmd.ExecuteReader()

            If Not reader.Read() Then
                MsgBox("L'e-mail n'existe pas")
                MsgBox("Veuillez saisir une autre adresse e-mail")
            ElseIf reader("password") <> password.Password Then
                MsgBox("Le mot de passe est incorrect")
            Else
                reader.Close()
                cnx.Close()
                email_ = email1
                email.Text = ""
                password.Password = ""
                Dim choose As New CreationCharge
                choose.Show()
                Me.Hide()
                test = 0
            End If
        End If
    End Sub
End Class
