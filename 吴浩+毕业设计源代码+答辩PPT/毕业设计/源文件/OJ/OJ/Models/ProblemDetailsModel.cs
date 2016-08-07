using System.ComponentModel.DataAnnotations;
using OJ.OJService;

namespace OJ.Models
{
    public class ProblemDetailsModel
    {
        [Display(Name = "问题信息")]
        public ProblemDO ProblemDO { get; set; }

        [Required]
        [Display(Name = "代码")]
        public string Code { get; set; }
    }
}