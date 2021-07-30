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
   [Route("v1/departments")]
   public class DepartmentController : ControllerBase
   {
      [HttpGet]
      [Route("")]

      public async Task<ActionResult<List<Department>>> Get([FromServices] DataContext context)
      {
         try
         {
            // OPA
            var departments = await context.Department.AsNoTracking().Include(x => x.Employees).ToListAsync();
            if (departments == null)
               return NotFound();
            return Ok(departments);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpGet]
      [Route("{id:int}")]
      public async Task<ActionResult<Department>> GetById(int id, [FromServices] DataContext context)
      {
         try
         {
            var department = await context.Department.Include(x => x.Employees).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
               return NotFound();

            return Ok(department);
         }
         catch (System.Exception)
         {

            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }


      // Função GetSupervisorById



      [HttpPost]
      [Route("")]
      public async Task<ActionResult<Department>> Post([FromServices] DataContext context, [FromBody] Department model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         try
         {
            context.Department.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
         }
         catch (Exception)
         {
            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }

      [HttpPut]
      [Route("{id:int}")]
      public async Task<ActionResult<Department>> Put(int id, [FromBody] Department model, [FromServices] DataContext context)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         if (model.Id != id)
            return NotFound();
         try
         {
            context.Entry<Department>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
      public async Task<ActionResult<Department>> Delete(int id, [FromServices] DataContext context)
      {
         var department = await context.Department.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
         if (department == null)
            return NotFound();
         try
         {
            context.Department.Remove(department);
            await context.SaveChangesAsync();
            return Ok(new { message = "Departamento removido com sucesso" });
         }
         catch (System.Exception)
         {
            return BadRequest(new { message = "Desculpe ocorreu um erro. Por favor, tente novamente mais tarde" });
         }
      }
   }
}