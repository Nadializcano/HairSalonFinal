using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {
    public void Dispose()
    {
      Specialty.ClearAll();
    }

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

    [TestMethod]
    public void GetAll_ReturnsSpecialties_SpecialtyList()
    {
      string description01 = "makeuo";
      string description02 = "haircut";
      Specialty newSpecialty1 = new Specialty(description01);
      newSpecialty1.Save();
      Specialty newSpecialty2 = new Specialty(description02);
      newSpecialty2.Save();
      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };

      List<Specialty> result = Specialty.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectSpecialtyFromDatabase_Specialty()
    {
      Specialty testSpecialty = new Specialty("Makeup");
      testSpecialty.Save();

      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

      Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Specialty()
    {
      Specialty firstSpecialty = new Specialty("Makeup");
      Specialty secondSpecialty = new Specialty("Makeup");
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void Save_SavesToDatabase_SpecialtyList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Makeup");

      //Act
      testSpecialty.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      Specialty testSpecialty = new Specialty("Makeup");

      testSpecialty.Save();
      Specialty savedSpecialty = Specialty.GetAll()[0];
      int result = savedSpecialty.GetId();
      int testId = testSpecialty.GetId();
      Assert.AreEqual(testId, result);
    }

  }
}
