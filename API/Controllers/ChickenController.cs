using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.Chickens;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChickenController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetChickens()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateChicken(ChickenRequestDto chicken)
        {
            return HandleResult(await Mediator.Send(
                new Create.Command
                {
                    Chicken = new Chicken
                    {
                        Age = chicken.Age,
                        ChickenType = chicken.ChickenType,
                        Gender = chicken.Gender,
                        LayingRate = chicken.LayingRate,
                        Weight = chicken.Weight
                    }
                }));
        }

        [HttpPut]
        public async Task<IActionResult> EditChicken(ChickenRequestDto chicken)
        {
            return HandleResult(await Mediator.Send(
                new Edit.Command
                {
                    Chicken = new Chicken
                    {
                        Id = chicken.Id.Value,
                        Age = chicken.Age,
                        ChickenType = chicken.ChickenType,
                        Gender = chicken.Gender,
                        LayingRate = chicken.LayingRate,
                        Weight = chicken.Weight
                    }
                }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChicken(long id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
