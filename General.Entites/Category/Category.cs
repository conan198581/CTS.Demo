using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace General.Entites.Category
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMenu { get; set; }
        public string SysResource { get; set; }
        public string ResouceID { get; set; }
        public string FatherResource { get; set; }
        public string FatherID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string RouteName { get; set; }
        public string CssClass { get; set; }
        public int Sort { get; set; }
        public bool IsDisabled { get; set; }

    }
}
