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
    public class Fil3Model : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public Fil3Model(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Depositor> Depositor { get; set; }
        public Deposit Deposit { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deposit = _context.Deposit.First(m => m.DepId == id);

            if (Deposit == null)
            {
                return NotFound();
            }
            Depositor = await _context.Depositor
                .Include(e => e.Dep).Where(m => m.DepId == Deposit.DepId).ToListAsync();
            return Page();
        }
    }
}