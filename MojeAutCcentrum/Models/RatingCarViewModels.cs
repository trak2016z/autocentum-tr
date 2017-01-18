using Newtonsoft.Json;
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

    public class RCVVM
    {
        public Brand Brand { get; set; }

        public Model Model { get; set; }

        public Generation Generation { get; set; }

        public Body Body { get; set; }

        public Motor Motor { get; set; }

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


    public class AddRatingCarVM
    {
        [Required]
        [Display(Name = "Opinia ogólna")]
        public string Description { get; set; }

        public virtual ICollection<Brand> Brand { get; set; }

        [Display(Name = "Marka")]
        public int BrandId { get; set; }

        public virtual ICollection<Model> Model { get; set; }

        [Display(Name = "Model")]
        public int ModelId { get; set; }

        public virtual ICollection<Generation> Generation { get; set; }

        [Display(Name = "Generacja")]
        public int GenerationId { get; set; }

        public virtual ICollection<Body> Body { get; set; }

        [Display(Name = "Podwozie")]
        public int BodyId { get; set; }

        public virtual ICollection<Motor> Motor { get; set; }

        [Display(Name = "Silnik")]
        public int MotorId { get; set; }

        [Display(Name = "Awaryjność")]
        public virtual Rating Failure { get; set; }

        [Display(Name = "Konfortowość")]
        public virtual Rating Conveniences { get; set; }

        [Display(Name = "Koszt utrzymania")]
        public virtual Rating Maintenance { get; set; }

        public List<int> Values
        {
            get
            {
                List<int> values = new List<int>();
                values.Add(1);
                values.Add(2);
                values.Add(3);
                values.Add(4);
                values.Add(5);
                return values;
            }
        }

        public string UserId { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class SelectCar
    {
         public string NameModel { get; set; }
         public string Id { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class AddDescription
    {
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? GenerationId { get; set; }
        public int? BodyId { get; set; }
        public int? MotorId { get; set; }
        public string Descripton { get; set; }
    }

    public class ShareCar
    {

        public virtual ICollection<Brand> Brand { get; set; }

        [Display(Name = "Marka")]
        public int BrandId { get; set; }

        public virtual ICollection<Model> Model { get; set; }

        [Display(Name = "Model")]
        public int ModelId { get; set; }

        public virtual ICollection<Generation> Generation { get; set; }

        [Display(Name = "Generacja")]
        public int GenerationId { get; set; }

        public virtual ICollection<Body> Body { get; set; }

        [Display(Name = "Podwozie")]
        public int BodyId { get; set; }

        public virtual ICollection<Motor> Motor { get; set; }

        [Display(Name = "Silnik")]
        public int MotorId { get; set; }

    }
}