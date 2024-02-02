using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using outer_space.Data;
using outer_space.Data.Tables;

namespace outer_space.Web.Pages.Astronauts
{
    public class CreateModel : PageModel
    {
        private readonly outer_space.Data.DataModelDbContext _context;

        public CreateModel(outer_space.Data.DataModelDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Astronaut Astronaut { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Astronauts == null || Astronaut == null)
            {
                return Page();
            }

            _context.Astronauts.Add(Astronaut);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
