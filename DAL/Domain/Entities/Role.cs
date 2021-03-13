using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Domain.Entities
{
    public class Role
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
    }
}
