using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps.Dto
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "Fullname is required")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime BirthDate { get; set; }

        public bool IsValid()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(this, validationContext, validationResults, true);
        }
    }
}
