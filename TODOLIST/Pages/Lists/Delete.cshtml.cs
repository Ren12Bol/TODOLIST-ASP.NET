using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TODOLIST.Data;
using TODOLIST.Models;

namespace TODOLIST.Pages.Lists
{
    public class DeleteModel : PageModel
    {
        private readonly TODOLIST.Data.TODOLISTContext _context;

        public DeleteModel(TODOLIST.Data.TODOLISTContext context)
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

            var list = await _context.List.FirstOrDefaultAsync(m => m.Id == id);

            if (list == null)
            {
                return NotFound();
            }
            else
            {
                List = list;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = await _context.List.FindAsync(id);
            if (list != null)
            {
                List = list;
                _context.List.Remove(List);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
