using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalInstitutionERPApp.Models.LibraryModels
{
    public class BorrowedByVM
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int BorrowerId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}