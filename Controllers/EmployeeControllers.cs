using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSystem.Data;
using TechSystem.Models;

// CRUD Employee Completado

namespace TechSystem.Controllers
{
   [Route("v1/departments")]
   public class EmployeeController : ControllerBase
   {

      [HttpGet]
      [Route("{departmentId:int}/employees")] // HTTP GET => https://localhost:5001/v1/employee/
      // Esse metódo retorna todos os funcionários cadastrados
      public async Task<ActionResult<List<Employee>>> Get(int departmentId, [FromServices] DataContext context)
      {
         var department = await context.Department.AsNoTracking().FirstOrDefaultAsync(x => x.Id == departmentId);
         if (department == null)
            return NotFound();
         try
         {
            // Caso tenha dependentes, retorna 
            // Include() => INNER JOIN
            var employeers = await context.Employees.Include(x => x.Dependents).AsNoTracking().ToListAsync();
            if (employeers == null)
               return NotFound(new { message = "Não foi possivel encontrar o funcionário" });
            return Ok(employeers);
         }
         catch (Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpGet]
      [Route("{departmentId:int}/employees/{employeeId:int}")] //  HTTP GET => https://localhost:5001/v1/employee/1
      // Esse metodo retorna caso exista, o funcionário portador do ID passado pela URL
      public async Task<ActionResult<Employee>> GetById(int employeeId, int departmentId, [FromServices] DataContext context)
      {
         var department = await context.Department.AsNoTracking().FirstOrDefaultAsync(x => x.Id == departmentId);
         if (department == null)
            return NotFound();
         try
         {
            var employee = await context.Employees.Include(x => x.Dependents).AsNoTracking().FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee == null)
               return NotFound(new { message = "Funcionário não encontrado" });
            return Ok(employee);
         }
         catch (Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }



      [HttpPost]
      [Route("{departmentId:int}/employees")]//  HTTP PUT => https://localhost:5001/v1/employee/
      // Realiza o registro do funcionario
      public async Task<ActionResult<Employee>> Set(int departmentId, [FromServices] DataContext context, [FromBody] Employee model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);
         var department = await context.Department.AsNoTracking().FirstOrDefaultAsync(x => x.Id == departmentId);
         if (department == null)
            return NotFound();
         try
         {
            context.Employees.Add(model);
            await context.SaveChangesAsync();

            return Ok(model);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }


      [HttpPut]
      [Route("{departmentId:int}/employees/{employeeId:int}")] // HTTP PUT => https://localhost:5001/v1/employee/2
      // Realiza a atualização de dados do funcionário portador do ID passado pela URL
      public async Task<ActionResult<Employee>> Update(int employeeId, int departmentId, [FromServices] DataContext context, [FromBody] Employee model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);
         var department = await context.Department.AsNoTracking().FirstOrDefaultAsync(x => x.Id == departmentId);
         if (department == null)
            return NotFound();
         if (employeeId != model.Id)
            return NotFound(new { message = "Funcionário não encontrado" });

         try
         {
            context.Entry<Employee>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpDelete]
      [Route("{departmentId:int}/employees/{employeeId:int}")] // HTTP DELETE => https://localhost:5001/v1/employee/5
      // Caso exista, deleta o funcionário portador do ID passado pela URL
      public async Task<ActionResult<Employee>> Delete(int employeeId, int departmentId, [FromServices] DataContext context)
      {
         var employe = await context.Employees.AsNoTracking().Include(x => x.Dependents).FirstOrDefaultAsync(x => x.Id == employeeId);
         var department = await context.Department.AsNoTracking().FirstOrDefaultAsync(x => x.Id == departmentId);
         if (department == null)
            return NotFound();
         if (employe == null)
            return NotFound(new { message = "Não foi possivel encontrar o funcionário" });

         try
         {
            context.Employees.Remove(employe);

            await context.SaveChangesAsync();
            return Ok(new { message = "Funcionário removido com sucesso" });
         }
         catch (System.Exception)
         {
            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }
   }
}