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
   [Route("v1/employee")]
   public class EmployeeController : ControllerBase
   {

      [HttpGet]
      [Route("")] // https://localhost:5001/v1/employee/
      // Esse metódo retorna todos os funcionários cadastrados
      public async Task<ActionResult<List<Employee>>> Get([FromServices] DataContext context)
      {
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
      [Route("{id:int}")] // https://localhost:5001/v1/employee/1
      // Esse metodo retorna caso exista, o funcionário portador do ID passado pela URL
      public async Task<ActionResult<Employee>> GetById(int id, [FromServices] DataContext context)
      {
         try
         {
            var employee = await context.Employees.Include(x => x.Dependents).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
      [Route("")]// https://localhost:5001/v1/employee/
      // Realiza o registro do funcionario
      public async Task<ActionResult<Employee>> Set([FromServices] DataContext context, [FromBody] Employee model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

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
      [Route("{id:int}")] // https://localhost:5001/v1/employee/2
      // Realiza a atualização de dados do funcionário portador do ID passado pela URL
      public async Task<ActionResult<Employee>> Update(int id, [FromServices] DataContext context, [FromBody] Employee model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         if (id != model.Id)
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
      [Route("{id:int}")] // https://localhost:5001/v1/employee/5
      // Caso exista, deleta o funcionário portador do ID passado pela URL
      public async Task<ActionResult<Employee>> Delete(int id, [FromServices] DataContext context)
      {
         var employe = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

         // Pega todos os dependentes que o funcionario possui
         var dependent = await context.Dependents.AsNoTracking().Where(x => x.EmployeeId == id).ToListAsync();

         if (employe == null || dependent == null)
            return NotFound(new { message = "Não foi possivel encontrar o funcionário" });

         try
         {
            context.Employees.Remove(employe);

            // Remove todos os dependentes que o funcionário possui, similar ao efeito CASCADE
            foreach (var item in dependent)
               context.Dependents.Remove(item);


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