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

namespace outer_space.Web.Pages.MissionAstronauts
{
    public class EditModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public EditModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MissionAstronaut MissionAstronaut { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MissionAstronauts == null)
            {
                return NotFound();
            }

            var missionastronaut =  await _context.MissionAstronauts.FirstOrDefaultAsync(m => m.MissionID == id);
            if (missionastronaut == null)
            {
                return NotFound();
            }
            MissionAstronaut = missionastronaut;
           ViewData["AstronautID"] = new SelectList(_context.Astronauts, "AstronautID", "AstronautNameFirst");
           ViewData["MissionID"] = new SelectList(_context.Missions, "MissionID", "MissionName");
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

            _context.Attach(MissionAstronaut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionAstronautExists(MissionAstronaut.MissionID))
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

        private bool MissionAstronautExists(int id)
        {
          return (_context.MissionAstronauts?.Any(e => e.MissionID == id)).GetValueOrDefault();
        }
    }
}
