using System;
using System.Collections;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BOBTechSystem.Repository
{
   // Função generica para ralização do CRUD

   public class Repository<T> where T : class
   {
      private readonly SqlConnection _connection;
      public Repository(SqlConnection connection) => _connection = connection;
      public IEnumerable<T> GetAll() => _connection.GetAll<T>();

      public T Get(Guid id) => _connection.Get<T>(id);
      public void Set(T model) => _connection.Insert<T>(model);
      public void Update(T model) => _connection.Update<T>(model);
      public void Update(Guid id) => _connection.Update<T>(_connection.Get<T>(id));
      public void Delete(T model) => _connection.Delete<T>(model);
      public void Delete(Guid id) => _connection.Delete<T>(_connection.Get<T>(id));

   }
}
