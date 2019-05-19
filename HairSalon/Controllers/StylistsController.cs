using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;


namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpPost("/stylists")]
    public ActionResult Create(string stylistName)
    {
      Stylist newStylist = new Stylist(stylistName);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult New()
    {
      return View();
    }
    // This one creates new Clients within a given Stylist, not new Stylists:
    [HttpPost("/stylists/{stylistId}/clients")]
    public ActionResult Create(int stylistId, string clientName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(stylistId);
      Client newClient = new Client(clientName, stylistId);
      newClient.Save();
      //foundStylist.AddClient(newClient);
      List<Client> stylistClients = foundStylist.GetClients();
      model.Add("stylistClients", stylistClients);
      model.Add("stylist", foundStylist);
      return View("Show", model);
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
      List<Client> allClients = Client.GetAll();
      List<Specialty> allSpecialties = Specialty.GetAll();
      model.Add("stylist", selectedStylist);
      model.Add("stylistClients", stylistClients);
      model.Add("stylistSpecialties", stylistSpecialties);
      model.Add("allClients", allClients);
      model.Add("allSpecialties", allSpecialties);
      return View(model);
    }

    [HttpPost("/stylists/delete")]
    public ActionResult Delete()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      return View();
    }

    [HttpGet("/stylists/{stylistId}/edit")]
    public ActionResult Edit(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }

    [HttpPost("/stylists/{stylistId}/update")]
    public ActionResult Update(int stylistId, string newName)
    {
      Stylist stylist = Stylist.Find(stylistId);
      stylist.Edit(newName);
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [ActionName("Destroy"), HttpPost("/stylists/{id}/delete")]
    public ActionResult Destroy(int id)
    {
      Stylist stylist = Stylist.Find(id);
      List<Client> stylistClients = stylist.GetClients();
      foreach(Client client in stylistClients)
      {
        client.Delete();
      }
      stylist.Delete();
      return RedirectToAction("Index");
    }

    [HttpPost("/stylists/{stylistId}/specialties/new")]
    public ActionResult AddSpecialty(int stylistId, int specialtyId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      Specialty specialty = Specialty.Find(specialtyId);
      stylist.AddSpecialty(specialty);
      return RedirectToAction("Show",  new { id = stylistId });
    }



  }
}
