using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using outer_space.Data;
using outer_space.Data.Tables;

namespace outer_space.Web.Pages.MissionAstronauts
{
    public class DeleteModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public DeleteModel(outer_space.Data.DataModelDbContext context)
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

            var missionastronaut = await _context.MissionAstronauts.FirstOrDefaultAsync(m => m.MissionID == id);

            if (missionastronaut == null)
            {
                return NotFound();
            }
            else 
            {
                MissionAstronaut = missionastronaut;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MissionAstronauts == null)
            {
                return NotFound();
            }
            var missionastronaut = await _context.MissionAstronauts.FindAsync(id);

            if (missionastronaut != null)
            {
                MissionAstronaut = missionastronaut;
                _context.MissionAstronauts.Remove(MissionAstronaut);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
