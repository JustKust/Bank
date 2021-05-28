using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.Depositors
{
    public class CreateModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public CreateModel(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmId"] = new SelectList(_context.Employee, "EmId", "Adress");
            return Page();
        }

        [BindProperty]
        public Depositor Depositor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Depositor.Add(Depositor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
