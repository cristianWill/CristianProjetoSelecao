using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> Add(PersonDto personDto)
        {
            var entity = _mapper.Map<Person>(personDto);
            await _personService.Add(entity);

            return new PersonResponse { 
                PersonObjects = new List<PersonDto> { _mapper.Map<PersonDto>(entity) } 
            };
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonResponse> FindById(int id)
        {
            var entity = await _personService.FindAsync(id);
            return new PersonResponse
            {
                PersonObjects = new List<PersonDto> { _mapper.Map<PersonDto>(entity) }
            };
        }

        public async Task<PersonResponse> Remove(int id)
        {
            await _personService.Remove(id);
            return new PersonResponse();
        }

        public async Task<PersonResponse> Update(PersonDto personDto)
        {
            var entity = _mapper.Map<Person>(personDto);
            await _personService.Update(entity);
            return new PersonResponse()
            {
                PersonObjects = new List<PersonDto>() { personDto }
            };
        }
    }
}
