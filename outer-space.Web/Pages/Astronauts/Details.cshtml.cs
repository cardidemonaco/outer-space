using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using outer_space.Data;
using outer_space.Data.Tables;

namespace outer_space.Web.Pages.Astronauts
{
    public class DetailsModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public DetailsModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

      public Astronaut Astronaut { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Astronauts == null)
            {
                return NotFound();
            }

            var astronaut = await _context.Astronauts.FirstOrDefaultAsync(m => m.AstronautID == id);
            if (astronaut == null)
            {
                return NotFound();
            }
            else 
            {
                Astronaut = astronaut;
            }
            return Page();
        }
    }
}
