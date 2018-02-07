using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.LibraryModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
    }
}