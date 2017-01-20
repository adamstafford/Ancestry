using Ancestry.LocalResource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ancestry.Models
{
    public class Review
    {
        [Key]
        public virtual int Review_Id { get; set; }
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        [Required]
        public virtual string Name { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public virtual string Email { get; set; }
        [Display(Name = "Gender", ResourceType = typeof(Resource))]
        public virtual string Gender { get; set; }
        [Display(Name = "Age", ResourceType = typeof(Resource))]
        [Range(0, 100)]
        public virtual int? Age { get; set; }
        [Display(Name = "AbilityToFind", ResourceType = typeof(Resource))]
        [Range(0, 5)]
        public virtual int AbilityToFind { get; set; }
        [Display(Name = "RangeOfProducts", ResourceType = typeof(Resource))]
        [Range(0, 5)]
        public virtual int RangeOfProducts { get; set; }
        [Display(Name = "EasyCheckout", ResourceType = typeof(Resource))]
        [Range(0, 5)]
        public virtual int EasyCheckout { get; set; }
        [Display(Name = "OverallExperience", ResourceType = typeof(Resource))]
        [Range(0, 5)]
        public virtual int OverallExperience { get; set; }
        [Display(Name = "MostLiked", ResourceType = typeof(Resource))]
        [DataType(DataType.MultilineText)]
        public virtual string MostLiked { get; set; }
        [Display(Name = "MostDisliked", ResourceType = typeof(Resource))]
        [DataType(DataType.MultilineText)]
        public virtual string MostDisliked { get; set; }
        [Display(Name = "MostLikeToSee", ResourceType = typeof(Resource))]
        [DataType(DataType.MultilineText)]
        public virtual string MostLikeToSee { get; set; }
        public virtual DateTime TimeDate { get; set; }
        public virtual string IpAddress { get; set; }
        public virtual string Browser { get; set; }
        public virtual string Device { get; set; }
    }
}