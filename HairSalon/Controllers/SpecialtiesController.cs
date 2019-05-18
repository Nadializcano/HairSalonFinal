using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {

    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
       return View();
    }

    [HttpPost("/specialties")]
    public ActionResult Create(string specialtyDescription)
    {
      Specialty newSpecialty = new Specialty(specialtyDescription);
      newSpecialty.Save();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    [HttpGet("/specialties/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("selectedSpecialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpPost("/specialties/{specialtyId}/delete")]
  public ActionResult Delete(int specialtyId)
  {
    Specialty specialty = Specialty.Find(specialtyId);
    specialty.Delete();
    return RedirectToAction("Index");
  }

// [HttpPost("/specialties/{specialtyId}/stylists/new")]
// public ActionResult AddCategory(int specialtyId, int stylistId)
// {
//   Specialty specialty = Specialty.Find(specialtyId);
//   Stylist stylist = Stylist.Find(stylistId);
//   specialty.AddStylist(stylist);
//   return RedirectToAction("Show",  new { id = specialtyId });
// }

[HttpGet("/specialties/{specialtyId}/edit")]
      public ActionResult Edit(int specialtyId)
      {
        Specialty specialty = Specialty.Find(specialtyId);
        return View(specialty);
      }
      
    [HttpPost("/specialties/{specialtyId}/update")]
      public ActionResult Update(int specialtyId, string newDescription)
      {
        Specialty specialty = Specialty.Find(specialtyId);
        specialty.Edit(newDescription);
        List<Specialty> allSpecialties = Specialty.GetAll();
        return View("Index", allSpecialties);
      }







  }
}
