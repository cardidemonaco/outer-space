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
    public class IndexModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public IndexModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

        public IList<Astronaut> Astronaut { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Astronauts != null)
            {
                Astronaut = await _context.Astronauts.ToListAsync();
            }
        }
    }
}
