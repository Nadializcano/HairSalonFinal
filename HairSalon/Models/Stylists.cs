using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
    {
      private string _name;
      private int _id;

      public Stylist(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylist;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylist;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(StylistName, StylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylist (name) VALUES (@name);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId().Equals(newStylist.GetId());
        bool nameEquality = this.GetName().Equals(newStylist.GetName());
        return (idEquality && nameEquality);
      }
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylist WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int StylistId = 0;
      string StylistName = "";
      while(rdr.Read())
      {
        StylistId = rdr.GetInt32(0);
        StylistName = rdr.GetString(1);
      }
      Stylist newStylist = new Stylist(StylistName, StylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newStylist;
    }

    public List<Client> GetClients()
     {
      List<Client> allStylistClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";
      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylist_id";
      stylistId.Value = this._id;
      cmd.Parameters.Add(stylistId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int clientStylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, clientStylistId, clientId);
        allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylistClients;
    }

    public static void DeleteAll()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylist;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      public void Edit(string newName)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE stylist SET name = @newName WHERE id = @searchId;";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@newName";
        name.Value = newName;
        cmd.Parameters.Add(name);
        cmd.ExecuteNonQuery();
        _name = newName;
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }

      }

      public void Delete()
      {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"DELETE FROM stylist WHERE id = @stylistId";
         MySqlParameter stylistId = new MySqlParameter();
         stylistId.ParameterName = "@stylistId";
         stylistId.Value = _id;
         cmd.Parameters.Add(stylistId);
         cmd.ExecuteNonQuery();
         conn.Close();
         if (conn != null)
         {
           conn.Close();
         }
       }

       public List<Specialty> GetSpecialties()
        {
          MySqlConnection conn = DB.Connection();
         conn.Open();
          MySqlCommand cmd = conn.CreateCommand();
          cmd.CommandText = @"SELECT specialties.* FROM stylist
          JOIN specialties_stylist ON (stylist.id = specialties_stylist.stylist_id)
          JOIN specialties ON (specialties_stylist.specialty_id = specialties.id)
         WHERE stylist.id = @StylistId;";

         MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = _id;
            cmd.Parameters.Add(stylistIdParameter);

           MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Specialty> specialties = new List<Specialty> {};
          while(rdr.Read())
            {
              int specialtyId = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);

                Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
                specialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return specialties;
        }


        public void AddSpecialty(Specialty newSpecialty)
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"INSERT INTO specialties_stylist (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
         MySqlParameter stylist_id = new MySqlParameter();
         stylist_id.ParameterName = "@StylistId";
         stylist_id.Value = _id;
         cmd.Parameters.Add(stylist_id);
         MySqlParameter specialty_id = new MySqlParameter();
         specialty_id.ParameterName = "@SpecialtyId";
         specialty_id.Value = newSpecialty.GetId();
         cmd.Parameters.Add(specialty_id);
         cmd.ExecuteNonQuery();
         conn.Close();
         if (conn != null)
         {
           conn.Dispose();
         }
       }


       // public List<Specialty> GetSpecialties()
       //  {
       //    MySqlConnection conn = DB.Connection();
       //   conn.Open();
       //    var cmd = conn.CreateCommand() as MySqlCommand;
       //    cmd.CommandText = @"SELECT specialty_id FROM specialties_stylist WHERE stylist_id = @StylistId;";
       //   MySqlParameter stylistIdParameter = new MySqlParameter();
       //      stylistIdParameter.ParameterName = "@StylistId";
       //      stylistIdParameter.Value = _id;
       //      cmd.Parameters.Add(stylistIdParameter);
       //
       //     var rdr = cmd.ExecuteReader() as MySqlDataReader;
       //      List<int> specialtyIds = new List<int> {};
       //    while(rdr.Read())
       //      {
       //        int specialtyId = rdr.GetInt32(0);
       //        specialtyIds.Add(specialtyId);
       //      }
       //      rdr.Dispose();
       //      List<Specialty> specialties = new List<Specialty> {};
       //      foreach (int specialtyId in specialtyIds)
       //      {
       //
       //      var specialtyQuery = conn.CreateCommand() as MySqlCommand;
       //      specialtyQuery.CommandText = @"SELECT * FROM specialties WHERE id = @SpecialtyId;";
       //      MySqlParameter specialtyIdParameter = new MySqlParameter();
       //      specialtyIdParameter.ParameterName = "@SpecialtyId";
       //      specialtyIdParameter.Value = specialtyId;
       //      specialtyQuery.Parameters.Add(specialtyIdParameter);
       //      var specialtyQueryRdr = specialtyQuery.ExecuteReader() as MySqlDataReader;
       //      while(specialtyQueryRdr.Read())
       //      {
       //        int thisSpecialtyId = specialtyQueryRdr.GetInt32(0);
       //        string specialtyDescription = specialtyQueryRdr.GetString(1);
       //        Specialty foundSpecialty = new Specialty(specialtyDescription, thisSpecialtyId);
       //        specialties.Add(foundSpecialty);
       //      }
       //      specialtyQueryRdr.Dispose();
       //      {
       //      conn.Close();
       //      if (conn != null)
       //      {
       //          conn.Dispose();
       //      }
       //      return specialties;
       //    }
       //  }
       // }











  }
}
