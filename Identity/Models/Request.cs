using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage ="Naziv ne može sadržati više od 50 karaktera")]
        [Display(Name = "Naziv zahteva")]
        public string RequestName { get; set; }
        [Display(Name = "Sektor")]
        public Department? Department { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Opis zahteva")]
        public string Description { get; set; }
        public Status Status { get; set; }
        [Required]
        [Display(Name = "Datum unosa")]
        [DataType(DataType.Date)]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")] izmenjeno jer ne radi edit datuma sa ApplyFormatInEditMode, ali ovako prikazuje razlicit format u pregledu i izmeni
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")] 
        public DateTime DateAccepted { get; set; }
    }
}
