using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSystem.Data;
using TechSystem.Models;

namespace TechSystem.Controllers
{
   [Route("v1/employee")]
   public class EmployeeController : ControllerBase
   {
      [HttpGet]
      [Route("")]

      public async Task<ActionResult<List<Employee>>> Get([FromServices] DataContext context)
      {
         try
         {
            var employeers = await context.Employees.AsNoTracking().ToListAsync();
            if (employeers == null)
               return NotFound(new { message = "Não há funcionarios registrados" });
            return Ok(employeers);
         }
         catch (Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpGet]
      [Route("{id:int}")]
      public async Task<ActionResult<Employee>> GetById(int id, [FromServices] DataContext context, [FromBody] Employee model)
      {
         try
         {
            var employee = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
      [Route("")]
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
      [Route("{id:int}")]

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
      [Route("{id:int}")]
      public async Task<ActionResult<Employee>> Delete(int id, [FromServices] DataContext context)
      {
         var employe = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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