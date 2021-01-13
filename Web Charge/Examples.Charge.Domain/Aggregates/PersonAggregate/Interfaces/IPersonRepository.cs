using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> FindAllAsync();
        Task<Person> FindById(int id);
        Task Remove(int id);
        Task<Person> Add(Person person);
        Task Update(Person person);

    }
}
