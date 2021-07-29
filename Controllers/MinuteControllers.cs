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

   [Route("v1/project/minutes")] // HTTP GET =>  https://localhost:5001/v1/project/minutes
   public class MinuteController : ControllerBase
   {

      [HttpGet]
      [Route("")]
      public async Task<ActionResult<List<ProjectMinute>>> Get([FromServices] DataContext context)
      {
         try
         {
            var minutes = await context.ProjectMinutes.AsNoTracking().ToListAsync();
            if (minutes == null)
               return BadRequest();

            return Ok(minutes);
         }
         catch (System.Exception)
         {
            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }


      [HttpPost]
      [Route("")] // HTTP PUT =>  https://localhost:5001/v1/project/minutes

      public async Task<ActionResult<ProjectMinute>> Post([FromServices] DataContext context, [FromBody] ProjectMinute model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);
         try
         {
            context.ProjectMinutes.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpPut]
      [Route("{id:int}")] // HTTP PUT =>  https://localhost:5001/v1/project/minutes/1

      public async Task<ActionResult<ProjectMinute>> Put(int id, [FromServices] DataContext context, [FromBody] ProjectMinute model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         if (model.Id != id)
            return NotFound();

         try
         {
            context.Entry<ProjectMinute>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok();
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }



      [HttpDelete]
      [Route("{id:int}")] // HTTP DELETE => https://localhost:5001/v1/project/minutes/1

      public async Task<ActionResult<ProjectMinute>> Delete(int id, [FromServices] DataContext context)
      {
         try
         {
            var minute = await context.ProjectMinutes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (minute == null)
               return NotFound();

            context.ProjectMinutes.Remove(minute);
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