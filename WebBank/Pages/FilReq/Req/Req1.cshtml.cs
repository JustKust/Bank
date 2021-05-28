using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebBank.Data;
using WebBank.Models;

namespace WebBank.Pages.FilReq.Req
{
    public class Req1Model : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public Req1Model(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public IList<Position> Position { get; set; }
        public async Task OnGetAsync()
        {
            Employee = await _context.Employee.ToListAsync();
            Position = await _context.Position.ToListAsync();
        }
    }
}