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

namespace Balaie_Cristian_Vlad_PROJECT.Pages.Metals
{
    public class EditModel : PageModel
    {
        private readonly Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext _context;

        public EditModel(Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Metal Metal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Metal == null)
            {
                return NotFound();
            }

            var metal =  await _context.Metal.FirstOrDefaultAsync(m => m.ID == id);
            if (metal == null)
            {
                return NotFound();
            }
            Metal = metal;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            _context.Attach(Metal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetalExists(Metal.ID))
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

        private bool MetalExists(int id)
        {
          return _context.Metal.Any(e => e.ID == id);
        }
    }
}
