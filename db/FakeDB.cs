using System.Collections.Generic;
using gregs_list_csharp.Models;

namespace gregs_list_csharp.db
{
    public class FakeDB
    {
        public static List<Car> Cars { get; set; } = new List<Car>();
        public static List<House> Houses { get; set; } = new List<House>();
        public static List<Job> Jobs { get; set; } = new List<Job>();
    }
}