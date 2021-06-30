using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AdminAPI.Models
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private Context dbContext = new Context();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserMasterRepository _repo = new UserMasterRepository())
            {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user != null)
                {
    
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                string id="";
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Type.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                identity.AddClaim(new Claim("LoginId", user.LoginId.ToString()));
                identity.AddClaim(new Claim("Email", user.Email));
                    if (user.Type == 1)
                    {
                        id = Convert.ToString(user.LoginId);
                    }
                    else if(user.Type==2){
                        id = Convert.ToString(dbContext.doctors.Where(d => d.Email == user.Email).Select(d => d.DoctorID).FirstOrDefault());
                    }
                    else if (user.Type == 3)
                    {
                        id = Convert.ToString(dbContext.patients.Where(d => d.Email == user.Email).Select(d=>d.PatientID).FirstOrDefault());
                    }

                    string userRoles = Convert.ToString( user.Type)+","+id;
                    
                foreach (string roleName in userRoles.Split(','))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
                }
                var additionalData = new AuthenticationProperties(new Dictionary<string, string>{
                    {
                        "role", Newtonsoft.Json.JsonConvert.SerializeObject(userRoles)
                    }
                });
                var token = new AuthenticationTicket(identity, additionalData);
                context.Validated(token);
            }
            else
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;

        
            }

            
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

    }
}