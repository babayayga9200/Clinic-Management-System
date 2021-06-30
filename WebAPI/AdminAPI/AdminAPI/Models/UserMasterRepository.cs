using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminAPI.Models
{
    public class UserMasterRepository : IDisposable
    {
        
         Context context = new Context();
        
        public LoginTable ValidateUser(string username, string password)
        {
            return context.loginTables.FirstOrDefault(user =>
            user.Email.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.Password == password);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}