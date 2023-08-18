using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using outer_space.Data.Tables;

namespace outer_space.Web.Pages.Galaxies
{
    public class EditModel : PageModel
    {
        private readonly Data.DataModelDbContext _context;

        public EditModel(Data.DataModelDbContext context)
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

            var galaxy =  await _context.Galaxies.FirstOrDefaultAsync(m => m.GalaxyID == id);
            if (galaxy == null)
            {
                return NotFound();
            }
            Galaxy = galaxy;
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

            _context.Attach(Galaxy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalaxyExists(Galaxy.GalaxyID))
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

        private bool GalaxyExists(int id)
        {
          return (_context.Galaxies?.Any(e => e.GalaxyID == id)).GetValueOrDefault();
        }
    }
}
