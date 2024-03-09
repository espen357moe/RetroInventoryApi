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
    public sealed class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly Repository _repository;

        public GroupController(ILogger<GroupController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetGroups")]
        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await _repository.GetGroups();
        }

        [HttpGet("{id}", Name = "GetGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Group>> GetGroup(Guid id)
        {
            var group = await _repository.GetGroup(id);

            if (group == null)
            {
                return NotFound();
            }

            return group;
        }

        [HttpPost(Name = "CreateGroup")]
        public async Task<ActionResult<Group>> CreateGroup(Group group)
        {
            await _repository.CreateGroup(group);
            return CreatedAtRoute("GetGroup", new { id = group.Id }, group);
        }

        [HttpPut(Name = "AddItemToGroup")]
        public async Task<ActionResult<Group>> AddItemToGroup(Guid itemId, Guid groupId)
        {
            var item = await _repository.GetItem(itemId);
            var group = await _repository.GetGroup(groupId);

            if (group == null || item == null)
            {
                return NotFound();
            }

            await _repository.AddItemToGroup(groupId, itemId);
            return CreatedAtRoute("GetGroup", new { id = group.Id }, group);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public sealed class CollectionController : ControllerBase
    {
        private readonly ILogger<CollectionController> _logger;
        private readonly Repository _repository;

        public CollectionController(ILogger<CollectionController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetCollections")]
        public async Task<IEnumerable<Collection>> GetCollections()
        {
            return await _repository.GetCollections();
        }

        [HttpGet("{id}", Name = "GetCollection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Collection>> GetCollection(Guid id)
        {
            var collection = await _repository.GetCollection(id);

            if (collection == null)
            {
                return NotFound();
            }

            return collection;
        }

        [HttpPost(Name = "CreateCollection")]
        public async Task<ActionResult<Collection>> CreateCollection(Collection collection)
        {
            await _repository.CreateCollection(collection);
            return CreatedAtRoute("GetCollection", new { id = collection.Id }, collection);
        }
    }   
}
