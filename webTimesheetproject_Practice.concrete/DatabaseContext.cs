using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtimesheet_Practice.models;
using System.Data.SqlClient;
namespace webTimesheetproject_Practice.concrete
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("cs")
        {

        }
        public DbSet<AuditTB> auditConcretes { get; set; }

        //public System.Data.Entity.DbSet<TimeSheetPractice.models.LoginViewModel> LoginViewModels { get; set; }
    }
}
