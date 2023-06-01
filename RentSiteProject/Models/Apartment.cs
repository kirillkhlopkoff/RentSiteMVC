using RentSiteProject.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace RentSiteProject.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public string Details { get; set; }
        public string MainPhoto { get; set; }

        /*public List<Photo> Photos { get; set; }
        public string MainPhoto
        {
            get { return Photos?.FirstOrDefault()?.Url; }
        }*/

        /*public List<string> Photos { get; set; } // Список фотографий
        public string MainPhoto { get; set; } // Главная фотография*/

    }
}
