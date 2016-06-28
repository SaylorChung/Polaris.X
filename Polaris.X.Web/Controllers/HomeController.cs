using Polaris.X.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Polaris.X.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Menu> menus = new List<Menu>() {
                new Menu {
                    ID =new Guid("DBC64808-850E-E511-B477-D89D6724AE57"),
                    Name = "系统设置",
                    ParentID =new Guid("00000000-0000-0000-0000-000000000000"),
                    Icon="fa fa-cog",
                    Level=1,
                    IsLeaf=false,
                    Seq=1,
                    Href="#",
                    Status=true
                },
                new Menu {
                    ID=new Guid("DD7645DC-758F-44B0-8B74-ED0A8A98E5CA"),
                    Name = "终端管理",
                    ParentID =new Guid("DBC64808-850E-E511-B477-D89D6724AE57"),
                    Icon="",
                    Level=2,
                    IsLeaf=true,
                    Seq=1,
                    Href="/Mobile/Index",
                    Status=true
                },
                new Menu {
                    ID=new Guid("9E50573A-55B1-4416-A28C-84851297144C"),
                    Name = "权限管理",
                    ParentID =new Guid("DBC64808-850E-E511-B477-D89D6724AE57"),
                    Icon="",
                    Level=2,
                    IsLeaf=false,
                    Seq=2,
                    Href="#",
                    Status=true
                },
                new Menu {
                    ID=new Guid("529AE273-850E-E511-B477-D89D6724AE57"),
                    Name = "角色授权",
                    ParentID =new Guid("9E50573A-55B1-4416-A28C-84851297144C"),
                    Icon="",
                    Level=3,
                    IsLeaf=true,
                    Seq=1,
                    Href="Role/Index",
                    Status=true
                },
                new Menu {
                    ID =new Guid("984A6286-D626-4BE8-BBB2-232563EF61B4"),
                    Name = "页面布局",
                    ParentID =new Guid("00000000-0000-0000-0000-000000000000"),
                    Icon="fa fa-columns",
                    Level=1,
                    IsLeaf=false,
                    Seq=2,
                    Href="#",
                    Status=true
                },
                new Menu {
                    ID =new Guid("CD26FFCC-70B4-477F-9064-81C5C600AD8D"),
                    Name = "统计图表",
                    ParentID =new Guid("00000000-0000-0000-0000-000000000000"),
                    Icon="fa fa fa-bar-chart-o",
                    Level=1,
                    IsLeaf=false,
                    Seq=3,
                    Href="#",
                    Status=true
                },
                new Menu {
                    ID =new Guid("2CFCB8B8-2F4F-40C3-B94A-223E6B6DF6F2"),
                    Name = "表单设计",
                    ParentID =new Guid("00000000-0000-0000-0000-000000000000"),
                    Icon="fa fa-edit",
                    Level=1,
                    IsLeaf=false,
                    Seq=4,
                    Href="#",
                    Status=true
                }
            };

            StringBuilder sb = new StringBuilder();

            if (menus.Count > 0)
            {
                var OneLevelMenus = menus.Where(m => m.Level == 1).OrderBy(m => m.Seq).ToList();
                //遍历所有模块
                for (int i = 0; i < OneLevelMenus.Count; i++)
                {
                    sb.AppendFormat("<li>");
                    if (OneLevelMenus[i].IsLeaf)
                    {
                        sb.AppendFormat("<a class=\"J_menuItem\" href=\"{0}\"><i class=\"{1}\"></i><span class=\"nav-label\">{2}</span></a>", OneLevelMenus[i].Href, OneLevelMenus[i].Icon, OneLevelMenus[i].Name);
                    }
                    else
                    {
                        sb.AppendFormat("<a href=\"{0}\"><i class=\"{1}\"></i><span class=\"nav-label\">{2}</span><span class=\"fa arrow\"></span></a>", OneLevelMenus[i].Href, OneLevelMenus[i].Icon, OneLevelMenus[i].Name);
                        sb.AppendFormat(RecursiveChild(menus, OneLevelMenus[i].ID, OneLevelMenus[i].Level + 1));
                    }
                    sb.AppendFormat("</li>");
                }
            }
            ViewBag.Menus = sb.ToString();
            return View();
        }
        // GET: Default
        public ActionResult Default()
        {
            return View();
        }

        #region Private Methods
        /// <summary>
        ///     递归获取子节点菜单。
        /// </summary>
        /// <param name="resourceList"></param>
        /// <param name="idParent"></param>
        /// <returns></returns>
        private string RecursiveChild(List<Menu> menus, Guid parentID, int level)
        {
            var tempMenus = menus.Where(m => m.Level == level && m.ParentID == parentID).OrderBy(m => m.Seq).ToList();
            StringBuilder sb = new StringBuilder();
            if (tempMenus != null && tempMenus.Count > 0)
            {
                sb.AppendFormat("<ul class=\"{0}\">", GetClassByLevel(level));
                foreach (var menu in tempMenus)
                {
                    if (menu.IsLeaf)
                    {
                        sb.AppendFormat("<li><a class=\"J_menuItem\" href=\"{0}\">{1}</a></li>", menu.Href, menu.Name);
                    }
                    else
                    {
                        sb.AppendFormat("<li><a href=\"{0}\">{1}<span class=\"fa arrow\"></span></a>", menu.Href, menu.Name);
                        sb.AppendFormat(RecursiveChild(menus, menu.ID, menu.Level + 1));
                        sb.AppendLine("</li>");
                    }
                }
                sb.AppendLine("</ul>");
            }
            return sb.ToString();
        }
        /// <summary>
        ///     根据level 获取UL的class
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private string GetClassByLevel(int level)
        {
            string temp = "";
            switch (level)
            {
                case 1:
                    break;
                case 2:
                    temp = "nav nav-second-level";
                    break;
                case 3:
                    temp = "nav nav-third-level";
                    break;
                case 4:
                    temp = "nav nav-fouth-level";
                    break;
            }

            return temp;
        }
        #endregion
    }
}