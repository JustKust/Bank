using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.Depositors
{
    public class EditModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public EditModel(WebBank.Data.BankContext context)
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
           ViewData["EmId"] = new SelectList(_context.Employee, "EmId", "Adress");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Depositor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositorExists(Depositor.DepostorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DepositorExists(long id)
        {
            return _context.Depositor.Any(e => e.DepostorId == id);
        }
    }
}
