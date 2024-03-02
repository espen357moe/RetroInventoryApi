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
                    Manufacturer = "Sega",
                    Model = "Sega Mega Drive console",
                    CosmeticCondition = CosmeticCondition.Pristine
                },
                new Item
                {
                    Manufacturer = "Sega",
                    Model = "Joypad",
                    CosmeticCondition = CosmeticCondition.Pristine
                },
                new Item
                {
                    Manufacturer = "Sega",
                    Model = "Joypad",
                    CosmeticCondition = CosmeticCondition.Pristine
                }
            };
        }        
    }
}