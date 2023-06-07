using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        // private static List<SuperHero> heroes = new List<SuperHero>{
        //     new SuperHero {
        //         Id = 1,
        //         Name = "Batman",
        //         FirstName = "Bruce",
        //         LastName = "Wayne",
        //         Place = "Gotham City"
        //     },
        //     new SuperHero {
        //         Id = 2,
        //         Name = "Ironman",
        //         FirstName = "Tony",
        //         LastName = "Stark",
        //         Place = "Cleveland"
        //     }
        // };

         private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return NotFound("Hero not found.");
            
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero, int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return NotFound("Hero not found.");
            
            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroToDelete = await _context.SuperHeroes.FindAsync(id);
            if (heroToDelete == null)
                return NotFound("Hero not found.");
            
            _context.SuperHeroes.Remove(heroToDelete);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        // [HttpGet]
        // public async Task<ActionResult<List<SuperHero>>> GetAll()
        // {
        //     return Ok(heroes);
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<SuperHero>> GetById(int id)
        // {
        //     var hero = heroes.FirstOrDefault(h => h.Id == id);
        //     if (hero == null)
        //         return NotFound("Hero not found.");
            
        //     return Ok(hero);
        // }

        // [HttpPost]
        // public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        // {
        //     heroes.Add(hero);
        //     return Ok(heroes);
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero, int id)
        // {
        //     var heroToUpdate = heroes.FirstOrDefault(h => h.Id == id);
        //     if (heroToUpdate == null)
        //         return NotFound("Hero not found.");
            
        //     heroToUpdate.Name = hero.Name;
        //     heroToUpdate.FirstName = hero.FirstName;
        //     heroToUpdate.LastName = hero.LastName;
        //     heroToUpdate.Place = hero.Place;

        //     return Ok(heroes);
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        // {
        //     var heroToDelete = heroes.FirstOrDefault(h => h.Id == id);
        //     if (heroToDelete == null)
        //         return NotFound("Hero not found.");
            
        //     heroes.Remove(heroToDelete);

        //     return Ok(heroToDelete);
        // }
    }
}