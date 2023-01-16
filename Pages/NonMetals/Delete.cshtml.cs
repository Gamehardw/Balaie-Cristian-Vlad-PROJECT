using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Balaie_Cristian_Vlad_PROJECT.Data;
using Balaie_Cristian_Vlad_PROJECT.Models;

namespace Balaie_Cristian_Vlad_PROJECT.Pages.NonMetals
{
    public class DeleteModel : PageModel
    {
        private readonly Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext _context;

        public DeleteModel(Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public NonMetal NonMetal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NonMetal == null)
            {
                return NotFound();
            }

            var nonmetal = await _context.NonMetal.FirstOrDefaultAsync(m => m.ID == id);

            if (nonmetal == null)
            {
                return NotFound();
            }
            else 
            {
                NonMetal = nonmetal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.NonMetal == null)
            {
                return NotFound();
            }
            var nonmetal = await _context.NonMetal.FindAsync(id);

            if (nonmetal != null)
            {
                NonMetal = nonmetal;
                _context.NonMetal.Remove(NonMetal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
