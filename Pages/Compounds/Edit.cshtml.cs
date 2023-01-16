using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Balaie_Cristian_Vlad_PROJECT.Data;
using Balaie_Cristian_Vlad_PROJECT.Models;

namespace Balaie_Cristian_Vlad_PROJECT.Pages.Compounds
{
    public class EditModel : PageModel
    {
        private readonly Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext _context;

        public EditModel(Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Compound Compound { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Compound == null)
            {
                return NotFound();
            }

            var compound =  await _context.Compound.FirstOrDefaultAsync(m => m.ID == id);
            if (compound == null)
            {
                return NotFound();
            }
            Compound = compound;
           ViewData["MetalID"] = new SelectList(_context.Set<Metal>(), "ID", "MetalName");
           ViewData["MetalloidID"] = new SelectList(_context.Set<Metalloid>(), "ID", "MetalloidName");
           ViewData["NonMetalID"] = new SelectList(_context.Set<NonMetal>(), "ID", "NonMetalName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Compound).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompoundExists(Compound.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompoundExists(int id)
        {
          return _context.Compound.Any(e => e.ID == id);
        }
    }
}
