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
        public async Task<string> Empresas(string dsn)
        {
            string queryString = "SELECT * FROM empresas";

            IList<Empresa> empresas = new List<Empresa>();
            using (OdbcConnection connection = new OdbcConnection("DSN=" + dsn))
            {
                OdbcCommand command = new OdbcCommand(queryString, connection);

                connection.Open();

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Empresa e = new Empresa();
                    e.proId = (string)reader["codigo"];
                    e.nombre = (string)reader["nombre"];
                    if (!reader.IsDBNull(2))
                        e.nif = (string)reader["nif"];
                    if (!reader.IsDBNull(4))
                        e.fechaAlta = (DateTime)reader["fecha_alta"];
                    if (!reader.IsDBNull(5))
                        e.fechaBaja = (DateTime?)reader["fecha_baja"];
                    e.activa = true;
                    if ((string)reader["activo"] == "N")
                        e.activa = false;
                    if (!reader.IsDBNull(6))
                        e.contacto1 = (string)reader["contacto1"];
                    if (!reader.IsDBNull(7))
                        e.contacto2 = (string)reader["contacto2"];
                    if (!reader.IsDBNull(8))
                        e.direccion = (string)reader["direccion"];
                    if (!reader.IsDBNull(11))
                        e.codPostal = (string)reader["distrito"];
                    if (!reader.IsDBNull(9))
                        e.poblacion = (string)reader["poblacion"];
                    if (!reader.IsDBNull(10))
                        e.provincia = (string)reader["provincia"];
                    if (!reader.IsDBNull(13))
                        e.fax = (string)reader["fax"];
                    if (!reader.IsDBNull(14))
                        e.email = (string)reader["email"];
                    if (!reader.IsDBNull(20))
                        e.observaciones = (string)reader["notas"];
                    empresas.Add(e);
                }

                // Call Close when done reading.
                reader.Close();
            }
            return JsonConvert.SerializeObject(empresas); ;
        }

        public async Task<string> Empresa(string dsn, string codigo)
        {
            string queryString = "SELECT * FROM empresas WHERE codigo = " + codigo;

            IList<Empresa> empresas = new List<Empresa>();
            using (OdbcConnection connection = new OdbcConnection("DSN=" + dsn))
            {
                OdbcCommand command = new OdbcCommand(queryString, connection);

                connection.Open();

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Empresa e = new Empresa();
                    e.proId = (string)reader["codigo"];
                    e.nombre = (string)reader["nombre"];
                    if (!reader.IsDBNull(2))
                        e.nif = (string)reader["nif"];
                    if (!reader.IsDBNull(4))
                        e.fechaAlta = (DateTime)reader["fecha_alta"];
                    if (!reader.IsDBNull(5))
                        e.fechaBaja = (DateTime?)reader["fecha_baja"];
                    e.activa = true;
                    if ((string)reader["activo"] == "N")
                        e.activa = false;
                    if (!reader.IsDBNull(6))
                        e.contacto1 = (string)reader["contacto1"];
                    if (!reader.IsDBNull(7))
                        e.contacto2 = (string)reader["contacto2"];
                    if (!reader.IsDBNull(8))
                        e.direccion = (string)reader["direccion"];
                    if (!reader.IsDBNull(11))
                        e.codPostal = (string)reader["distrito"];
                    if (!reader.IsDBNull(9))
                        e.poblacion = (string)reader["poblacion"];
                    if (!reader.IsDBNull(10))
                        e.provincia = (string)reader["provincia"];
                    if (!reader.IsDBNull(13))
                        e.fax = (string)reader["fax"];
                    if (!reader.IsDBNull(14))
                        e.email = (string)reader["email"];
                    if (!reader.IsDBNull(20))
                        e.observaciones = (string)reader["notas"];
                    empresas.Add(e);
                }

                // Call Close when done reading.
                reader.Close();
            }
            return JsonConvert.SerializeObject(empresas); ;
        }
    }
}
