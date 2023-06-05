Imports Microsoft.VisualBasic.FileIO
Imports Npgsql
Imports System.Data
Imports System.IO
Imports System.Windows.Forms

Public Class testcsv

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim csvFiles() As String = Directory.GetFiles("C:\reports", "*.csv")
        Dim i As Integer = 0


        cnx.Open()

        Dim transaction As NpgsqlTransaction = cnx.BeginTransaction()
        Try
            Dim cmd As New NpgsqlCommand()
            cmd.Connection = cnx
            cmd.Transaction = transaction
            cmd.CommandType = CommandType.Text
            For Each csvFile As String In csvFiles
                ' Read the CSV file using TextFieldParser
                Dim parser As New TextFieldParser(csvFile)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(";")
                Dim headerFields As String() = parser.ReadFields() ' Skip the header line

                While Not parser.EndOfData
                    Dim fields As String() = parser.ReadFields()

                    ' Insert data into PostgreSQL table
                    cmd.CommandText = "INSERT INTO public.testcsv (""numero de charge"", date, heure, consigne, temperature) VALUES (@Column1, @Column2, @Column3 , @Column4, @Column5)"

                    cmd.Parameters.AddWithValue("@Column1", fields(6))
                    cmd.Parameters.AddWithValue("@Column2", fields(4))
                    cmd.Parameters.AddWithValue("@Column3", fields(5))
                    cmd.Parameters.AddWithValue("@Column4", fields(2))
                    cmd.Parameters.AddWithValue("@Column5", fields(0))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    LAB.Content = i
                    i += 1
                End While

            Next
            transaction.Commit()
            MessageBox.Show("Data inserted successfully.")

        Catch ex As NpgsqlException
            transaction.Rollback()
            MessageBox.Show("PostgreSQL Error: " & ex.Message & vbCrLf & "SQL State: ")
        Catch ex As Exception
            transaction.Rollback()
            MessageBox.Show("Error inserting data: " & ex.Message)

        End Try


        cnx.Close()


    End Sub

End Class
