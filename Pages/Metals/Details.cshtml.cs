using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Balaie_Cristian_Vlad_PROJECT.Data;
using Balaie_Cristian_Vlad_PROJECT.Models;

namespace Balaie_Cristian_Vlad_PROJECT.Pages.Metals
{
    public class DetailsModel : PageModel
    {
        private readonly Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext _context;

        public DetailsModel(Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext context)
        {
            _context = context;
        }

      public Metal Metal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Metal == null)
            {
                return NotFound();
            }

            var metal = await _context.Metal.FirstOrDefaultAsync(m => m.ID == id);
            if (metal == null)
            {
                return NotFound();
            }
            else 
            {
                Metal = metal;
            }
            return Page();
        }
    }
}
