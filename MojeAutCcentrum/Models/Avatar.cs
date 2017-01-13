using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MojeAutCcentrum.Models
{
    public class Avatar
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Fream { get; set; }

        public int Size { get; set; }

        public virtual string UserId { get; set; }
    }
}