﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFor_Country.Models;
using Microsoft.AspNetCore.Authorization;

namespace APIFor_Country.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Districts
       // [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
        {
            return await _context.Districts.ToListAsync();
        }

        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<District>> GetDistrict(int id)
        {
            var district = await _context.Districts.FindAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return district;
        }

        // PUT: api/Districts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistrict(int id, District district)
        {
            if (id != district.Id)
            {
                return BadRequest();
            }

            _context.Entry(district).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Districts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<District>> PostDistrict(District district)
        {
            District district1 = new District();
            district1.Name = district.Name;
            _context.Districts.Add(district1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistrict", new { id = district.Id }, district);
        }

        // DELETE: api/Districts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistrictExists(int id)
        {
            return _context.Districts.Any(e => e.Id == id);
        }
    }
}
