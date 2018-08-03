using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGarden.Models.DbModels
{
    public class Role : BaseEntity
    {
        public Role()
        {
            this.Users = new List<User>();
        }
        public string Name { get; set; }

        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}