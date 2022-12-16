using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grama_Tudor_Ionut_Lab2.Data;
using Grama_Tudor_Ionut_Lab2.Models;

namespace Grama_Tudor_Ionut_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Grama_Tudor_Ionut_Lab2.Data.Grama_Tudor_Ionut_Lab2Context _context;

        public DetailsModel(Grama_Tudor_Ionut_Lab2.Data.Grama_Tudor_Ionut_Lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.Include(m => m.Member)
                .Include(m => m.Book).ThenInclude(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
