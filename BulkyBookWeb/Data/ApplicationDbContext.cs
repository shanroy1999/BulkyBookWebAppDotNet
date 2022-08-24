using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    // inherit from the DbContext class file in Entity Framework
    public class ApplicationDbContext :DbContext
    {
        // configuration inside the constructor to establish connection
        // In constructor -> pass some options as parameters
        // options -> passed to base class i.e. DbContext
        // no need to create a object of the class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Create the 'Categories' table in the database
        // Create a DbSet for the table using the model name 'Category' in the Models folder
        // Table name created inside the database = 'Categories'
        // Table will have 4 columns corresponding to the properties in the Category class model
        public DbSet<Category> Categories { get; set; }
    }
}
