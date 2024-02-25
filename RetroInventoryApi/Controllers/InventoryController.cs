using Microsoft.AspNetCore.Mvc;
using RetroInventoryApi.Domain;

namespace RetroInventoryApi.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }        

        [HttpGet(Name = "GetItems")]
        public IEnumerable<Item> GetItems()
        {
            return new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = "Sega",
                    Model = "Sega Mega Drive console",
                    Condition = Condition.Pristine
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = "Sega",
                    Model = "Joypad",
                    Condition = Condition.Pristine
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Manufacturer = "Sega",
                    Model = "Joypad",
                    Condition = Condition.Pristine
                }
            };
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class ItemGroupController : ControllerBase
    {
        private readonly ILogger<ItemGroupController> _logger;

        public ItemGroupController(ILogger<ItemGroupController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetItemGroups")]
        public IEnumerable<ItemGroup> GetItemGroups()
        {
            return new List<ItemGroup>
            {
                new ItemGroup
                {
                    Id = Guid.NewGuid(),
                    Name = "Sega Mega Drive",
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Manufacturer = "Sega",
                            Model = "Sega Mega Drive console",
                            Condition = Condition.Pristine
                        },
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Manufacturer = "Sega",
                            Model = "Joypad",
                            Condition = Condition.Pristine
                        },
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Manufacturer = "Sega",
                            Model = "Joypad",
                            Condition = Condition.Pristine
                        }
                    }
                },
                new ItemGroup
                {
                    Id = Guid.NewGuid(),
                    Name = "Midi Modules",
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Manufacturer = "Roland",
                            Model = "MT-32",
                            Condition = Condition.Pristine
                        },
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Manufacturer = "Roland",
                            Model = "SC-55",
                            Condition = Condition.Pristine
                        },
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Manufacturer = "Roland",
                            Model = "SC-88",
                            Condition = Condition.Pristine
                        }
                    }
                }
            };
        }
    }
}
