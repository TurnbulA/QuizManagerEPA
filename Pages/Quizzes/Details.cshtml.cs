using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizManager.Data;
using QuizManager.Models;

namespace QuizManager.Pages.Quizzes
{
    public class DetailsModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public DetailsModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = await _context.Quiz.FirstOrDefaultAsync(m => m.QuizID == id);

            if (Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
