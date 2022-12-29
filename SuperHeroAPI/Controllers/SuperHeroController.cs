using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext context;

        public SuperHeroController(DataContext context) 
        {
            this.context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            context.SuperHeroes.Add(hero);
            await context.SaveChangesAsync();

            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
        {
            var dbHero = await context.SuperHeroes.FindAsync(hero.Id);
            if (dbHero == null)
            {
                return BadRequest("Hero not found.");
            }

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await context.SaveChangesAsync();

            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var dbHero = await context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
            {
                return BadRequest("Hero not found.");
            }

            context.SuperHeroes.Remove(dbHero);

            await context.SaveChangesAsync();

            return Ok(await context.SuperHeroes.ToListAsync());
        }

    }
}
