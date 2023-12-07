using Microsoft.AspNetCore.Mvc;
using Poultry.Application.Services.FoodServices;
using Poultry.Domain.Entities;

namespace Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodServiceController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetFoodServices()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoodService(FoodServiceRequestDto chicken)
        {
            return HandleResult(await Mediator.Send(new Create.Command
            {
                FoodService = new FoodService
                {
                    FoodType = chicken.FoodType,
                    Amount = chicken.Amount,
                }
            }));
        }

        [HttpPut]
        public async Task<IActionResult> EditFoodService(FoodServiceRequestDto chicken)
        {
            return HandleResult(await Mediator.Send(new Edit.Command
            {
                FoodService = new FoodService
                {
                    Id = chicken.Id.Value,
                    Amount = chicken.Amount,
                    FoodType = chicken.FoodType
                }
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFoodService(long id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
