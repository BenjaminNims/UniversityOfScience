using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UniversityOfScienceTwo.Data;
using UniversityOfScienceTwo.Models;

namespace UniversityOfScienceTwo.Pages.Faculty
{
    public class IndexModel : PageModel
    {
        private readonly UniversityOfScienceTwo.Data.ApplicationDbContext _context;

        public IndexModel(UniversityOfScienceTwo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Professor> Professor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Professor != null)
            {
                Professor = await _context.Professor.ToListAsync();
            }
        }
    }
}
