using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest
  {
    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=Nadia_lizcano_test;";
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      Specialty newSpecialty = new Specialty("Test");
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "makeuo";
      Specialty newSpecialty = new Specialty(description);

      string result = newSpecialty.GetDescription();

      Assert.AreEqual(description, result);
    }

   [TestMethod]
   public void SetDescription_SetDescription_String()
   {
      string description = "makeup";
      Specialty newSpecialty = new Specialty(description);

      string updatedDescription = "haircut";
      newSpecialty.SetDescription(updatedDescription);
      string result = newSpecialty.GetDescription();

      Assert.AreEqual(updatedDescription, result);
   }

   [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_SpecialtyList()
    {
      List<Specialty> newList = new List<Specialty> { };

      List<Specialty> result = Specialty.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

  }
}
