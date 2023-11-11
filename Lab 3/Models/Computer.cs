using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab_3.Models
{
    public class Computer
    {

        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę komputera!")]
        [MinLength(3, ErrorMessage = "Pole musi mieć co najmniej 3 znaki.")]
        [MaxLength(50, ErrorMessage = "Pole nie może mieć więcej niż 50 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać model procesora!")]
        [MinLength(2, ErrorMessage = "Pole musi mieć co najmniej 2 znaki.")]
        [MaxLength(50, ErrorMessage = "Pole nie może mieć więcej niż 50 znaków.")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Proszę podać ilość pamięci RAM!")]
        [Range(2, 512, ErrorMessage = "Pole musi mieć wartość między 2 a 512.")]
        public string MemoryRAM { get; set; }

        [Required(ErrorMessage = "Proszę podać model karty graficzną!")]
        [MinLength(2, ErrorMessage = "Pole musi mieć co najmniej 2 znaki.")]
        [MaxLength(50, ErrorMessage = "Pole nie może mieć więcej niż 50 znaków.")]
        public string GraphicsCard { get; set; }

        [Required(ErrorMessage = "Proszę podać producenta!")]
        [MinLength(2, ErrorMessage = "Pole musi mieć co najmniej 2 znaki.")]
        [MaxLength(50, ErrorMessage = "Pole nie może mieć więcej niż 50 znaków.")]
        public string Manufacturer { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę podać poprawną datę produkcji!")]
        [Range(typeof(DateTime), "1946-02-14", "2025-01-01", ErrorMessage = "Data nie znajduje się w przedziale 1946-02-14 - 2025-01-01.")]
        public DateTime ProductionDate { get; set; }

        public bool IsValid()
        {
            bool isName = Name != null;
            bool isProcessor = Processor != null;
            bool isMemoryRAM = MemoryRAM != null;
            bool isGraphicsCard = GraphicsCard != null;
            bool isManufacturer = Manufacturer != null;
            bool isProductionDate = ProductionDate != null;

            bool IsValid = isName && isProcessor && isMemoryRAM && isGraphicsCard && isManufacturer && isProductionDate;

            return IsValid;
        }
    }
}
