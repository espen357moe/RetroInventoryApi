namespace RetroInventoryApi.Domain
{
    public static class MockCreator
    {
        public static IEnumerable<Item> CreateItems()
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

        public static IEnumerable<ItemGroup> CreateItemGroups()
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