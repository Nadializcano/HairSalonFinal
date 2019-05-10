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
    public void GetAll_ReturnsAllStylistObjects_StylistList()
    {
        string name01 = "John";
        string name02 = "Maria";
        Stylist newStylist1 = new Stylist(name01);
        newStylist1.Save();
        Stylist newStylist2 = new Stylist(name02);
        newStylist2.Save();
        List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

        List<Stylist> actualResult = Stylist.GetAll();
        CollectionAssert.AreEqual(newList, actualResult);
    }

  }
}
