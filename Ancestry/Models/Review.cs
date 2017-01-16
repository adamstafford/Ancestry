using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ancestry.Models
{
    public class Review
    {
        [Key]
        public int Review_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        [Range(0, 5)]
        public int AbilityToFind { get; set; }
        [Range(0, 5)]
        public int RangeOfProducts { get; set; }
        [Range(0, 5)]
        public int EasyCheckout { get; set; }
        [Range(0, 5)]
        public int OverallExperience { get; set; }
        public string MostLiked { get; set; }
        public string MostDisliked { get; set; }
        public string MostLikeToSee { get; set; }
    }
}