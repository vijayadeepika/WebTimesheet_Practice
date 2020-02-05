using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtimesheet_Practice.models;

namespace webTimeSheetProject_Practice.Interface
{
    public interface IAudit
    {
        void InsertAuditData(AuditTB audittb);
    }
}
