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
   [Route("v1/project")]
   public class ProjectControllers : ControllerBase
   {
      [HttpGet]
      [Route("")] // HTTP GET => localhost:5001/v1/project
      public async Task<ActionResult<List<Project>>> Get([FromServices] DataContext context)
      {
         try
         {
            var projects = await context.Projects.Include(x => x.Minute).Include(x => x.Steps).AsNoTracking().ToListAsync();
            if (projects == null)
               return NotFound();
            return Ok(projects);
         }
         catch (System.Exception)
         {
            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpGet]
      [Route("{id:int}")]  // HTTP GET => localhost:5001/v1/project/1

      public async Task<ActionResult<Project>> GetById(int id, [FromServices] DataContext context)
      {
         try
         {
            var projects = await context.Projects.AsNoTracking().Include(x => x.Minute).Include(x => x.Steps).FirstOrDefaultAsync(x => x.Id == id);
            if (projects == null)
               return NotFound();

            return Ok(projects);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }

      }


      [HttpPost]
      [Route("")] // HTTP POST => localhost:5001/v1/project

      public async Task<ActionResult<Project>> Post([FromServices] DataContext context, [FromBody] Project model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         try
         {
            context.Add<Project>(model);
            await context.SaveChangesAsync();
            return Ok(model);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }


      [HttpPut]
      [Route("{id:int}")] // HTTP PUT => localhost:5001/v1/project/2

      public async Task<ActionResult<Project>> Put(int id, [FromServices] DataContext context, [FromBody] Project model)
      {
         if (!ModelState.IsValid)
            return BadRequest();

         if (model.Id != id)
            return NotFound();

         try
         {
            context.Entry<Project>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpDelete]
      [Route("{id:int}")] // HTTP DELETE => localhost:5001/v1/project/3

      public async Task<ActionResult<Project>> Delete(int id, [FromServices] DataContext context)
      {
         try
         {

            var project = await context.Projects.Include(x => x.Minute).Include(x => x.Steps).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (project == null)
               return NotFound();


            context.Projects.Remove(project);

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