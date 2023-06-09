Imports Npgsql

Module publique
    Public four As String
    Public nCharge As String
    Public test As Boolean
    Public email_ As String
    Public cnx As New NpgsqlConnection("Host=localhost;Port=5432;Database=testJamai;Username=postgres;Password=testjamai")
    Public cmd As NpgsqlCommand
    Public reader As NpgsqlDataReader
    Public str As String



End Module
