using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Driver : IEntity
    {
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Jméno")]
        public virtual string DriverName { get; set; }

        [Required]
        [Display(Name = "Příjmení")]
        public virtual string DriverSurname { get; set; }

        [Display(Name = "Email")]
        public virtual string DriverEmail { get; set; }

        [Display(Name = "Telefon")]
        public virtual string DriverPhoneNumber { get; set; }

        public virtual Car CarId { get; set; }

        [NotMapped]
        [Display(Name = "Aktuální řidič")]
        public virtual string NameSurname 
        {
            get
            {
                return (DriverName + " " + DriverSurname);
            }

            set 
            {

            }
        }
    }
}
