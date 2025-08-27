using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess.Concrete.EfCore
{
    public class LibDbContextFactory : IDesignTimeDbContextFactory<LibDbContext>
    {
        public LibDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-CGDTBSJ\\MSSQLSERVER5;Database=LibraryManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");




            return new LibDbContext(optionsBuilder.Options);
        }
    }
}
