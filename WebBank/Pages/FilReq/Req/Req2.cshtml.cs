using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.FilReq.Req
{
    public class Req2Model : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public Req2Model(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Deposit> Deposit { get; set; }
        public IList<Currency> Currency { get; set; }
        public async Task OnGetAsync()
        {
            Deposit = await _context.Deposit.ToListAsync();
            Currency = await _context.Currency.ToListAsync();
        }
    }
}