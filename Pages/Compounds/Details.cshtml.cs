using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Balaie_Cristian_Vlad_PROJECT.Data;
using Balaie_Cristian_Vlad_PROJECT.Models;

namespace Balaie_Cristian_Vlad_PROJECT.Pages.Compounds
{
    public class DetailsModel : PageModel
    {
        private readonly Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext _context;

        public DetailsModel(Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext context)
        {
            _context = context;
        }

      public Compound Compound { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Compound == null)
            {
                return NotFound();
            }

            var compound = await _context.Compound.FirstOrDefaultAsync(m => m.ID == id);
            var metal = await _context.Compound.Include(b => b.Metal).ToListAsync();
            var metalloid = await _context.Compound.Include(b => b.Metalloid).ToListAsync();
            var nonmetal = await _context.Compound.Include(b => b.NonMetal).ToListAsync();
            if (compound == null)
            {
                return NotFound();
            }
            else 
            {
                Compound = compound;
            }
            return Page();
        }
    }
}
