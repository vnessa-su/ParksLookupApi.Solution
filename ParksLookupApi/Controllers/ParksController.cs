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
      park.SetGeocodeData();
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

    //PUT: parks/{id}
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

    //PUT: parks/{id}/category/{categoryId}
    [HttpPut("{id}/category/{categoryId}")]
    public async Task<IActionResult> EditCategory(int id, int categoryId)
    {
      Park selectedPark = await _db.Parks.FindAsync(id);
      if (selectedPark == null)
      {
        return NotFound();
      }

      selectedPark.CategoryId = categoryId;
      _db.Entry(selectedPark).State = EntityState.Modified;
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

      return Ok(selectedPark);
    }

    //DELETE: parks/{id}/category
    [HttpDelete("{id}/category")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      Park selectedPark = await _db.Parks.FindAsync(id);
      if (selectedPark == null)
      {
        return NotFound();
      }

      selectedPark.CategoryId = 0;
      _db.Entry(selectedPark).State = EntityState.Modified;
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

      return Ok(selectedPark);
    }

    //GET: parks/random
    [HttpGet("random")]
    public async Task<ActionResult<Park>> GetRandom()
    {
      List<Park> allParks = await _db.Parks.ToListAsync();
      int numberOfEntries = allParks.Count;
      Random randomNumberGenerator = new Random();
      int randomIndex = randomNumberGenerator.Next(0, numberOfEntries);
      Park randomPark = allParks[randomIndex];
      return randomPark;
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}