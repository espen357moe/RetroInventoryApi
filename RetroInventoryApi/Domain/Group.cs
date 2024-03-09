namespace RetroInventoryApi.Domain
{
    public sealed class ItemGroup
    {
        public Guid Id { get; private set; }
        public string? Name { get; set; }
        public ICollection<Item>? Items { get; set; }

        public ItemGroup(string? name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}