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
    public class IndexModel : PageModel
    {
        private readonly TODOLIST.Data.TODOLISTContext _context;

        public IndexModel(TODOLIST.Data.TODOLISTContext context)
        {
            _context = context;
        }

        public IList<List> List { get;set; } = default!;

        public async Task OnGetAsync()
        {
            List = await _context.List.ToListAsync();
        }
    }
}
