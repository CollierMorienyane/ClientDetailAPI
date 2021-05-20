using ClientInfoAPI.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClientInfoAPI.Controllers
{
    public class AddressTypeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                 select AddressTypeID, AddressTypeName from AddressType
            ";

            DataTable addressTypes = new DataTable();

            try
            {
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
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error getting Address Types");
            }

            return Request.CreateResponse(HttpStatusCode.OK, addressTypes);
        }

        public string Post(AddressType addressType)
        {
            try
            {
                string query = @"insert into AddressType values('" + addressType.AddressTypeName + @"')";

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
                return "Insert failure";
            }

            return "Added Successfully";
        }

        public string Put(AddressType addressType)
        {
            try
            {
                string query = @"update AddressType set AddressTypeName = '" + addressType.AddressTypeName + @"' where AddressTypeID = " + addressType.AddressTypeID;

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
                string query = @"delete from AddresType where AddressTypeID = " + id;

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
                return "Delete failure";
            }

            return "Deleted Successfully";
        }
    }
}
