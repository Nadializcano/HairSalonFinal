using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
      Stylist.ClearAll();
    }

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=Nadia_lizcano_test;";
    }


    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
        string name = "Test Stylist";
        Stylist newStylist = new Stylist(name);
        Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
        string name = "Test Stylist";
        Stylist newStylist = new Stylist(name);
        string actualResult = newStylist.GetName();
        Assert.AreEqual(name, actualResult);
    }

    [TestMethod]
  public void GetAll_ReturnsEmptyListFromDatabase_StylistList()
  {
    List<Stylist> newList = new List<Stylist> { };
    List<Stylist> result = Stylist.GetAll();
    CollectionAssert.AreEqual(newList, result);
  }

  [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Maria");
      Stylist secondStylist = new Stylist("Maria");

      //Assert
      Assert.AreEqual(firstStylist, secondStylist);
    }
    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Maria");
      testStylist.Save();

      //Act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }


    // [TestMethod]
    // public void GetId_ReturnsStylistId_Int()
    // {
    //     string name = "Test Stylist";
    //     Stylist newStylist = new Stylist(name);
    //     int actualResult = newStylist.GetId();
    //     Assert.AreEqual(1, actualResult);
    // }

    [TestMethod]
    public void GetAll_ReturnsAllStylistObjects_StylistList()
    {
        string name01 = "Jon";
        string name02 = "Maria";
        Stylist newStylist1 = new Stylist(name01);
        newStylist1.Save();
        Stylist newStylist2 = new Stylist(name02);
        newStylist2.Save();
        List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

        List<Stylist> actualResult = Stylist.GetAll();
        CollectionAssert.AreEqual(newList, actualResult);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToStylist_Id()
    {
      //Arrange
      Stylist testStylist = new Stylist("Maria");
      testStylist.Save();

      //Act
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }


    [TestMethod]
    public void Find_ReturnsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Maria");
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.AreEqual(testStylist, foundStylist);
    }

  //   [TestMethod]
  // public void GetClients_RetrievesAllClientsWithStylist_ClientList()
  // {
  //   //Arrange, Act
  //   Stylist testStylist = new Stylist("Maria");
  //   testStylist.Save();
  //   Client firstClient = new Client("Noah", testStylist.GetId());
  //   firstClient.Save();
  //   Client secondClient = new Client("Sandra", testStylist.GetId());
  //   secondClient.Save();
  //   List<Client> testClientList = new List<Client> {firstClient, secondClient};
  //   List<Client> resultClientList = testStylist.GetClients();
  //
  //   //Assert
  //   CollectionAssert.AreEqual(testClientList, resultClientList);
  // }


  }
}
