using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>{
            new SuperHero {
                Id = 1,
                Name = "Batman",
                FirstName = "Bruce",
                LastName = "Wayne",
                Place = "Gotham City"
            },
            new SuperHero {
                Id = 2,
                Name = "Ironman",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Cleveland"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
                return NotFound("Hero not found.");
            
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero, int id)
        {
            var heroToUpdate = heroes.FirstOrDefault(h => h.Id == id);
            if (heroToUpdate == null)
                return NotFound("Hero not found.");
            
            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.LastName = hero.LastName;
            heroToUpdate.Place = hero.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroToDelete = heroes.FirstOrDefault(h => h.Id == id);
            if (heroToDelete == null)
                return NotFound("Hero not found.");
            
            heroes.Remove(heroToDelete);

            return Ok(heroToDelete);
        }
    }
}