using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using outer_space.Data;
using outer_space.Data.Tables;

namespace outer_space.Web.Pages.Astronauts
{
    public class EditModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public EditModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Astronaut Astronaut { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Astronauts == null)
            {
                return NotFound();
            }

            var astronaut =  await _context.Astronauts.FirstOrDefaultAsync(m => m.AstronautID == id);
            if (astronaut == null)
            {
                return NotFound();
            }
            Astronaut = astronaut;
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

            _context.Attach(Astronaut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AstronautExists(Astronaut.AstronautID))
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

        private bool AstronautExists(int id)
        {
          return (_context.Astronauts?.Any(e => e.AstronautID == id)).GetValueOrDefault();
        }
    }
}
