using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebBank.Pages.FilReq
{
    public class IndexModel : PageModel
    {
        private readonly WebBank.Data.BankContext _context;

        public IndexModel(WebBank.Data.BankContext context)
        {
            _context = context;
        }
        public List<SelectListItem> Position { get; set; }
        public List<SelectListItem> Currency { get; set; }
        public List<SelectListItem> Deposit { get; set; }
        public List<SelectListItem> Mark { get; set; }

        public IActionResult OnGet()
        {
            Position = _context.Position.Select(p =>
                new SelectListItem
                {
                    Value = p.PosId.ToString(),
                    Text = p.PosName
                }).ToList();

            Currency = _context.Currency.Select(p =>
                new SelectListItem
                {
                    Value = p.CurId.ToString(),
                    Text = p.Name
                }).ToList();

            Deposit = _context.Deposit.Select(p =>
                new SelectListItem
                {
                    Value = p.DepId.ToString(),
                    Text = p.DepName
                }).ToList();

            Mark = _context.Depositor.Select(p =>
                new SelectListItem
                {
                    Value = p.DepRafMark.ToString(),
                    Text = p.DepRafMark
                }).ToList();

            return Page();
        }

    }
}