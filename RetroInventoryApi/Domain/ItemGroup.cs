namespace RetroInventoryApi.Domain
{
    public class ItemGroup
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
