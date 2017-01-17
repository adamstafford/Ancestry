using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Ancestry.Models
{
    public class ReviewContext : DbContext
    {
        public DbSet<Review> review { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void AddReview(Review review)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AncestryDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddReview", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = review.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = review.Email;
                cmd.Parameters.Add(paramEmail);

                SqlParameter paramAge = new SqlParameter();
                paramAge.ParameterName = "@Age";
                paramAge.Value = review.Age;
                cmd.Parameters.Add(paramAge);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = review.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramAbilityToFind = new SqlParameter();
                paramAbilityToFind.ParameterName = "@AbilityToFind";
                paramAbilityToFind.Value = review.AbilityToFind;
                cmd.Parameters.Add(paramAbilityToFind);

                SqlParameter paramRangeOfProducts = new SqlParameter();
                paramRangeOfProducts.ParameterName = "@RangeOfProducts";
                paramRangeOfProducts.Value = review.RangeOfProducts;
                cmd.Parameters.Add(paramRangeOfProducts);

                SqlParameter paramEasyCheckout = new SqlParameter();
                paramEasyCheckout.ParameterName = "@EasyCheckout";
                paramEasyCheckout.Value = review.EasyCheckout;
                cmd.Parameters.Add(paramEasyCheckout);

                SqlParameter paramOverallExperience = new SqlParameter();
                paramOverallExperience.ParameterName = "@OverallExperience";
                paramOverallExperience.Value = review.OverallExperience;
                cmd.Parameters.Add(paramOverallExperience);

                SqlParameter paramMostLiked = new SqlParameter();
                paramMostLiked.ParameterName = "@MostLiked";
                paramMostLiked.Value = review.MostLiked;
                cmd.Parameters.Add(paramMostLiked);

                SqlParameter paramMostDisliked = new SqlParameter();
                paramMostDisliked.ParameterName = "@MostDisliked";
                paramMostDisliked.Value = review.MostDisliked;
                cmd.Parameters.Add(paramMostDisliked);

                SqlParameter paramMostLikeToSee = new SqlParameter();
                paramMostLikeToSee.ParameterName = "@MostLikeToSee";
                paramMostLikeToSee.Value = review.MostLikeToSee;
                cmd.Parameters.Add(paramMostLikeToSee);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}