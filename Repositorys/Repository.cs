

using System;
using System.Collections;
using BOBTechSystem.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BOBTechSystem.Repository
{

   public class Repository<T> where T : class
   {
      public SqlConnection _connection { get; set; }
      public Repository(SqlConnection connection) => _connection = _connection;

      public IEnumerable GetAll() => _connection.GetAll<T>();

      public T Get(Guid id) => _connection.Get<T>(id);

      public void Set(T model) => _connection.Insert<T>(model);

   }
}
