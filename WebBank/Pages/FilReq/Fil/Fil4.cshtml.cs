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
    public class Fil4Model : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public Fil4Model(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Depositor> Depositor { get; set; }
        public Depositor Depositor_ { get; set; }
        public async Task<IActionResult> OnGetAsync(string Mark)
        {

            if (Mark == null)
            {
                return NotFound();
            }

            Depositor_ = _context.Depositor.First(m => m.DepRafMark == Mark);

            if (Depositor_ == null)
            {
                return NotFound();
            }
            Depositor = await _context.Depositor
                 .Include(e => e.Dep).Where(m => m.DepRafMark == Depositor_.DepRafMark).ToListAsync();
            return Page();
        }
    }
}