Imports System.Data
Imports System.Windows
Imports Npgsql

Class UserDetails

    Public Sub New(userID As Integer, userName As String, lastName As String, userEmail As String, userPassword As String, userFonction As String)
        InitializeComponent()

        ' Use the passed data to display user details in the window
        ' You can set the values to the appropriate controls in the window
        UserIDTextBox.Text = userID.ToString()
        UserNameTextBox.Text = userName
        LastNameTextBox.Text = lastName
        EmailTextBox.Text = userEmail
        passwordTextBox.Text = userPassword
        UserFonctionTextBox.Text = userFonction
    End Sub

    Private Sub modifyButton_Click(sender As Object, e As RoutedEventArgs)
        ' Enable editing mode for the TextBoxes
        UserNameTextBox.IsReadOnly = False
        LastNameTextBox.IsReadOnly = False
        UserFonctionTextBox.IsReadOnly = False
        EmailTextBox.IsReadOnly = False
        passwordTextBox.IsReadOnly = False

        ' Change the button text to indicate saving
        Modifybutton.Content = "Enregistrer"

        ' Change the button click event handler to save changes
        RemoveHandler Modifybutton.Click, AddressOf modifyButton_Click
        AddHandler Modifybutton.Click, AddressOf saveChangesButton_Click
    End Sub

    Private Sub saveChangesButton_Click(sender As Object, e As RoutedEventArgs)
        ' Disable editing mode for the TextBoxes
        UserNameTextBox.IsReadOnly = True
        LastNameTextBox.IsReadOnly = True
        UserFonctionTextBox.IsReadOnly = True
        EmailTextBox.IsReadOnly = True
        passwordTextBox.IsReadOnly = True

        ' Get the updated values from the TextBoxes
        Dim userID As Integer = Integer.Parse(UserIDTextBox.Text)
        Dim userName As String = UserNameTextBox.Text
        Dim lastName As String = LastNameTextBox.Text
        Dim userFonction As String = UserFonctionTextBox.Text
        Dim userEmail As String = EmailTextBox.Text
        Dim userPassword As String = passwordTextBox.Text

        ' Update the user details in the database
        If cnx.State = ConnectionState.Closed Then
            cnx.Open()
        End If

        Dim query As String = "UPDATE users SET nom = @Nom, prenom = @prenom, fonction = @Fonction, email = @Email, password = @Password WHERE id = @ID"

        cmd = New NpgsqlCommand(query, cnx)
        cmd.Parameters.AddWithValue("@Nom", userName)
        cmd.Parameters.AddWithValue("@prenom", lastName)
        cmd.Parameters.AddWithValue("@Fonction", userFonction)
        cmd.Parameters.AddWithValue("@Email", userEmail)
        cmd.Parameters.AddWithValue("@Password", userPassword)
        cmd.Parameters.AddWithValue("@ID", userID)

        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        If rowsAffected > 0 Then
            ' Show a message or perform any other action for successful update
            MsgBox("User details updated successfully.")
        Else
            ' Update failed
            MsgBox("Failed to update user details.")
        End If

        ' Change the button text back to "Modifier"
        Modifybutton.Content = "Modifier"

        ' Change the button click event handler back to modifyButton_Click
        RemoveHandler Modifybutton.Click, AddressOf saveChangesButton_Click
        AddHandler Modifybutton.Click, AddressOf modifyButton_Click

        ' Close the database connection
        cnx.Close()
    End Sub



    Private Sub deleteButton_Click(sender As Object, e As RoutedEventArgs)
        If cnx.State = ConnectionState.Closed Then
            cnx.Open()
        End If

        ' Get the user ID from the TextBox
        Dim userId As Integer = Integer.Parse(UserIDTextBox.Text)

        ' Delete the user record from the database
        Dim query As String = "DELETE FROM users WHERE id = " & userId

        cmd = New NpgsqlCommand(query, cnx)
        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        If rowsAffected > 0 Then
            ' Clear the TextBox values
            UserIDTextBox.Clear()
            UserNameTextBox.Clear()
            LastNameTextBox.Clear()
            UserFonctionTextBox.Clear()
            EmailTextBox.Clear()
            passwordTextBox.Clear()

            ' Show a message or perform any other action for deletion
            MsgBox("User deleted successfully.")
        Else
            ' User not found or deletion failed
            MsgBox("User not found or deletion failed.")
        End If

        ' Close the database connection
        cnx.Close()

    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim second1 As New Personnel

        second1.Show()
        Me.Hide()
    End Sub
End Class