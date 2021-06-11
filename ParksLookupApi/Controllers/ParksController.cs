using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookupApi.Models;
using System.Linq;
using System.Text.Json;
using System;

namespace ParksLookupApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksLookupApiContext _db;

    public ParksController(ParksLookupApiContext db)
    {
      _db = db;
    }

    //GET: parks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get()
    {
      return await _db.Parks.ToListAsync();
    }

    //POST: parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    //GET: parks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park selectedPark = await _db.Parks.FindAsync(id);
      if (selectedPark == null)
      {
        return NotFound();
      }

      return selectedPark;
    }

    // PUT: parks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(park).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return Ok(park);
    }

    //DELETE: parks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      Park selectedPark = await _db.Parks.FindAsync(id);
      if (selectedPark == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(selectedPark);
      await _db.SaveChangesAsync();

      return Ok();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}