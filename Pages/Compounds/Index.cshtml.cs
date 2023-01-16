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
    public class IndexModel : PageModel
    {
        private readonly Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext _context;

        public IndexModel(Balaie_Cristian_Vlad_PROJECT.Data.Balaie_Cristian_Vlad_PROJECTContext context)
        {
            _context = context;
        }

        public IList<Compound> Compound { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Compound != null)
            {
                Compound = await _context.Compound
                .Include(c => c.Metal)
                .Include(c => c.Metalloid)
                .Include(c => c.NonMetal).ToListAsync();
            }
        }
    }
}
