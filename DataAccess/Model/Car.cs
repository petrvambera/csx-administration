using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Car : IEntity
    {
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Tovární značka")]
        public virtual string CarMark { get; set; }

        [Required]
        [Display(Name = "Model")]
        public virtual string CarModel { get; set; }

        [Required]
        [Display(Name = "Rok výroby")]
        public virtual int YearOfManufacture { get; set; }

        [Required]
        [Display(Name = "Výkon motoru")]
        public virtual int EnginePower { get; set; }

        [Required]
        [Display(Name = "Volný vůz")]
        public virtual bool IsFree { get; set; }

        [Display(Name = "Aktuální řidič")]
        public virtual Driver CurrentDriver { get; set; }
    }
}
