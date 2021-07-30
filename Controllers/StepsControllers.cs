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
   public class StepsController : ControllerBase
   {

      [HttpGet]
      [Route("{projectId:int}/steps/")]
      public async Task<ActionResult<List<ProjectStep>>> Get(int projectId, [FromServices] DataContext context)
      {

         var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

         if (project == null)
            return NotFound();

         try
         {
            var minutes = await context.ProjectSteps.AsNoTracking().ToListAsync();
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
      [Route("{projectId:int}/steps/")] // HTTP PUT =>  https://localhost:5001/v1/project/minutes

      public async Task<ActionResult<ProjectStep>> Post(int projectId, [FromServices] DataContext context, [FromBody] ProjectStep model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

         if (project == null)
            return NotFound();

         if (model.ProjectId != projectId)
            return NotFound();



         try
         {
            context.ProjectSteps.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpPut]
      [Route("{projectId:int}/steps/{stepsId:int}")] // HTTP PUT =>  https://localhost:5001/v1/project/minutes/1

      public async Task<ActionResult<ProjectStep>> Put(int projectId, int stepsId, [FromServices] DataContext context, [FromBody] ProjectStep model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

         if (project == null)
            return NotFound();

         if (model.ProjectId != projectId)
            return NotFound();

         try
         {
            context.Entry<ProjectStep>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok();
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }



      [HttpDelete]
      [Route("{projectId:int}/steps/{stepsId:int}")] // HTTP DELETE => https://localhost:5001/v1/project/minutes/1

      public async Task<ActionResult<ProjectStep>> Delete(int projectId, int stepsId, [FromServices] DataContext context)
      {
         var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == projectId);

         if (project == null)
            return NotFound();

         try
         {
            var minute = await context.ProjectSteps.AsNoTracking().FirstOrDefaultAsync(x => x.Id == stepsId);
            if (minute == null)
               return NotFound();

            context.ProjectSteps.Remove(minute);
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
