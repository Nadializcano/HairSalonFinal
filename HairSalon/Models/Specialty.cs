using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
      private string _description;
      private int _id;

      public Specialty (string description, int id = 0)
      {
        _description = description;
        _id = id;
      }

      public string GetDescription()
      {
        return _description;
      }

      public void SetDescription(string newDescription)
      {
        _description = newDescription;
      }

      public int GetId()
      {
        return _id;
      }
  }
}
