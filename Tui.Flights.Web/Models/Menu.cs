using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tui.Presentation.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Roles { get; set; }
        public string Area { get; set; }
        public Menu()
        {

        }

        public Menu(int _MenuId, string _LinkText, string _ActionName, string _ControllerName, string _Area, string _Roles)
        {
            MenuId = _MenuId;
            LinkText = _LinkText;
            ActionName = _ActionName;
            ControllerName = _ControllerName;
            Roles = _Roles;
            Area = _Area;
        }
    }
}