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
        public virtual int Review_Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual string Email { get; set; }
        public virtual string Gender { get; set; }
        public virtual int? Age { get; set; }
        [Range(0, 5)]
        public virtual int AbilityToFind { get; set; }
        [Range(0, 5)]
        public virtual int RangeOfProducts { get; set; }
        [Range(0, 5)]
        public virtual int EasyCheckout { get; set; }
        [Range(0, 5)]
        public virtual int OverallExperience { get; set; }
        public virtual string MostLiked { get; set; }
        public virtual string MostDisliked { get; set; }
        public virtual string MostLikeToSee { get; set; }
        public virtual DateTime TimeDate { get; set; }
        public virtual string IpAddress { get; set; }
        public virtual string Browser { get; set; }
        public virtual string Device { get; set; }
    }
}