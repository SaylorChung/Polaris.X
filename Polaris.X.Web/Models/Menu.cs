using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polaris.X.Web.Models
{
    public class Menu
    {
        /// <summary>
        ///     uniq-identifier
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     上级ID
        /// </summary>
        public Guid ParentID { get; set; }
        /// <summary>
        ///     Icon
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        ///     级别
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        ///     链接
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        ///     是否叶结点
        /// </summary>
        public bool IsLeaf { get; set; }
        /// <summary>
        ///     序列
        /// </summary>
        public int Seq { get; set; }
        /// <summary>
        ///     状态
        /// </summary>
        public bool Status { get; set; }
    }
}