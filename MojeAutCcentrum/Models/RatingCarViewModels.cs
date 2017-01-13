using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MojeAutCcentrum.Models
{
    public class RatingCarViewModels
    {
        public Brand Brand { get; set; }

        public Model Model { get; set; }

        public Generation Generation { get; set; }

        public Body Body { get; set; }

        public Motor Motor { get; set; }

        public decimal rating { get; set; }

        public int number { get; set; }
    }

    public class RCViewVM
    {
        public int? Brand { get; set; }

        public int? Model { get; set; }

        public int? Generation { get; set; }

        public int? Body { get; set; }

        public int? Motor { get; set; }

        public decimal rating { get; set; }

        public int number { get; set; }
    }

    public class RatingCarEntityViewModels
    {
        public Brand Brand { get; set; }

        public Model Model { get; set; }

        public Generation Generation { get; set; }

        public Body Body { get; set; }

        public Motor Motor { get; set; }

        [Display(Name = "Awaryjność")]
        public decimal Failure { get; set; }

        [Display(Name = "Konfortowość")]
        public decimal Conveniences { get; set; }

        [Display(Name = "Koszt utrzymania")]
        public decimal Maintenance { get; set; }

        public virtual IList<Comment> Comment { get; set; }


    }

    public class Comment
    {
        public string Email { get; set; }

        public Massage Massage { get; set; }

        public string Image { get; set; }
    }

    public class Massage
    {
        public string Description { get; set; }
        public string Failure { get; set; }
        public string Conveniences { get; set; }
        public string Maintenance { get; set; }
    }   
}