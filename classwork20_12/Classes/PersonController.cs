using Microsoft.AspNetCore.Mvc;

namespace classwork20_12.Classes
{
    [Route("/person")]
    public class PersonController : Controller
    {
        private readonly List<Person> people = [new("Ivan", "Ivanov", DateTime.Today.Date, "Russia")];

        [HttpGet("all", Name = "persons")]
        public IActionResult GetAllPersons()
        {
            return Ok(people);
        }

        //[HttpGet("{name}/{surname}/{birthday:datetime}")]
        [HttpGet("getperson", Name = "get_person")]
        public IActionResult GetPerson(string name, string surname, DateTime birthday)
        {
            Person? person = people
                .Find(p => p.Name == name && 
                      p.Surname == surname && 
                      p.Birthday == birthday);

            if (person is null)
            {
                return NotFound($"The person you are looking for could not be found! Your query: {name} {surname} {birthday}");
            }

            return Ok(person);
        }

        [HttpGet("writeperson", Name = "write_person")]
        public IActionResult OutputPerson(string name, string surname)
        {
            Person? person = people
               .Find(p => p.Name == name &&
                     p.Surname == surname);

            if (person is null)
            {
                return NotFound($"The person you are looking for could not be found! Your query: {name} {surname}");
            }

            ConsolePersonWriter writer = new();
            person.Display(writer);
            FilePersonWriter file_writer = new("person.txt");
            person.Display(file_writer);

            return Ok("Wrote to console and file!");
        }
    }
}
