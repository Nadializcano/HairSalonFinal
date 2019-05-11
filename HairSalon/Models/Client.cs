using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
      private string _name;
      private int _id;
      private int _stylistId;

      public Client (string name, int stylistId, int id = 0)
      {
          _name = name;
          _stylistId = stylistId;
          _id = id;
      }
      public string GetName()
      {
          return _name;
      }
      public void SetName(string newName)
      {
        _name = newName;
      }
      public int GetId()
      {
        return _id;
      }
      public int GetStylistId()
      {
        return _stylistId;
      }
    }

}
