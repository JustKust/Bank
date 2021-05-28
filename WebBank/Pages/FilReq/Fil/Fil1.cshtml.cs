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
    public class Fil1Model : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public Fil1Model(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public Position Position { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = _context.Position.First(m => m.PosId == id);

            if (Position == null)
            {
                return NotFound();
            }
            Employee = await _context.Employee
                .Include(e => e.Pos).Where(m => m.PosId == Position.PosId).ToListAsync();
            return Page();
        }
    }
}