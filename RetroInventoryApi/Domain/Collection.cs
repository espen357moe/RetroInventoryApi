namespace RetroInventoryApi.Domain
{
    public class Collection
    {
        public Guid Id { get; private set; }
        public string? Name { get; set; }
        public ICollection<Group>? Groups { get; set; }

        protected Collection()
        {

        }

        public Collection(string? name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
