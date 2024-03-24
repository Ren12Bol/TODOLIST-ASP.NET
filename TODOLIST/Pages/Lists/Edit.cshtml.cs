using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TODOLIST.Data;
using TODOLIST.Models;

namespace TODOLIST.Pages.Lists
{
    public class EditModel : PageModel
    {
        private readonly TODOLIST.Data.TODOLISTContext _context;

        public EditModel(TODOLIST.Data.TODOLISTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List List { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list =  await _context.List.FirstOrDefaultAsync(m => m.Id == id);
            if (list == null)
            {
                return NotFound();
            }
            List = list;
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

            _context.Attach(List).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListExists(List.Id))
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

        private bool ListExists(int id)
        {
            return _context.List.Any(e => e.Id == id);
        }
    }
}
