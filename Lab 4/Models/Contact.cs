using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab_4.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Proszę podać imię!")]
        public string Name { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Nieprawidłowy format email!")]
        [Required(ErrorMessage = "Proszę podać poprawny email!")]
        public string Email { get; set; }

        [Display(Name = "Tytuł")]
        [MinLength(length: 5, ErrorMessage = "Tytuł musi mieć co najmniej 5 znaków!")]
        [Required(ErrorMessage = "Proszę wpisz tytuł!")]
        public string Subject { get; set; }

        [Display(Name = "Wiadomość")]
        [MinLength(length: 5, ErrorMessage = "Wiadomość musi mieć co najmniej 5 znaków!")]
        [Required(ErrorMessage = "Proszę wpisz wiadomość!")]
        public string Message { get; set; }

        [Display(Name = "Priorytet")]
        [EnumDataType(typeof(Priority), ErrorMessage = "Nieprawidłowy priorytet.")]
        [Required(ErrorMessage = "Pole Priorytet jest wymagane.")]
        public Priority Priority { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Pole Data jest wymagane.")]
        public DateTime Date { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime Created { get; set; }
    }
}
