using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }

        public async Task<Person> Add(Person person)
        {
            return await _personRepository.Add(person);
        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> FindAsync(int id)
        {
            return await _personRepository.FindById(id);
        }

        public async Task Remove(int id)
        {
            await _personRepository.Remove(id);
        }

        public async Task Update(Person person)
        {
            await _personRepository.Update(person);
        }
    }
}
