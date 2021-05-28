using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.FilReq.Fil
{
    public class Fil2Model : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public Fil2Model(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Deposit> Deposit { get; set; }
        public Currency Currency { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Currency = _context.Currency.First(m => m.CurId == id);

            if (Currency == null)
            {
                return NotFound();
            }
            Deposit = await _context.Deposit
                .Include(e => e.Cur).Where(m => m.CurId == Currency.CurId).ToListAsync();
            return Page();
        }
    }
}