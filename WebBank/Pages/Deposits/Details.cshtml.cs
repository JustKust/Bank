using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.Deposits
{
    public class DetailsModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public DetailsModel(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public Deposit Deposit { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Deposit = await _context.Deposit
                .Include(d => d.Cur).FirstOrDefaultAsync(m => m.DepId == id);

            if (Deposit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
