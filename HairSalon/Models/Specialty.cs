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

      public static List<Specialty> GetAll()
      {
        List<Specialty> allSpecialtys = new List<Specialty> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM specialties;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int specialtyId = rdr.GetInt32(0);
          string specialtyDescription = rdr.GetString(1);
          Specialty newSpecialty = new Specialty(specialtyDescription,specialtyId);
          allSpecialtys.Add(newSpecialty);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allSpecialtys;
      }
  }
}
