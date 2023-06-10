Imports Microsoft.VisualBasic.ApplicationServices
Imports Npgsql
Imports System.Data
Imports System.Windows.Forms

Class Personnel

    Dim dt As New DataTable()
    Public Sub New()
        InitializeComponent()
        user1.Header = usera
        LoadData()

    End Sub

    Private Sub LoadData()
        Dim query As String = "SELECT id, nom, prenom, initial, fonction, habilitation, equipe, password, email FROM public.users"

        Using cmd As New NpgsqlCommand(query, cnx)
            cnx.Open()
            Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                dt.Load(reader)
                reader.Close()
            End Using
            cnx.Close()
        End Using

        userDataGrid.ItemsSource = dt.DefaultView
    End Sub
    Private Sub MenuItem1_Click(sender As Object, e As RoutedEventArgs)
        Dim login As New MainWindow()
        login.Show()
        Me.Hide()
    End Sub





    Private Sub userDataGrid_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        ' Handle the selection changed event of the userDataGrid
        ' Enable the Afficher button only when a single row is selected
        afficherButton.IsEnabled = (userDataGrid.SelectedItems.Count = 1)
    End Sub
    Private Sub afficherButton_Click(sender As Object, e As RoutedEventArgs)
        ' Handle the Afficher button click events
        ' Get the selected row from the userDataGrid
        Dim selectedRow As DataRowView = TryCast(userDataGrid.SelectedItem, DataRowView)

        If selectedRow IsNot Nothing Then
            ' Extract the necessary data from the selected row
            Dim id As Integer = CInt(selectedRow("id"))
            Dim nom As String = CStr(selectedRow("nom"))
            Dim prenom As String = CStr(selectedRow("prenom"))
            Dim email As String = CStr(selectedRow("email"))
            Dim password As String = CStr(selectedRow("password"))
            Dim fonction As String = CStr(selectedRow("fonction"))

            ' Pass the data to the next window or perform any other action
            ' For example, you can open a new window and display the user data:
            Dim userDetailsWindow As New UserDetails(id, nom, prenom, email, password, fonction)
            userDetailsWindow.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub addButton_Click(sender As Object, e As RoutedEventArgs)
        Dim addUserWindow As New AddUserWindow()
        addUserWindow.Show()
        Me.Hide()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim choose As New second
        choose.Show()
        Me.Hide()
    End Sub



End Class