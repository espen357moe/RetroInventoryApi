using Microsoft.AspNetCore.Mvc;
using RetroInventoryApi.Domain;

namespace RetroInventoryApi.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public sealed class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IEnumerable<Item> _items;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
            _items = MockCreator.CreateItems();
        }        

        [HttpGet(Name = "GetItems")]
        public IEnumerable<Item> GetItems()
        {
            return _items;  
        }
    }

    [ApiController]
    [Route("[controller]")]
    public sealed class ItemGroupController : ControllerBase
    {
        private readonly ILogger<ItemGroupController> _logger;
        private readonly IEnumerable<ItemGroup> _itemGroups;

        public ItemGroupController(ILogger<ItemGroupController> logger)
        {
            _logger = logger;
            _itemGroups = MockCreator.CreateItemGroups();
        }

        [HttpGet(Name = "GetItemGroups")]
        public IEnumerable<ItemGroup> GetItemGroups()
        {
            return _itemGroups;             
        }
    }
}
