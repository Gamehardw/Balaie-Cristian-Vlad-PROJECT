using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Balaie_Cristian_Vlad_PROJECT.Data;
using Balaie_Cristian_Vlad_PROJECT.Models;

namespace Balaie_Cristian_Vlad_PROJECT.Pages.Compounds
{
    public class CreateModel : PageModel
    {
        private readonly Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext _context;

        public CreateModel(Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MetalID"] = new SelectList(_context.Set<Metal>(), "ID", "MetalName");
        ViewData["MetalloidID"] = new SelectList(_context.Set<Metalloid>(), "ID", "MetalloidName");
        ViewData["NonMetalID"] = new SelectList(_context.Set<NonMetal>(), "ID", "NonMetalName");
            return Page();
        }

        [BindProperty]
        public Compound Compound { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Compound.Add(Compound);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
