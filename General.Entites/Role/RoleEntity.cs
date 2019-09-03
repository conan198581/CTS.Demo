using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace General.Entites.Role
{
    [Table("SysRole")]
    public class RoleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Creator { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? Modifier { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
