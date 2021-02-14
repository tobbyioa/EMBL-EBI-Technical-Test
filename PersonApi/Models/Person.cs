
namespace PersonApi.Models
{
    // Mpdel for our database object entries
    public class Person
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string age { get; set; }
        public string favourite_colour { get; set; }
    }
}
