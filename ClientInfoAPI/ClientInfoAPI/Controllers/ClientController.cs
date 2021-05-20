using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ClientInfoAPI.Models;

namespace ClientInfoAPI.Controllers
{
    public class ClientController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                 select c.ClientID, c.FirstName, c.LastName, c.Gender from Client c 
            ";

            DataTable clients = new DataTable();

            try
            {
                using (var connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["ClientDB"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, connectionString))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(clients);
                        }
                    }
                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error getting Address Types");
            }

            return Request.CreateResponse(HttpStatusCode.OK, clients);
        }

        public string Post(Client client)
        {
            try
            {
                string query = @"insert into client(FirstName, LastName, Gender) values('" +
                    client.FirstName + @", " +
                    client.LastName + @", " + 
                    client.Gender +
            @"')";

                DataTable clients = new DataTable();

                using (var connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["ClientDB"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, connectionString))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(clients);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Insert failure";
            }

            return "Added Successfully";
        }
        
        public string Put(Client client)
        {
            try
            {
                string query = @"update client set FirstName = '" + client.FirstName +
                    @" ,LastName = " + client.LastName +
                    @" , Gender = " + client.Gender +
                    @"' where clientID = " + client.ClientID;

                DataTable addressTypes = new DataTable();

                using (var connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["ClientDB"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, connectionString))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(addressTypes);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Update failure";
            }

            return "Updated Successfully";
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from client where ClientID = " + id;

                DataTable clients = new DataTable();

                using (var connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["ClientDB"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, connectionString))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(clients);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "Delete failure";
            }

            return "Deleted Successfully";
        }

        [Route("api/Client/GetAllAddressTypeNames")]
        [HttpGet]
        public HttpResponseMessage GetAllAddressTypeNames()
        {
            string query = @"
                 select AddressTypeName from AddressType  
            ";

            DataTable addressTypeNames = new DataTable();

            try
            {
                using (var connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["ClientDB"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, connectionString))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(addressTypeNames);
                        }
                    }
                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error getting Address Types");
            }

            return Request.CreateResponse(HttpStatusCode.OK, addressTypeNames);

        }

        [Route("api/Client/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = System.Web.HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = System.Web.HttpContext.Current.Server.MapPath("~/Images/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;
            }
            catch(Exception)
            {
                return "default.png";
            }
        }
    }
}
