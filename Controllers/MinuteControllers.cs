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

   [Route("v1/projects")] // HTTP GET =>  https://localhost:5001/v1/project/minutes
   public class MinuteController : ControllerBase
   {

      [HttpGet]
      [Route("{projectId:int}/minutes")]
      public async Task<ActionResult<List<ProjectMinute>>> Get(int projectId, [FromServices] DataContext context)
      {

         var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

         if (project == null)
            return NotFound();

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
      [Route("{projectId:int}/minutes")] // HTTP PUT =>  https://localhost:5001/v1/project/minutes

      public async Task<ActionResult<ProjectMinute>> Post(int projectId, [FromServices] DataContext context, [FromBody] ProjectMinute model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);
         var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

         if (project == null)
            return NotFound();

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
      [Route("{projectId:int}/minutes/{minutesId:int}")] // HTTP PUT =>  https://localhost:5001/v1/project/minutes/1

      public async Task<ActionResult<ProjectMinute>> Put(int projectId, int minutesId, [FromServices] DataContext context, [FromBody] ProjectMinute model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);
         var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

         if (project == null)
            return NotFound();

         if (model.Id != minutesId)
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
      [Route("{projectId:int}/minutes/{minutesId:int}")] // HTTP DELETE => https://localhost:5001/v1/project/minutes/1

      public async Task<ActionResult<ProjectMinute>> Delete(int projectId, int minutesId, [FromServices] DataContext context)
      {

         var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

         if (project == null)
            return NotFound();

         try
         {
            var minute = await context.ProjectMinutes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == minutesId);
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