using diary_api.Models;
using diary_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace diary_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase {
  public PersonController() {

  }

  [HttpGet]
  public ActionResult<List<Person>> GetAll() => PersonService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<Person> Get(int id) {
    var person = PersonService.Get(id);
    if (person == null)
      return NotFound();

    return person;
  }

  [HttpPost]
  public IActionResult CreatePerson(Person person){
    PersonService.Add(person);
    return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
  }

  [HttpPut("{id}")]
  public IActionResult UpdatePerson(int id, Person person){
    if (id != person.Id)
      return BadRequest();

    var existingPerson = PersonService.Get(id);
    if (existingPerson is null)
      return NotFound();

    PersonService.Update(person);

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult DeletePerson(int id){
    var person = PersonService.Get(id);
    if (person is null)
      return NotFound();

    PersonService.Delete(id);

    return NoContent();
  }

}
