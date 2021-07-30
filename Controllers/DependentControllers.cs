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
   [Route("v1/employees")] // https://localhost:5001/v1/employee/dependent
   public class DependentController : ControllerBase
   {



      [HttpGet]
      [Route("{employeeId:int}/dependents")] // https://localhost:5001/v1/employee/1/dependent
      public async Task<ActionResult<List<Dependent>>> Get(int employeeId, [FromServices] DataContext context)
      {
         try
         {
            var dependents = await context.Dependents.AsNoTracking().Where(y => y.EmployeeId == employeeId).ToListAsync();
            if (dependents == null)
               return NotFound(new { message = "Esse funcionário não possui dependentes" });
            return Ok(dependents);
         }
         catch (System.Exception e)
         {

            return BadRequest(new { message = $"{e.Message}" });
         }
      }


      [HttpGet]
      [Route("{employeeId:int}/dependents/{dependentsId}")] // https://localhost:5001/v1/employee/1/dependent
      public async Task<ActionResult<Dependent>> GetById(int employeeId, int dependentsId, [FromServices] DataContext context)
      {
         try
         {
            var dependents = await context.Employees.Include(x => x.Dependents).FirstOrDefaultAsync(y => y.Id == employeeId);
            if (dependents == null)
               return NotFound(new { message = "Esse funcionário não possui dependentes" });

            foreach (var item in dependents.Dependents)
               if (item.Id == dependentsId)
                  return Ok(item);

            return NotFound();
         }
         catch (System.Exception e)
         {

            return BadRequest(new { message = $"{e.Message}" });
         }
      }

      [HttpPost]
      [Route("{employeeId:int}/dependents")] // https://localhost:5001/v1/employee/1/dependent

      public async Task<ActionResult<Dependent>> Post(int employeeId, [FromServices] DataContext context, [FromBody] Dependent model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);
         var temp = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == employeeId);

         if (temp == null)
            return NotFound();

         if (model.EmployeeId != employeeId)
            return NotFound();

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
      [Route("{employeeId:int}/dependents/{dependentId}")] // https://localhost:5001/v1/employee/3/dependent/1

      public async Task<ActionResult<Dependent>> Get(int employeeId, int dependentId, [FromServices] DataContext context, [FromBody] Dependent model)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);
         var temp = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == employeeId);
         if (model.Id != dependentId)
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
      [Route("{employeeId:int}/dependents/{dependentId}")] // https://localhost:5001/v1/employee/dependent/2

      public async Task<ActionResult<Dependent>> Delete(int dependentId, [FromServices] DataContext context)
      {
         var dependent = await context.Dependents.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dependentId);
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