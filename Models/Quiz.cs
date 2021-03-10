using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizManager.Models
{
    public class Quiz
    {
        public int QuizID { get; set; }
        [Display(Name = "Quiz Name")]
        [Required]
        public string QuizName { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
