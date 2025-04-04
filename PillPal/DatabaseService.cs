using System;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Windows.Forms;

public class DatabaseService
{
    private string connectionString;

    public DatabaseService()
    {
        connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
    }


    public void TestConnection()
    {/*
        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                MessageBox.Show("Połączenie nawiązane pomyślnie!");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Wystąpił błąd podczas łączenia: " + ex.Message);
        }
    */
    }
}

