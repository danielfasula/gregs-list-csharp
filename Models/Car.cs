using System;

namespace gregs_list_csharp.Models
{
    public class Car
    {


        public Car(string make, string model, int year, int miles, int price)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Miles = miles;
            this.Price = price;

        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
        public int Price { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}