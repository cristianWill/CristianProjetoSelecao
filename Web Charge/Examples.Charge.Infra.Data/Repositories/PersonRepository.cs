using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person);
        
        public async Task<Person> FindById(int id)
        {
            var entity = await _context.Person.FindAsync(id);
            _context.Entry(entity).Collection("Phones").Load();

            foreach (var ph in entity.Phones)
                _context.Entry(ph).Reference("PhoneNumberType").Load();

            return entity;
        }

        public async Task Remove(int id)
        {
            var p = await _context.Person.FindAsync(id);
            _context.Person.Remove(p);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> Add(Person person)
        {
            var p = await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();

            return p.Entity;
        }

        public async Task Update(Person person)
        {
            var p = _context.Person.Update(person);
            await _context.SaveChangesAsync();
        }
    }
}
