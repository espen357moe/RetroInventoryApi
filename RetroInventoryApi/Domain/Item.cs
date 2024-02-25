namespace RetroInventoryApi.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public string? Notes { get; set; }
        public string? Location { get; set; }
        public Condition Condition { get; set; }
    }
}
