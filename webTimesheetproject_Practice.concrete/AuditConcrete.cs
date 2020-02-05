using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtimesheet_Practice.models;
using webTimeSheetProject_Practice.Interface;

namespace webTimesheetproject_Practice.concrete
{
    public class AuditConcrete : IAudit
    {
       public void InsertAuditData(AuditTB audittb)
        {
            using (var _context = new DatabaseContext())
            {
                _context.auditConcretes.Add(audittb);
                _context.SaveChanges();
                //error we get here
            }
        }
    }
}
