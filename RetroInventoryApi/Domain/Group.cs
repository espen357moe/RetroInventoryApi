namespace RetroInventoryApi.Domain
{
    public sealed class Group
    {
        public Guid Id { get; private set; }
        public string? Name { get; set; }
        public ICollection<Item>? Items { get; set; }

        protected Group()
        {

        }

        public Group(string? name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}