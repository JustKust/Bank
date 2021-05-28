using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebBank.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Depositor = new HashSet<Depositor>();
        }

        [Display(Name = "Код сотрудника")]
        public long EmId { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [Display(Name = "Телефон")]
        public string Telephone { get; set; }
        [Display(Name = "Возраст")]
        public long Age { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Должность")]
        public long PosId { get; set; }
        [Display(Name = "Должность")]
        public virtual Position Pos { get; set; }
        public virtual ICollection<Depositor> Depositor { get; set; }
    }
}
