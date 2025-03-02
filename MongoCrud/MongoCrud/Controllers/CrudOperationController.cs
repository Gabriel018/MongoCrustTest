using Microsoft.AspNetCore.Mvc;
using MongoCrud.Data.Model;
using MongoCrud.Services;

namespace MongoCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        public  readonly MongoService _mongoService;

        public CrudOperationController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpGet]
        public async Task<List<Funcionario>> Get() =>
            await _mongoService.GetAll();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Funcionario>> Get(string id)
        {
            var book = await _mongoService.GetById(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Funcionario funcionario)
        {
            await _mongoService.CreateAsync(funcionario);

            return CreatedAtAction(nameof(Get), new { id = funcionario.Id }, funcionario);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Funcionario Updatefuncionario)
        {
            var funcionario = await _mongoService.GetById(id);

            if (funcionario is null)
            {
                return NotFound();
            }

            Updatefuncionario.Id = funcionario.Id;

            await _mongoService.UpdateAsync(id, Updatefuncionario);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _mongoService.GetById(id);

            if (book is null)
            {
                return NotFound();
            }

            await _mongoService.DeleteAsync(id);

            return NoContent();
        }
    }
}
