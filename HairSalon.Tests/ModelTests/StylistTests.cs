using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest
  {


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
  }
}
