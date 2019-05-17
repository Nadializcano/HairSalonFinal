using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
       Stylist stylist = Stylist.Find(stylistId);
       return View(stylist);
    }

    [HttpPost("/clients/deleteAll")]
    public ActionResult DeleteAll()
    {
      Client.ClearAll();
      return View();
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
      public ActionResult Edit(int stylistId, int clientId)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(stylistId);
        model.Add("stylist", stylist);
        Client client = Client.Find(clientId);
        model.Add("client", client);
        return View(model);
      }

    [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
      public ActionResult Update(int stylistId, int clientId, string newName)
      {
        Client client = Client.Find(clientId);
        client.Edit(newName);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(stylistId);
        model.Add("stylist", stylist);
        model.Add("client", client);
        return View("Show", model);
      }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}/delete")]
      public ActionResult Delete(int stylistId, int clientId)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Client client = Client.Find(clientId);
        client.Delete();
        model.Add("client", client);
        return View(model);
      }

    [HttpPost("/clients/deleted")]
      public ActionResult Deleted(int clientId)
      {
        Client client = Client.Find(clientId);
        client.Delete();
        return View("Index");
      }

      // [ActionName("Destroy"), HttpPost("/clients/{id}/delete")]
      // public ActionResult Destroy(int id)
      // {
      //   Client clients = Client.Find(id);
      //   List<Client> stylistClients = clients.GetClients();
      //   foreach(Client client in stylistClients)
      //   {
      //     client.Delete();
      //   }
      //
      //   return RedirectToAction("Index");
      // }
  }
}
