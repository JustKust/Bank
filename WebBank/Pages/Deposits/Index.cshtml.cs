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
    public class IndexModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public IndexModel(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Deposit> Deposit { get;set; }

        public async Task OnGetAsync()
        {
            Deposit = await _context.Deposit
                .Include(d => d.Cur).ToListAsync();
        }
    }
}
