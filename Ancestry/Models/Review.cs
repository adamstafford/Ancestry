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
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int AbilityToFind { get; set; }
        public int RangeOfProducts { get; set; }
        public int EasyCheckout { get; set; }
        public int OverallExperience { get; set; }
        public string MostLiked { get; set; }
        public string MostDisliked { get; set; }
        public string MostLikeToSee { get; set; }
    }
}