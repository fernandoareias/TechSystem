using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSystem.Data;
using TechSystem.Models;

namespace TechSystem.Controllers
{
   [Route("v1/dependent")]
   public class DependentController : ControllerBase
   {

      [HttpGet]
      [Route("")] // https://localhost:5001/v1/dependent
      public async Task<ActionResult<List<Dependent>>> Get([FromServices] DataContext context)
      {
         try
         {
            var dependents = await context.Dependents.AsNoTracking().ToListAsync();
            if (dependents == null)
               return NotFound(new { message = "Não há dependentes registrado" });
            return Ok(dependents);
         }
         catch (System.Exception e)
         {

            return BadRequest(new { message = $"{e.Message}" });
         }
      }

      [HttpGet]
      [Route("{id:int}")] // https://localhost:5001/v1/dependent/1
      public async Task<ActionResult<Dependent>> GetById(int id, [FromServices] DataContext context)
      {
         try
         {
            var dependet = await context.Dependents.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (dependet == null)
               return NotFound(new { message = "Não foi possivel encontrar o dependente" });
            return Ok(dependet);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpGet]
      [Route("employee/{id:int}")] // https://localhost:5001/v1/dependent/employee/2

      public async Task<ActionResult<List<Dependent>>> GetByEmployee(int id, [FromServices] DataContext context)
      {
         try
         {
            var dependent = await context.Dependents.AsNoTracking().Where(x => x.EmployeeId == id).ToListAsync();
            if (dependent == null)
               return NotFound(new { message = "Esse funcionário não possui dependentes" });
            return Ok(dependent);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpPost]
      [Route("")]

      public async Task<ActionResult<Dependent>> Post([FromServices] DataContext context, [FromBody] Dependent model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);
         try
         {
            context.Dependents.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
         }
         catch (System.Exception)
         {
            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }
   }
}