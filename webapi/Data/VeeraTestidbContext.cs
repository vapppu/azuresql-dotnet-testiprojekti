using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

    public class VeeraTestidbContext : DbContext
    {
        public VeeraTestidbContext (DbContextOptions<VeeraTestidbContext> options)
            : base(options)
        {
        }

        public DbSet<webapi.Models.Kissat> Kissat { get; set; } = default!;
    }
