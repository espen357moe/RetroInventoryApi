﻿namespace RetroInventoryApi.Domain
{
    public sealed class Item
    {
        public Guid Id { get; private set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public string? Notes { get; set; }
        public string? Location { get; set; }
        public CosmeticCondition CosmeticCondition { get; set; }
        public FunctionalCondition FunctionalCondition { get; set; }        

        protected Item()
        {

        }

        public Item()
        {
            Id = Guid.NewGuid();
        }
    }
}