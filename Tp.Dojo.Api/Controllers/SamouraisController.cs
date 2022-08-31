// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tp.Dojo.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using TpDojo.Business;

[Route("api/[controller]")]
[ApiController]
public class SamouraisController : ControllerBase
{
    private readonly SamouraiService samouraiService;

    public SamouraisController(SamouraiService samouraiService)
    {
        this.samouraiService = samouraiService;
    }


    // GET: api/<SamouraisController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return this.Ok(await this.samouraiService.GetSamouraisAsync());
    }

    // GET api/<SamouraisController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<SamouraisController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<SamouraisController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<SamouraisController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
