using System;
using System.Collections.Generic;
using Music_Player.Models;
using Music_Player.Models.Repository;
using Music_Player.Pages.Helpers;
using System.Web.ModelBinding;

namespace Music_Player.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                User myUser = new User();
                if (TryUpdateModel(myUser,
                   new FormValueProvider(ModelBindingExecutionContext)))
                {

                    myUser.UserLines = new List<UserLine>();

                    PlayList myList = SessionHelper.GetList(Session);

                    foreach (ListLine line in myList.Lines)
                    {
                        myUser.UserLines.Add(new UserLine
                        {
                            User = myUser,
                            Song = line.Song,
                        });
                    }

                    new Repository().SaveUsers(myUser);
                    myList.Clear();

                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }
    }
}