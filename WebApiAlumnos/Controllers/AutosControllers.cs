using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAlumnos.DTOs;
using WebApiAlumnos.Entidades;

namespace WebApiAlumnos.Controllers
{

    [ApiController]
    [Route ("api/autos")]
    public class AutosControllers : ControllerBase
    {

        private readonly ApplicationDBContext dBContext;

        public AutosControllers(ApplicationDBContext context)
        {
            this.dBContext = context;
        }


        [HttpGet
        public async Task<ActionResult<List<Auto>>> Get()
        {
            return await dBContext.Autos.Include(x => x.Agencias).ToListAsync();
        }
        /*public ActionResult<List<Auto>> Get()
        {
            return new List<Auto>()
            {
                new Auto() {Id = 1, Modelo = "Tsuru"},
                new Auto() {Id = 2, Modelo = "Jetta" }
            };
        }*/

        public async Task<ActionResult<List<Auto>>> Get()
        {
            return await dBContext.Auto.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Auto auto)
        {
            dBContext.Add(auto);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/alumnos/1
        public async Task<ActionResult> Put(Auto auto, int id)
        {
            if(auto.Id != id)
            {
                return BadRequest("El id del auto no coincide con el establecido en la url.");

            }

            dBContext.Update(auto);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dBContext.Auto.AnyAsync(x => x.Id == id);
            if(!exist)
            {
                return NotFound();
            }

            dBContext.Remove(new Auto()
            {
                Id = id
            });
            await dBContext.SaveChangesAsync();
            return Ok();
        }
        
    }


}


