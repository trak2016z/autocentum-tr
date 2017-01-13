using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MojeAutCcentrum.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MojeAutCcentrum.Context
{
    public class Connection : IdentityDbContext<ApplicationUser>
    {

        public Connection():base("Connection", throwIfV1Schema: false) { }

        public static Connection Create() => new Connection();



        public DbSet<Brand> Brand { get; set; }

        public DbSet<Body> Body { get; set; }

        public DbSet<Generation> Generation { get; set; }

        public DbSet<Model> Model { get; set; }

        public DbSet<Motor> Motor { get; set; }

        public DbSet<RatingCar> RatingCar { get; set; }
        
        public DbSet<Avatar> Avatar { get; set; }
    }
}