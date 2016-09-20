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
        public async Task<string> Agentes(string dsn)
        {
            string queryString = "SELECT * FROM agrupaciones";

            IList<Agente> agentes = new List<Agente>();
            using (OdbcConnection connection = new OdbcConnection("DSN=" + dsn))
            {
                OdbcCommand command = new OdbcCommand(queryString, connection);

                connection.Open();

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    agentes.Add(ReadAgenteDr(reader));
                }

                // Call Close when done reading.
                reader.Close();
            }
            return JsonConvert.SerializeObject(agentes); ;
        }

        public async Task<string> Agente(string dsn, string codigo)
        {
            string queryString = "SELECT * FROM agrupaciones WHERE codigo = '" + codigo + "'";

            IList<Agente> clientes = new List<Agente>();
            using (OdbcConnection connection = new OdbcConnection("DSN=" + dsn))
            {
                OdbcCommand command = new OdbcCommand(queryString, connection);

                connection.Open();

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(ReadAgenteDr(reader));
                }

                // Call Close when done reading.
                reader.Close();
            }
            return JsonConvert.SerializeObject(clientes); ;
        }

        public Agente ReadAgenteDr(OdbcDataReader reader)
        {
            Agente c = new Agente();
            c.proId = (string)reader["codigo"];
            if (!reader.IsDBNull(12))
                c.nombre = (string)reader["nombre"];
            if (!reader.IsDBNull(11))
                c.fechaAlta = (DateTime)reader["fecha_alta"];
            if (!reader.IsDBNull(23))
                c.fechaBaja = (DateTime?)reader["fecha_baja"];
            c.activa = true;
            if (!reader.IsDBNull(22))
                c.contacto1 = (string)reader["contacto"];
            if (!reader.IsDBNull(14))
                c.direccion = (string)reader["domicilio"];
            if (!reader.IsDBNull(17))
                c.codPostal = (string)reader["distrito"];
            if (!reader.IsDBNull(16))
                c.poblacion = (string)reader["poblacion"];
            if (!reader.IsDBNull(18))
                c.provincia = (string)reader["provincia"];
            if (!reader.IsDBNull(19))
                c.telefono1 = (string)reader["telefono"];
            if (!reader.IsDBNull(20))
                c.fax = (string)reader["fax"];
            if (!reader.IsDBNull(21))
                c.email = (string)reader["mail"];
            if (!reader.IsDBNull(2))
                c.observaciones = (string)reader["notas"];
            return c;
        }
    }
}
