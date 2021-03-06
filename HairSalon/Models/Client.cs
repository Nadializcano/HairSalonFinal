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

      public static void ClearAll()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

      public override bool Equals(System.Object otherClient)
      {
        if (!(otherClient is Client))
        {
          return false;
        }
        else
        {
          Client newClient = (Client) otherClient;
          bool idEquality = this.GetId() == newClient.GetId();
          bool nameEquality = this.GetName() == newClient.GetName();
          bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
          return (idEquality && nameEquality && stylistEquality);
        }
      }

      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@name, @stylist_id);";
        MySqlParameter name = new MySqlParameter();
        name.ParameterName = "@name";
        name.Value = this._name;
        cmd.Parameters.Add(name);
        MySqlParameter stylistId = new MySqlParameter();
        stylistId.ParameterName = "@stylist_id";
        stylistId.Value = this._stylistId;
        cmd.Parameters.Add(stylistId);
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

      public static List<Client> GetAll()
      {
        List<Client> allClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientId = rdr.GetInt32(0);
          string clientName = rdr.GetString(1);
          int clientStylistId = rdr.GetInt32(2);
          Client newClient = new Client(clientName, clientStylistId, clientId);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allClients;
      }

      public static Client Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int clientId = 0;
        string clientName = "";
        int clientStylistId = 0;
        while(rdr.Read())
        {
          clientId = rdr.GetInt32(0);
          clientName = rdr.GetString(1);
          clientStylistId = rdr.GetInt32(2);
        }
        Client newClient = new Client(clientName, clientStylistId, clientId);
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return newClient;
      }

      public void Edit(string newName)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE clients SET name = @newName WHERE id = @searchId;";
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
        cmd.CommandText = @"DELETE FROM clients WHERE id = @ClientId; DELETE FROM stylist WHERE id = @ClientId;";
        MySqlParameter clientIdParameter = new MySqlParameter();
        clientIdParameter.ParameterName = "@ClientId";
        clientIdParameter.Value = this.GetId();
        cmd.Parameters.Add(clientIdParameter);
        cmd.ExecuteNonQuery();
        if (conn != null)
        {
          conn.Close();
        }
       }

       public static void DeleteAll()
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"DELETE FROM clients;";
         cmd.ExecuteNonQuery();
         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
       }

       // public List<Client> GetClients()
       //  {
       //   List<Client> allClients = new List<Client> {};
       //   MySqlConnection conn = DB.Connection();
       //   conn.Open();
       //   var cmd = conn.CreateCommand() as MySqlCommand;
       //   cmd.CommandText = @"SELECT * FROM clients WHERE client_id = @client_id;";
       //   MySqlParameter clientId = new MySqlParameter();
       //   clientId.ParameterName = "@client_id";
       //   clientId.Value = this._id;
       //   cmd.Parameters.Add(clientId);
       //   var rdr = cmd.ExecuteReader() as MySqlDataReader;
       //   while(rdr.Read())
       //   {
       //     int clientsId = rdr.GetInt32(0);
       //     string clientName = rdr.GetString(1);
       //     int clientStylistId = rdr.GetInt32(2);
       //     Client newClient = new Client(clientName, clientStylistId, clientsId);
       //     allClients.Add(newClient);
       //   }
       //   conn.Close();
       //   if (conn != null)
       //   {
       //     conn.Dispose();
       //   }
       //   return allClients;
       // }

  }
}
