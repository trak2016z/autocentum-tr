using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MojeAutCcentrum.Models
{
    [JsonObject(IsReference = true)]
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public int Value { get; set; }

        public string Description { get; set; }
    }
}