using EventManager.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Models.ViewModels
{
    public class CreateViewModel : IValidatableObject
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Location { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartTime >= EndTime)
            {
                yield return new ValidationResult("StartTime cannot be less than EndTime", new[] { "StartTime" });
            }
            else if (StartTime < DateTime.Now)
            {
                yield return new ValidationResult("Date must be in the future", new[] { "StartTime", });
            }
            else if (EndTime < DateTime.Now)
            {
                yield return new ValidationResult("Date must be in the future", new[] { "EndTime" });
            }
            else if (StartTime.Year > 2500)
            {
                yield return new ValidationResult("The year must be less than 2500", new[] { "StartTime" });
            }
            else if (EndTime.Year > 2500)
            {
                yield return new ValidationResult("The year must be less than 2500", new[] { "EndTime" });
            }
        }
    }
}
