

using System;
using System.Data;
using System.Data.SqlClient;
using BoBStore.Shared;

namespace TechSystem.Infra.DataContext
{
    public class TechDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public TechDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();

        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

    }
}