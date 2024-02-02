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
    public class IndexModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public IndexModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

        public IList<MissionAstronaut> MissionAstronaut { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MissionAstronauts != null)
            {
                MissionAstronaut = await _context.MissionAstronauts
                .Include(m => m.Astronaut)
                .Include(m => m.Mission).ToListAsync();
            }
        }
    }
}
