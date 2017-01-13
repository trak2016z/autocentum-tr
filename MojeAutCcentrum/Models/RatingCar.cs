using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MojeAutCcentrum.Models
{
    public class RatingCar
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; } 
        
        public virtual Brand Brand { get; set; }

        public virtual  Model Model { get; set; }

        public virtual Generation Generation { get; set; }

        public virtual Body Body { get; set; }

        public virtual Motor Motor { get; set; }

        public virtual Rating Failure { get; set; }

        public virtual Rating Conveniences { get; set; }

        public virtual Rating Maintenance { get; set; }

        public virtual string UserId { get; set; }
    }
}