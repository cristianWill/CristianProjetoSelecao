using System.Threading.Tasks;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonResponse> FindById(int id);
        Task<PersonResponse> Remove(int id);
        Task<PersonResponse> Add(PersonDto personDto);
        Task<PersonResponse> Update(PersonDto personDto);
    }
}