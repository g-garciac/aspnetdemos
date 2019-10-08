using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPocs.Models
{
    public enum DayOfWeek
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
    public class BindingsDemoVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 100, maximum: 200, ErrorMessage = "El valor indicado no está en el rango permitido")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "El día de la semana debe ser indicado")]
        [DisplayName("Day of Week")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public DateTime Day { get; set; }
    }
}
