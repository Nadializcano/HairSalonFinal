using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
      private string _specialty;
      private int _id;

      public Specialty (string specialty, int id = 0)
      {
        _specialty = specialty;
        _id = id;
      }

      public string GetSpecialty()
      {
        return _specialty;
      }

      public void SetSpecialty(string newSpecialty)
      {
        _specialty = newSpecialty;
      }

      public int GetId()
      {
        return _id;
      }
  }
}
