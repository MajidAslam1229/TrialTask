using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialTask.Entities.Tables
{
    public class QuizStatus
    {
        [Key]
        public int Id { get; set; }
        public string? Status { get; set; }    
    }
}
