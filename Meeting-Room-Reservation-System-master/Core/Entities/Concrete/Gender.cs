using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{

    public  class Gender : IEntity
    {
        public int GenderId { get; set; }

        public string GenderName { get; set; } = null!;

        public int InsertUserId { get; set; }

        public DateTime InsertDate { get; set; }

        public int? UpdateUserId { get; set; }

        public int? UpdateDate { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
