using System.Data.Entity;

namespace WebApplication3.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Quantity> Quantities { get; set; }
        public DbSet<Measurment> Measurments { get; set; }

    }
}