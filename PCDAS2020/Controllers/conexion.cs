using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;


namespace PCDAS2020.Controllers
{
    public class conexion
    {
        private string cadenaConexion { get; set; }
        private SqlConnection conexionSQL;
        public conexion()
        {
            cadenaConexion = @"Data source=(local); Initial Catalog=DASPC; Integrated Security =True";
        }
        public bool conectar()
        {
            try
            {
                this.conexionSQL = new SqlConnection(this.cadenaConexion);
                this.conexionSQL.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool estadoconexion()
        {
            switch (this.conexionSQL.State)
            {
                case System.Data.ConnectionState.Broken:
                    return true;
                case System.Data.ConnectionState.Open:
                    return true; 
                default:
                    return false;
            }
        }
        public void desconectar()
        {
            this.conexionSQL.Close();
        }
    }
}