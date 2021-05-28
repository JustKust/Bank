using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.Currencies
{
    public class DeleteModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public DeleteModel(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Currency Currency { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Currency = await _context.Currency.FirstOrDefaultAsync(m => m.CurId == id);

            if (Currency == null)
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

            Currency = await _context.Currency.FindAsync(id);

            if (Currency != null)
            {
                _context.Currency.Remove(Currency);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
