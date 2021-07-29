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
   [Route("v1/dependent")] // https://localhost:5001/v1/dependent
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



      [HttpPost]
      [Route("")] // https://localhost:5001/v1/dependent/

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

      [HttpPut]
      [Route("{id:int}")] // https://localhost:5001/v1/dependent/1

      public async Task<ActionResult<Dependent>> Get(int id, [FromServices] DataContext context, [FromBody] Dependent model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         if (model.Id != id)
            return NotFound(new { message = "Não foi possivel encontrar o dependente" });
         try
         {
            context.Entry<Dependent>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpDelete]
      [Route("{id:int}")] // https://localhost:5001/v1/dependent/2

      public async Task<ActionResult<Dependent>> Delete(int id, [FromServices] DataContext context)
      {
         var dependent = await context.Dependents.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
         if (dependent == null)
            return NotFound();

         try
         {
            context.Dependents.Remove(dependent);
            await context.SaveChangesAsync();
            return Ok();
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }
   }
}