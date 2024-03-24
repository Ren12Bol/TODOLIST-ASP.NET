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
    public class DetailsModel : PageModel
    {
        private readonly TODOLIST.Data.TODOLISTContext _context;

        public DetailsModel(TODOLIST.Data.TODOLISTContext context)
        {
            _context = context;
        }

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
    }
}
