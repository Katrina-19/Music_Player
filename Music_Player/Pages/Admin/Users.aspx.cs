using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using Music_Player.Models;
using Music_Player.Models.Repository;

namespace Music_Player.Pages.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int dispatchID;
                if (int.TryParse(Request.Form["dispatch"], out dispatchID))
                {
                    User myUser = repository.Users.Where(o => o.UserId == dispatchID).FirstOrDefault();
                    if (myUser != null)
                    {
                        myUser.Dispatched = true;
                        repository.SaveUsers(myUser);
                    }
                }
            }
        }

        public IEnumerable<User> GetUsers([Control] bool showDispatched)
        {
            if (showDispatched)
            {
                return repository.Users;
            }
            else
            {
                return repository.Users.Where(o => !o.Dispatched);
            }
        }

    }
}