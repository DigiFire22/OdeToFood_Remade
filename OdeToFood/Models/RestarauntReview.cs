﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class RestarauntReview : IValidatableObject
    {
        public int Id { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        [Display(Name = "Username")]
        [DisplayFormat(NullDisplayText = "Anonymous")]
        [StringLength(1024)]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && Body.Length > 20)
            {
                yield return new ValidationResult("Low reviews need longer body");
            }
        }
    }
}
