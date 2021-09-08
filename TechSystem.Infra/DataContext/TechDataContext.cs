

using System;
using System.Data;
using System.Data.SqlClient;
using TechSystem.Shared;

namespace TechSystem.Infra.DataContext
{
    public class TechDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public TechDataContext()
        {
            Connection = new SqlConnection("server=localhost,1433;database=TechSystem;User ID=sa;Password=kpglk");
            Connection.Open();

        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

    }
}