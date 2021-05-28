using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.Positions
{
    public class IndexModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public IndexModel(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Position> Position { get;set; }

        public async Task OnGetAsync()
        {
            Position = await _context.Position.ToListAsync();
        }
    }
}
