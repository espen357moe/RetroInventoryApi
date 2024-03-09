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
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {
            await _repository.CreateItem(item);
            return CreatedAtRoute("GetItem", new { id = item.Id }, item);
        }

        [HttpDelete("{id}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item.Result == null)
            {
                return NotFound();
            }

            var deletionSuccessful = await _repository.DeleteItem(id);

            if (!deletionSuccessful)
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
        public async Task<IEnumerable<Group>> GetItemGroups()
        {
            return await _repository.GetItemGroups();
        }

        [HttpGet("{id}", Name = "GetItemGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Group>> GetItemGroup(Guid id)
        {
            var itemGroup = await _repository.GetItemGroup(id);

            if (itemGroup == null)
            {
                return NotFound();
            }

            return itemGroup;
        }

        [HttpPost(Name = "CreateItemGroup")]
        public async Task<ActionResult<Group>> CreateItemGroup(Group itemGroup)
        {
            await _repository.CreateItemGroup(itemGroup);
            return CreatedAtRoute("GetItemGroup", new { id = itemGroup.Id }, itemGroup);
        }

        [HttpPut(Name = "AddItemToItemGroup")]
        public async Task<ActionResult<Group>> AddItemToItemGroup(Guid itemId, Guid itemGroupId)
        {
            var item = await _repository.GetItem(itemId);
            var itemGroup = await _repository.GetItemGroup(itemGroupId);

            if (itemGroup == null || item == null)
            {
                return NotFound();
            }

            await _repository.AddItemToItemGroup(itemGroupId, itemId);
            return CreatedAtRoute("GetItemGroup", new { id = itemGroup.Id }, itemGroup);
        }
    }
}
