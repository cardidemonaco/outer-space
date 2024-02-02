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

namespace outer_space.Web.Pages.Missions
{
    public class EditModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public EditModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mission Mission { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Missions == null)
            {
                return NotFound();
            }

            var mission =  await _context.Missions.FirstOrDefaultAsync(m => m.MissionID == id);
            if (mission == null)
            {
                return NotFound();
            }
            Mission = mission;
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

            _context.Attach(Mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(Mission.MissionID))
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

        private bool MissionExists(int id)
        {
          return (_context.Missions?.Any(e => e.MissionID == id)).GetValueOrDefault();
        }
    }
}
