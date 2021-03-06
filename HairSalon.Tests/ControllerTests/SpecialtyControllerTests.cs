using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class  SpecialtiesControllerTests
    {
      [TestMethod]
      public void Index_HasCorrectModelType_SpecialtyList()
      {
         SpecialtiesController controller = new  SpecialtiesController();
        ViewResult indexView = controller.Index() as ViewResult;

        var result = indexView.ViewData.Model;

        Assert.IsInstanceOfType(result, typeof(List<Specialty>));
      }

      [TestMethod]
      public void New_ReturnsCorrectView_True()
      {
         SpecialtiesController controller = new  SpecialtiesController();
        ActionResult newView = controller.New();
        Assert.IsInstanceOfType(newView, typeof (ViewResult));
      }

      [TestMethod]
      public void Show_ReturnsCorrectView_True()
      {
         SpecialtiesController controller = new  SpecialtiesController();
        ActionResult showView = controller.Show(1);
        Assert.IsInstanceOfType(showView, typeof(ViewResult));
      }

    }
}
