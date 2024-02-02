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
    public class DetailsModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public DetailsModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

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
    }
}
