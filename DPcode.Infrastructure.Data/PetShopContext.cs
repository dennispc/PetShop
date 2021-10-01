using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPcode.Core.Models;
using DPcode.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPcode.Infrastructure.Data
{
    public class PetShopContext : DbContext
    {

        public string DbPath { get; private set; }
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt){
        }

        public DbSet<PetEntity> pets { get; set; }
        public DbSet<PetTypeEntity> petTypes{get; set;}
        public DbSet<OwnerEntity> owners{get; set;}
    }
}