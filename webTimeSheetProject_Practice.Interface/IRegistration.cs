using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webtimesheet_Practice.models;

namespace webTimeSheetProject_Practice.Interface
{
  public  interface IRegistration
    {
        bool CheckUserNameExist(string name);
        int addUser(Registration entity);
        IQueryable<Registration> ListofRegisterdUser(string sortColumn, string Search);
        bool UpdatePassword(string RegistrationID, string Password);


    }
}
