using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsDB.WebAPI.Models
{
    public class StudentsDBWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StudentsDBWebAPIContext() : base("name=StudentsDBWebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<StudentsDB.WebAPI.Models.Student> Students { get; set; }
    }
}
