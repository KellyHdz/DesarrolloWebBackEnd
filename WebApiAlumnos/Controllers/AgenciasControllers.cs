using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAlumnos.Entidades;
//using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace WebApiAlumnos.Controllers
{
    [ApiController]
    [Route("api/agencias")]
    public class AgenciasController: ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public AgenciasController (ApplicationDBContext context)
        {
            this.dBContext = context;
        }

        [HttpGet]
        [HttpGet("/listadoAgencia")]
        public async Task<ActionResult<List<Agencia>>> GetAll()
        {
            return await dBContext.Agencias.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Agencia>> GetById(int id)
        {
            return await dBContext.Agencias.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Agencia agencia)
        {
            var existeAuto = await dBContext.Agencias.AnyAsync(x => x.Id == agencia.AutoId);
        
            if(!existeAuto)
            {
                return BadRequest($"No existe el auto con el id: {agencia.AutoId}");
            }

            dBContext.Add(agencia);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Agencia agencia, int id)
        {
            var exist = await dBContext.Agencias.AnyAsync(x => x.Id == id);

            if(!exist)
            {
                return NotFound("La agencia especificada no existe. ");
            }
            
            if(agencia.Id != id)
            {
                return BadRequest("El id de la clase no coincide con el establecido en la url. ");
            }

            dBContext.Update(agencia);
            await dBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dBContext.Agencias.AnyAsync(x => x.Id == id);
            if(!exist)
            {
                return NotFound("El recurso no fue encontrado. ");
            }

            //var validateRelation = await dbContext.AutoAgencia.AnyAsync
            
            dBContext.Remove(new Agencia { Id = id });
            await dBContext.SaveChangesAsync();
            return Ok();
        }
    }

    

    
}
