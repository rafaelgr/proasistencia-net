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
        public async Task<string> Clientes(string dsn)
        {
            string queryString = "SELECT * FROM clientes_locales";

            IList<Cliente> clientes = new List<Cliente>();
            using (OdbcConnection connection = new OdbcConnection("DSN=" + dsn))
            {
                OdbcCommand command = new OdbcCommand(queryString, connection);

                connection.Open();

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(ReadClienteDr(reader));
                }

                // Call Close when done reading.
                reader.Close();
            }
            return JsonConvert.SerializeObject(clientes); ;
        }

        public async Task<string> Cliente(string dsn, string codigo)
        {
            string queryString = "SELECT * FROM clientes_locales WHERE codigo = '" + codigo + "'";

            IList<Cliente> clientes = new List<Cliente>();
            using (OdbcConnection connection = new OdbcConnection("DSN=" + dsn))
            {
                OdbcCommand command = new OdbcCommand(queryString, connection);

                connection.Open();

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(ReadClienteDr(reader));
                }

                // Call Close when done reading.
                reader.Close();
            }
            return JsonConvert.SerializeObject(clientes); ;
        }

        public Cliente ReadClienteDr(OdbcDataReader reader)
        {
            Cliente c = new Cliente();
            c.proId = (string)reader["codigo"];
            c.nombre = (string)reader["nombre"];
            if (!reader.IsDBNull(2))
                c.nif = (string)reader["nif"];
            if (!reader.IsDBNull(6))
                c.fechaAlta = (DateTime)reader["fecha_alta"];
            if (!reader.IsDBNull(7))
                c.fechaBaja = (DateTime?)reader["fecha_baja"];
            c.activa = true;
            if ((string)reader["activo"] == "N")
                c.activa = false;
            if (!reader.IsDBNull(10))
                c.contacto1 = (string)reader["contacto_1"];
            if (!reader.IsDBNull(11))
                c.contacto2 = (string)reader["contacto_2"];
            if (!reader.IsDBNull(12))
                c.direccion = (string)reader["direccion"];
            if (!reader.IsDBNull(15))
                c.codPostal = (string)reader["distrito"];
            if (!reader.IsDBNull(13))
                c.poblacion = (string)reader["poblacion"];
            if (!reader.IsDBNull(14))
                c.provincia = (string)reader["provincia"];
            if (!reader.IsDBNull(18))
                c.fax = (string)reader["fax"];
            if (!reader.IsDBNull(19))
                c.email = (string)reader["email"];
            if (!reader.IsDBNull(21))
                c.observaciones = (string)reader["notas"];
            return c;
        }
    }
}
