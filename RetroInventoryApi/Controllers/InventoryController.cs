using Microsoft.AspNetCore.Mvc;
using RetroInventoryApi.Database;
using RetroInventoryApi.Domain;

namespace RetroInventoryApi.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public sealed class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly Repository _repository;

        public ItemController(ILogger<ItemController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetItems")]
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _repository.GetItems();
        }

        [HttpGet("{id}", Name = "GetItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Item>> GetItem(Guid id)
        {
            var item = await _repository.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost(Name = "CreateItem")]
        public IActionResult CreateItem(Item item)
        {
            _repository.CreateItem(item);
            return CreatedAtRoute("GetItem", new { id = item.Id }, item);
        }

        [HttpDelete(Name = "DeleteItem")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = _repository.GetItem(id);
            
            if (item.Result == null)
            {
                return NotFound();
            }
            
            var deletionResult = await _repository.DeleteItem(id);
            
            if (!deletionResult)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }

    [ApiController]
    [Route("[controller]")]
    public sealed class ItemGroupController : ControllerBase
    {
        private readonly ILogger<ItemGroupController> _logger;
        private readonly Repository _repository;

        public ItemGroupController(ILogger<ItemGroupController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetItemGroups")]
        public async Task<IEnumerable<ItemGroup>> GetItemGroups()
        {
            return await _repository.GetItemGroups();
        }
    }
}
