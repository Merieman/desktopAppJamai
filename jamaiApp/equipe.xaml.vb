Imports Npgsql
Imports System.ComponentModel
Imports System.Data
Imports System.Runtime.CompilerServices

Partial Public Class equipe
    Inherits Window

    Private SelectedItems As New List(Of OperatorItem)()

    Public Sub New()
        InitializeComponent()
        add.IsEnabled = False
        PopulateFirstListBox()
    End Sub

    Private Sub PopulateFirstListBox()
        ' Retrieve data from the database
        If cnx.State = ConnectionState.Closed Then
            cnx.Open()
        End If

        str = "SELECT initial, fonction, equipe FROM public.users"

        ' Check if there is an existing reader and close it
        If reader IsNot Nothing AndAlso Not reader.IsClosed Then
            reader.Close()
        End If

        cmd = New NpgsqlCommand(str, cnx)
        reader = cmd.ExecuteReader()
        Dim operatorsList As New List(Of OperatorItem)()
        While reader.Read()
            Dim initial As String = reader.GetString(0)
            Dim func As String = reader.GetString(1)
            Dim team As String = reader.GetString(2)
            operatorsList.Add(New OperatorItem() With {
                .Initial = initial,
                .Fonction = func,
                .Team = team
            })
        End While

        ' Bind the operatorsList to the first ListBox
        firstListBox.ItemsSource = operatorsList
        reader.Close()
        cnx.Close()
    End Sub

    Private Sub Grid_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)
        Dim grid = TryCast(sender, Grid)
        Dim item = TryCast(grid.DataContext, OperatorItem)

        If item IsNot Nothing Then
            item.IsSelected = Not item.IsSelected
        End If
    End Sub
    Private Sub SecondListBox_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)
        Dim grid = TryCast(sender, Grid)
        Dim item = TryCast(grid.DataContext, OperatorItem)

        If item IsNot Nothing Then
            item.IsSelected = Not item.IsSelected
        End If
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim planific As New Planification
        planific.Show()
        Me.Hide()
    End Sub

    Private Sub MenuItem1_Click(sender As Object, e As RoutedEventArgs) Handles MenuItem1.Click
        Dim decon As New MainWindow
        decon.Show()
        Me.Hide()
    End Sub

    Private Sub RadioButton_Checked(sender As Object, e As RoutedEventArgs)
        add.IsEnabled = True
    End Sub

    Private Sub RadioButton_Checked_1(sender As Object, e As RoutedEventArgs)
        add.IsEnabled = True
    End Sub

    Private Sub RadioButton_Checked_2(sender As Object, e As RoutedEventArgs)
        add.IsEnabled = True
    End Sub

    Private Sub add_Click(sender As Object, e As RoutedEventArgs) Handles add.Click
        If CheckIfAnyItemSelected() Then
            GetSelectedItems()
        End If
    End Sub

    Private Function CheckIfAnyItemSelected() As Boolean
        For Each item As OperatorItem In firstListBox.Items
            If item.IsSelected Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub GetSelectedItems()
        For Each item As OperatorItem In firstListBox.Items
            If item.IsSelected AndAlso Not SelectedItems.Contains(item) Then
                SelectedItems.Add(item)
                secondListBox.Items.Add(item)
            End If
        Next
    End Sub
End Class

Public Class OperatorItem
    Implements INotifyPropertyChanged

    Private _initial As String
    Private _fonction As String
    Private _team As String
    Private _isSelected As Boolean
    Private _isSelectedSecond As Boolean


    Public Property Initial As String
        Get
            Return _initial
        End Get
        Set(value As String)
            _initial = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Fonction As String
        Get
            Return _fonction
        End Get
        Set(value As String)
            _fonction = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Team As String
        Get
            Return _team
        End Get
        Set(value As String)
            _team = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(value As Boolean)
            _isSelected = value
            OnPropertyChanged("IsSelected")
        End Set
    End Property

    Public Property IsSelectedSecond As Boolean
        Get
            Return _isSelectedSecond
        End Get
        Set(value As Boolean)
            _isSelectedSecond = value
            OnPropertyChanged("IsSelectedSecond")
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Initial} - {Fonction} - {Team}"
    End Function
End Class
