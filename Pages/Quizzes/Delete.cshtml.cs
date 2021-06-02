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
    public class DeleteModel : PageModel
    {
        private readonly QuizManager.Data.QuizContext _context;

        public DeleteModel(QuizManager.Data.QuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = await _context.Quiz.FirstOrDefaultAsync(m => m.QuizId == id);

            if (Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = await _context.Quiz.FindAsync(id);

            if (Quiz != null)
            {
                _context.Quiz.Remove(Quiz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
