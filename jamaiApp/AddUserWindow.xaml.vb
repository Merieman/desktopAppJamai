Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports Npgsql

Class AddUserWindow


    Private Sub MenuItem1_Click(sender As Object, e As RoutedEventArgs)
        Dim login As New MainWindow()
        login.Show()
        Me.Hide()
    End Sub
    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim perso As New Personnel
        perso.Show()
        Me.Hide()
    End Sub
    Private Sub ClearFields()
        nomTextBox.Text = String.Empty
        prenomTextBox.Text = String.Empty
        naissTextBox.SelectedDate = Nothing
        foncTextBox.Text = String.Empty
        embTextBox.SelectedDate = Nothing
        sortieTextBox.SelectedDate = Nothing
        mdpTextBox.Password = String.Empty
        habTextBox.Text = String.Empty
        emailTextBox.Text = String.Empty
        telTextBox.Text = String.Empty
        eqTextBox.Text = String.Empty
        initTextBox.Text = String.Empty
    End Sub

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        user1.Header = usera
    End Sub

    Private Sub addButton_click(sender As Object, e As RoutedEventArgs)
        Dim nom As String = nomTextBox.Text
        Dim prenom As String = prenomTextBox.Text
        Dim date_naiss As DateTime = DateTime.Parse(naissTextBox.Text)
        Dim fonction As String = foncTextBox.Text
        Dim date_embauche As DateTime = DateTime.Parse(embTextBox.Text)

        Dim mot_de_passe As String = mdpTextBox.Password
        Dim habilitation As String = habTextBox.Text
        Dim email As String = emailTextBox.Text
        Dim telephone As String = telTextBox.Text
        Dim equipe As String = eqTextBox.Text
        Dim initial As String = initTextBox.Text






        ' Prepare the SQL query
        Dim query As String = "INSERT INTO public.users (Nom, Prenom, birthDate, Fonction, hireDate, dateDeSortie, password, Habilitation, Email, Telephone, Equipe, Initial) VALUES (@Nom, @Prenom, @birthDate, @Fonction, @hireDate, @DateDeSortie, @password, @Habilitation, @Email, @Telephone, @Equipe, @Initial)"
        Using command As New NpgsqlCommand(query, cnx)

            cnx.Open()
            ' Set the parameter values
            command.Parameters.AddWithValue("@Nom", nom)
            command.Parameters.AddWithValue("@Prenom", prenom)
            command.Parameters.AddWithValue("@birthDate", date_naiss)
            command.Parameters.AddWithValue("@Fonction", fonction)
            command.Parameters.AddWithValue("@hireDate", date_embauche)
            If Not String.IsNullOrEmpty(sortieTextBox.Text) Then
                Dim date_sortie As DateTime
                If DateTime.TryParse(sortieTextBox.Text, date_sortie) Then
                    command.Parameters.AddWithValue("@dateDeSortie", date_sortie)
                Else
                    ' Parsing failed, handle the case where the text is not a valid DateTime
                    ' Show an error message or take appropriate action
                End If
            Else
                command.Parameters.AddWithValue("@dateDeSortie", DBNull.Value) ' Set parameter value to DBNull for empty date
            End If


            command.Parameters.AddWithValue("@password", mot_de_passe)
            command.Parameters.AddWithValue("@Habilitation", habilitation)
            command.Parameters.AddWithValue("@Email", email)
            command.Parameters.AddWithValue("@Telephone", telephone)
            command.Parameters.AddWithValue("@Equipe", equipe)
            command.Parameters.AddWithValue("@Initial", initial)

            ' Execute the query
            command.ExecuteNonQuery()

            ' Display a success message or perform other actions
            MessageBox.Show("User added successfully.")
            ClearFields()
            cnx.Close()
        End Using
    End Sub

    Private Sub nomTextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles nomTextBox.TextChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub UpdateButtonEnabled()
        ' Enable the button if the text box and date picker both have a value, disable it otherwise
        addButton.IsEnabled = Not String.IsNullOrEmpty(nomTextBox.Text) AndAlso Not String.IsNullOrEmpty(prenomTextBox.Text) AndAlso Not String.IsNullOrEmpty(foncTextBox.Text) AndAlso naissTextBox.SelectedDate IsNot Nothing AndAlso embTextBox.SelectedDate IsNot Nothing AndAlso Not String.IsNullOrEmpty(mdpTextBox.Password) AndAlso Not String.IsNullOrEmpty(initTextBox.Text) AndAlso Not String.IsNullOrEmpty(eqTextBox.Text) AndAlso Not String.IsNullOrEmpty(telTextBox.Text) AndAlso Not String.IsNullOrEmpty(emailTextBox.Text)

    End Sub

    Private Sub prenomTextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles prenomTextBox.TextChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub naissTextBox_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles naissTextBox.SelectedDateChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub foncTextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles foncTextBox.TextChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub embTextBox_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles embTextBox.SelectedDateChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub sortieTextBox_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles sortieTextBox.SelectedDateChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub mdpTextBox_PasswordChanged(sender As Object, e As RoutedEventArgs) Handles mdpTextBox.PasswordChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub initTextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles initTextBox.TextChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub telTextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles telTextBox.TextChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub habTextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles habTextBox.TextChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub eqTextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles eqTextBox.TextChanged
        UpdateButtonEnabled()
    End Sub

    Private Sub MenuItem1_Click_1(sender As Object, e As RoutedEventArgs) Handles MenuItem1.Click
        Dim decon As New MainWindow
        decon.Show()
        Me.Hide()
    End Sub
End Class