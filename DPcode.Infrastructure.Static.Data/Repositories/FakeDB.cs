using System;
using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Infrastructure.Static.Data.IRepositories;

namespace DPcode.Infrastructure.Static.Data.Repositories
{
    public class FakeDB
    {


        public static readonly List<Pet> pets = new List<Pet>();

        public static readonly List<PetType> petTypes = new List<PetType>();

        public static readonly List<Owner> owners = new List<Owner>();
    }
}