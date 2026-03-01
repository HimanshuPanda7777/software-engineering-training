using System.ComponentModel.DataAnnotations;

namespace MVC_Core_WebApp1.Models

{
    public class Student
    {
        
        
        [Required(ErrorMessage="Roll no cant be lft blank")]
        public int RollNo { get; set; }
        [Required(ErrorMessage = "name no cant be lft blank")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "name must be between 2 and 20 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "age no cant be lft blank")]
        [Range(18, 30, ErrorMessage = "age must be between 18 and 30")]
        public int age { get; set; }
        public string adress { get; set; }

    }
}
