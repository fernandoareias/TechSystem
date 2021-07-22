using BOBTechSystem.Repository;
using Microsoft.Data.SqlClient;
using BOBTechSystem.Models;

namespace BOBTechSystem
{
   class Program
   {
      static void Main(string[] args)
      {
         const string CONNECTSTRING = "Server=localhost;Database=BOBTech;User Id=sa;Password=Nando@37074957;";

         using (var connection = new SqlConnection(CONNECTSTRING))
         {
            var repository = new Repository<Employee>(connection);

            var employee = repository.GetAll();

            foreach (var item in employee)
            {
               System.Console.WriteLine(item.Name);
            }

            System.Console.WriteLine();
         }
      }
   }
}

