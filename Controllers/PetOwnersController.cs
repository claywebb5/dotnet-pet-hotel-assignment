using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            // return new List<PetOwner>();
            return _context.PetOwners;
        }

        [HttpPost]
        public IActionResult Create(PetOwner petOwner) {
                _context.Add(petOwner);
                _context.SaveChanges();

             return CreatedAtAction(nameof(Create), new { id = petOwner.id }, petOwner);
        }
        
        // PUT /api/breads/:id
        // returns NoContent()
        // Bread must contain all fields that are NOT NULL
        // nullables will be filled with NULL if they are missing from the request body JSON
        [HttpPut("{id}")]
        public IActionResult Put(int id, PetOwner petOwner) {
            Console.WriteLine("in PUT");
            if (id != petOwner.id) {
                return BadRequest();
            }
            // update in DB
            _context.Update(petOwner);
            _context.SaveChanges();


            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Console.WriteLine("TRYNA DELETEA!!");
            PetOwner petOwner = _context.PetOwners.SingleOrDefault(p => p.id == id);

            if(petOwner is null) {
                return NotFound();
            }

            _context.PetOwners.Remove(petOwner);
            _context.SaveChanges(); // really make the change            

            // 204
        
                return NoContent();
        
        }
     }
}