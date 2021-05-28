using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebBank.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Deposit = new HashSet<Deposit>();
        }

        [Display(Name = "Код валюты")]
        public long CurId { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Обменный курс")]
        public double ExchangeRate { get; set; }

        public virtual ICollection<Deposit> Deposit { get; set; }
    }
}
