using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tui.Presentation.Models;

namespace Tui.Presentation.Controllers
{
    public class MenusController : BaseController
    {
        // GET: Menus
        public ActionResult Menus()
        {
            try
            {
                List<Menu> menus = new List<Menu>{
                   new Menu{ MenuId = 1 ,LinkText="index", ActionName="Index",ControllerName="Flight",Area="FlightArea" , Roles="All"  },
                   new Menu{ MenuId = 1 ,LinkText="Create Flight", ActionName="add",ControllerName="Flight",Area="FlightArea" , Roles="All"  },
                 };

                string profileUserCurrent = "All";
                //String[] roles = Enum.GetValues(typeof(ProfileEnum)).Cast<ProfileEnum>().Select(v => v.ToString()).ToArray();
                string[] roles = new string[] { profileUserCurrent };



                List<Menu> links = (from item in menus
                                       where item.Roles.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                                       .Any(x => roles.Contains(x) || x == "All")
                                       select item).ToList();


                return PartialView(links);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}