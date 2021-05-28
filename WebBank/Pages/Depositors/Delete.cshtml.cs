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
    public class DeleteModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public DeleteModel(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Depositor = await _context.Depositor.FindAsync(id);

            if (Depositor != null)
            {
                _context.Depositor.Remove(Depositor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
