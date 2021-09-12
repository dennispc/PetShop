using NUnit.Framework;
using DPcode.WebApi.Converters;
using DPcode.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class PetControllerTest
    {
        private PetConverter _petConverter;
        [SetUp]
        public void Setup()
        {
            _petConverter = new PetConverter();
        }

        [Test]
        public void Test1()
        {
            List<Pet> list = new List<Pet>();

            for (int i = 0; i < 3; i++)
            {
                Pet p = new Pet();
                p.name = "petname" + i;
                p.price = (1333 + i);
                list.Add(p);
            }

            Assert.IsTrue(_petConverter.GetAsPetReadDto(list).Count()>1);
        }
    }
}