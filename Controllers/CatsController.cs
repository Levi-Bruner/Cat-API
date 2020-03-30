using System;
using System.Collections.Generic;
using catApi.Models;
using Microsoft.AspNetCore.Mvc;
using catApi.DB;

namespace catApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CatsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get()
    {
      try
      {
        return Ok(FakeDB.cats);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{catId}")]
    public ActionResult<Cat> Get(string catId)
    {
      try
      {
        Cat found = FakeDB.cats.Find(c => c.Id == catId);
        if (found == null)
        {
          throw new Exception("Invalid ID");
        }
        return Ok(found);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Cat> Create([FromBody] Cat newCat)
    {
      try
      {
        FakeDB.cats.Add(newCat);
        return Created($"api/cat/{newCat.Id}", newCat);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Cat> Edit(string id, [FromBody] Cat updatedCat)
    {
      try
      {
        Cat catToUpdate = FakeDB.cats.Find(c => c.Id == id);
        if (catToUpdate == null)
        {
          throw new Exception();
        }
        catToUpdate.Name = updatedCat.Name;
        catToUpdate.Breed = updatedCat.Breed;
        catToUpdate.Age = updatedCat.Age;
        return Ok(catToUpdate);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        Cat catToRemove = FakeDB.cats.Find(c => c.Id == id);
        if (catToRemove == null)
        {
          throw new Exception("bad ID");
        }
        FakeDB.cats.Remove(catToRemove);
        return Ok("Successfully Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}