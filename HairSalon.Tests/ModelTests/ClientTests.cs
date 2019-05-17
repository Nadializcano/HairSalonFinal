using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=Nadia_lizcano_test;";
    }
    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("Test", 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Noah";
      Client newClient = new Client(name, 1);
      string result = newClient.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetName_String()
    {
      string name = "Noah";
      Client newClient = new Client(name, 1);

      string updatedName = "Pris";
      newClient.SetName(updatedName);
      string result = newClient.GetName();

      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ClientList()
    {
      List<Client> newList = new List<Client> { };
      List<Client> result = Client.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      string name01 = "Maria";
      string name02 = "Noah";
      Client newClient1 = new Client(name01, 1);
      newClient1.Save();
      Client newClient2 = new Client(name02, 1);
      newClient2.Save();

      List<Client> newList = new List<Client> { newClient1, newClient2 };

      List<Client> result = Client.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      Client firstClient = new Client("Maria", 1);
      Client secondClient = new Client("Maria", 1);
      Assert.AreEqual(firstClient, secondClient);
    }

      // [TestMethod]
      // public void Save_SavesToDatabase_ClientList()
      // {
      //   //Arrange
      //   Client testClient = new Client("Noah", 1);
      //
      //   //Act
      //   testClient.Save();
      //   List<Client> result = Client.GetAll();
      //   List<Client> testList = new List<Client>{testClient};
      //
      //   //Assert
      //   CollectionAssert.AreEqual(testList, result);
      // }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      Client testClient = new Client("Noah", 1);
      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = testClient.GetId();
      Assert.AreEqual(testId, result);
    }

      // [TestMethod]
      // public void GetId_ClientsInstantiateWithAnIdAndGetterReturns_Int()
      // {
      //     //Arrange
      //     string name = "Noah";
      //     Client newClient = new Client(name);
      //
      //     //Act
      //     int result = newClient.GetId();
      //
      //     //Assert
      //     Assert.AreEqual(1, result);
      // }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Noah", 1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      string firstName = "Noah";
      Client testClient = new Client(firstName, 1);
      testClient.Save();
      string secondName = "Pris";

      testClient.Edit(secondName);
      string result = Client.Find(testClient.GetId()).GetName();

      Assert.AreEqual(secondName, result);
    }

    [TestMethod]
    public void GetStylistId_ReturnsClientsParentStylistId_Int()
    {
      Stylist newStylist = new Stylist("Noah", 1);
      Client newClient = new Client("Maria.", 1, newStylist.GetId());

      int result = newClient.GetStylistId();

      Assert.AreEqual(newStylist.GetId(), result);
    }

    [TestMethod]
    public void Delete_DeletesClientFromDatabase_Client()
    {
      string testName = "Test Client";
      Client testClient = new Client(testName, 1);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());
      foundClient.Delete();
      List<Client> newList = new List<Client>{};
      List<Client> testList = Client.GetAll();

      CollectionAssert.AreEqual(newList, testList);
    }
  }
}
