using target_backend.Dao;
using target_backend.Models;

namespace target_backend.Repository
{
    public class PersonRepository
    {
        private readonly DaoPerson _daoPerson;

        public PersonRepository() {
            _daoPerson = new DaoPerson();
        }

        public List<Person> GetPeople {
            get
            {
                return _daoPerson.GetPeople();
            }
        }

        public void InsertPerson(Person person)
        {
            _daoPerson.InsertPerson(person);
        }

        public void UpdatePerson(Person person, int Id)
        {
            _daoPerson.UpdatePerson(person, Id);
        }

        public void DeletePerson(int Id)
        {
            _daoPerson.DeletePerson(Id);
        }
    }
}
