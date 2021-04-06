using System;

namespace gregs_list_csharp.Models
{
    public class House
    {

        public House(int bedrooms, int bathrooms, int levels, string description, int price)
        {
            this.Bedrooms = bedrooms;
            this.Bathrooms = bathrooms;
            this.Levels = levels;
            this.Description = description;
            this.Price = price;
        }

        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Levels { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Id { get; private set; } = Guid.NewGuid().ToString();
    }
}