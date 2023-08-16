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
    public class DeleteModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public DeleteModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Galaxies == null)
            {
                return NotFound();
            }
            var galaxy = await _context.Galaxies.FindAsync(id);

            if (galaxy != null)
            {
                Galaxy = galaxy;
                _context.Galaxies.Remove(Galaxy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
