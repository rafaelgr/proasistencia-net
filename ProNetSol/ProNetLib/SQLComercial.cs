using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using Newtonsoft.Json;

namespace ProNetLib
{
    public partial class SQLAny
    {
        public async Task<string> Comerciales(string dsn)
        {
            string queryString = "SELECT * FROM comerciales";

            IList<Comercial> comerciales = new List<Comercial>();
            using (OdbcConnection connection = new OdbcConnection("DSN=" + dsn))
            {
                OdbcCommand command = new OdbcCommand(queryString, connection);

                connection.Open();

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comerciales.Add(ReadComercialDr(reader));
                }

                // Call Close when done reading.
                reader.Close();
            }
            return JsonConvert.SerializeObject(comerciales); ;
        }

        public async Task<string> Comercial(string dsn, string codigo)
        {
            string queryString = "SELECT * FROM comerciales WHERE codigo = " + codigo;

            IList<Comercial> clientes = new List<Comercial>();
            using (OdbcConnection connection = new OdbcConnection("DSN=" + dsn))
            {
                OdbcCommand command = new OdbcCommand(queryString, connection);

                connection.Open();

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(ReadComercialDr(reader));
                }

                // Call Close when done reading.
                reader.Close();
            }
            return JsonConvert.SerializeObject(clientes); ;
        }

        public Comercial ReadComercialDr(OdbcDataReader reader)
        {
            Comercial c = new Comercial();
            c.proId = (int)reader["codigo"];
            if (!reader.IsDBNull(1))
            c.nombre = (string)reader["empresa"];
            if (!reader.IsDBNull(2))
                c.nif = (string)reader["nif"];
            if (!reader.IsDBNull(4))
                c.fechaAlta = (DateTime)reader["fecha_alta"];
            if (!reader.IsDBNull(5))
                c.fechaBaja = (DateTime?)reader["fecha_baja"];
            c.activa = true;
            if ((string)reader["activo"] == "N")
                c.activa = false;
            if (!reader.IsDBNull(6))
                c.contacto1 = (string)reader["contacto_1"];
            if (!reader.IsDBNull(7))
                c.contacto2 = (string)reader["contacto_2"];
            if (!reader.IsDBNull(8))
                c.direccion = (string)reader["direccion"];
            if (!reader.IsDBNull(11))
                c.codPostal = (string)reader["distrito"];
            if (!reader.IsDBNull(9))
                c.poblacion = (string)reader["poblacion"];
            if (!reader.IsDBNull(10))
                c.provincia = (string)reader["provincia"];
            if (!reader.IsDBNull(13))
                c.fax = (string)reader["fax"];
            if (!reader.IsDBNull(14))
                c.email = (string)reader["e_mail"];
            c.observaciones = "";
            return c;
        }
    }
}
