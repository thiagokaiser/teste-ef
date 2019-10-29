using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteEf.Data;
using TesteEf.Models;

namespace TesteEf.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById([FromServices] DataContext context, int id)
        {
            var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Category>> Update(
            [FromServices] DataContext context,
            [FromBody] Category category)
        {

            context.Entry<Category>(category).State = EntityState.Modified;
            await context.SaveChangesAsync();
            
            return category;

        }
        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<Category>> Delete(
            [FromServices] DataContext context,
            [FromBody] Category category)
        {

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            
            return category;

        }
    }
}