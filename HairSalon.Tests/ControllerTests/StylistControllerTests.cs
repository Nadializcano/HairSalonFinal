using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests {
    [TestClass]
    public class StylistsControllerTest {
    //
    //     [TestMethod]
    //     public void Create_ReturnsCorrectActionType_RedirectToActionResult () {
    //         //Arrange
    //         StylistsController controller = new StylistsController ();
    //
    //         //Act
    //         IActionResult view = controller.Create ("Jon");
    //
    //         //Assert
    //         Assert.IsInstanceOfType (view, typeof (RedirectToActionResult));
    //     }
    //
        // [TestMethod]
        // public void Create_RedirectsToCorrectAction_Index () {
        //     //Arrange
        //     StylistsController controller = new StylistsController ();
        //     RedirectToActionResult actionResult = controller.Create ("Jon") as RedirectToActionResult;
        //
        //     //Act
        //     string result = actionResult.ActionName;
        //
        //     //Assert
        //     Assert.AreEqual (result, "Index");
        // }
    //
        [TestMethod]
        public void Index_HasCorrectModelType_StylistsList()
        {
            //Arrange
            StylistsController controller = new StylistsController();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }
    }
}
