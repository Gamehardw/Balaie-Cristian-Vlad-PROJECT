using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Balaie_Cristian_Vlad_PROJECT.Data;
using Balaie_Cristian_Vlad_PROJECT.Models;

namespace Balaie_Cristian_Vlad_PROJECT.Pages.Metalloids
{
    public class DeleteModel : PageModel
    {
        private readonly Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext _context;

        public DeleteModel(Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Metalloid Metalloid { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Metalloid == null)
            {
                return NotFound();
            }

            var metalloid = await _context.Metalloid.FirstOrDefaultAsync(m => m.ID == id);

            if (metalloid == null)
            {
                return NotFound();
            }
            else 
            {
                Metalloid = metalloid;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Metalloid == null)
            {
                return NotFound();
            }
            var metalloid = await _context.Metalloid.FindAsync(id);

            if (metalloid != null)
            {
                Metalloid = metalloid;
                _context.Metalloid.Remove(Metalloid);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
