using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using outer_space.Data;
using outer_space.Data.Tables;

namespace outer_space.Web.Pages.Galaxies
{
    public class DetailsModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public DetailsModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

      public Galaxy Galaxy { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Galaxies == null)
            {
                return NotFound();
            }

            var galaxy = await _context.Galaxies.FirstOrDefaultAsync(m => m.GalaxyID == id);
            if (galaxy == null)
            {
                return NotFound();
            }
            else 
            {
                Galaxy = galaxy;
            }
            return Page();
        }
    }
}
