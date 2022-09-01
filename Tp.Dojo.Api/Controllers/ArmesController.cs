using Microsoft.AspNetCore.Mvc;
using Tp.Dojo.Api.Models;
using TpDojo.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tp.Dojo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmesController : ControllerBase
    {
        private readonly ArmeService armeService;

        public ArmesController(ArmeService armeService)
        {
            this.armeService = armeService;
        }
        // GET: api/<ArmesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this.armeService.GetArmesAsync());
        }

        // GET api/<ArmesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return this.Ok(await this.armeService.GetArmeByIdAsync(id));
        }

        // POST api/<ArmesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArmeViewModel armeViewModel)
        {
            var armeDto = ArmeViewModel.ToArmeDto(armeViewModel);
            await this.armeService.AddArmeAsync(armeDto);
            return this.Created("", armeViewModel);
        }

        // PUT api/<ArmesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ArmeViewModel armeViewModel)
        {
            if (id != armeViewModel.Id)
            {
                return this.BadRequest();
            }
            var armeDto = ArmeViewModel.ToArmeDto(armeViewModel);
            await this.armeService.UpdateArmeAsync(armeDto);
            return this.NoContent();
        }


        // DELETE api/<ArmesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Ok(this.armeService.RemoveArmeAsync(id));
        }
    }
}
