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
  public class CategoriesController : ControllerBase
  {
    private readonly ParksLookupApiContext _db;

    public CategoriesController(ParksLookupApiContext db)
    {
      _db = db;
    }

    //GET: categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> Get()
    {
      return await _db.Categories.ToListAsync();
    }

    //POST: categories
    [HttpPost]
    public async Task<ActionResult<Category>> Post(Category category)
    {
      _db.Categories.Add(category);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
    }

    //GET: categories/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
      Category selectedCategory = await _db.Categories.FindAsync(id);
      if (selectedCategory == null)
      {
        return NotFound();
      }

      return selectedCategory;
    }

    // PUT: categories/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Category category)
    {
      if (id != category.CategoryId)
      {
        return BadRequest();
      }

      _db.Entry(category).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CategoryExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return Ok(category);
    }

    //DELETE: categories/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      Category selectedCategory = await _db.Categories.FindAsync(id);
      if (selectedCategory == null)
      {
        return NotFound();
      }

      _db.Categories.Remove(selectedCategory);
      await _db.SaveChangesAsync();

      return Ok();
    }

    private bool CategoryExists(int id)
    {
      return _db.Categories.Any(e => e.CategoryId == id);
    }
  }
}