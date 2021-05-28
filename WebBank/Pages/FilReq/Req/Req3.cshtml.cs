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
    public class Req3Model : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public Req3Model(WebBank.Data.BankContext context)
        {
            _context = context;
        }

        public IList<Depositor> Depositor { get; set; }
        public IList<Deposit> Deposit { get; set; }
        public IList<Employee> Employee { get; set; }
        public async Task OnGetAsync()
        {
            Depositor = await _context.Depositor.ToListAsync();
            Deposit = await _context.Deposit.ToListAsync();
            Employee = await _context.Employee.ToListAsync();
        }
    }
}