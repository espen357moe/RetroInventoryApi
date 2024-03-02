namespace RetroInventoryApi.Domain
{
    public sealed class ItemGroup
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        // public ICollection<Item>? Items { get; set; }
    }
}