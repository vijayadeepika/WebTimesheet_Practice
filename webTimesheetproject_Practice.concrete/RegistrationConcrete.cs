using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtimesheet_Practice.models;
using webTimeSheetProject_Practice.Interface;

namespace webTimesheetproject_Practice.concrete
{
    public class RegistrationConcrete : IRegistration
    {
        public int addUser(Registration entity)
        {
            try
            {
                using (var _context = new DatabaseContext())
                {
                    _context.registraion.Add(entity);
                    return _context.SaveChanges();
                }
            }
            catch(Exception )
            {
                throw;
            }

        }

        public bool CheckUserNameExist(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Registration> ListofRegisterdUser(string sortColumn, string Search)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(string RegistrationID, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
