using Microsoft.AspNetCore.Mvc;
using target_backend.Repository;
using target_backend.Models;
using Microsoft.AspNetCore.Cors;

namespace target_backend.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository _personRepository;

        public PersonController()
        {
            _personRepository = new PersonRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return _personRepository.GetPeople;
        }

        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _personRepository.InsertPerson(person);
        }

        [HttpPatch]
        [Route("{id}")]
        public void Update([FromRoute] int Id, [FromBody] Person person)
        {
            _personRepository.UpdatePerson(person, Id);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete([FromRoute] string Id)
        {
            _personRepository.DeletePerson(Convert.ToInt32(Id));
        }
    }

}