using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.Depositors
{
    public class DetailsModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public DetailsModel(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public Depositor Depositor { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Depositor = await _context.Depositor
                .Include(d => d.Em).FirstOrDefaultAsync(m => m.DepostorId == id);

            if (Depositor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
