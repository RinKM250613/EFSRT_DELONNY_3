﻿using Dominio.Entidad.Negocio.Entidad.Lista;
using Dominio.Entidad.Negocio.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidad.Negocio.Abstraccion;
using Microsoft.Win32;

namespace Infraestructura.SQL.Negocios
{
    public class pedidoDAO : IPedido
    {
        public string Add(Pedido pedido)
        {
            string mensaje = "";
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_MERGE_PEDIDOS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPedido", pedido.codPedido);
                        cmd.Parameters.AddWithValue("@CodCliente", pedido.codCliente);
                        cmd.Parameters.AddWithValue("@CodEmpleado", pedido.codEmpleado);
                        cmd.Parameters.AddWithValue("@FechaEntrega", pedido.fecEntrega);
                        cmd.Parameters.AddWithValue("@FechaEnvio", pedido.fecEnvio);
                        cmd.Parameters.AddWithValue("@EstadoEnvio", pedido.estadoEnvio);
                        cmd.Parameters.AddWithValue("@Cantidad", pedido.cantidad);
                        cmd.Parameters.AddWithValue("@DireccionDestino", pedido.direccionDestino);
                        cmd.Parameters.AddWithValue("@CiudadDestino", pedido.ciudadDestino);

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha registrado {c} pedido";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public string Delete(string id)
        {
            string mensaje = "";
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_ELIMINAR_PEDIDO", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPedido", id);

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha eliminado {c} pedido";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;
        }
        public Pedido Find(string id)
        {
            Pedido ped = new Pedido();
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_BUSCAR_PEDIDO_X_ID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPedido", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ped = new Pedido()
                            {
                                codPedido = reader.GetString(0),
                                codCliente = reader.GetString(1),
                                codEmpleado = reader.GetString(2),
                                fecPedido = reader.GetDateTime(3).Date,
                                fecEntrega = reader.GetDateTime(4).Date,
                                fecEnvio = reader.GetDateTime(5).Date,
                                estadoEnvio = reader.GetString(6),
                                cantidad = reader.GetInt16(7),
                                direccionDestino = reader.GetString(8),
                                ciudadDestino = reader.GetString(9),

                            };
                        }
                    }
                }
            }
            return ped;
        }
        public string Update(Pedido pedido)
        {
            string mensaje = "";
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_MERGE_PEDIDOS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPedido", pedido.codPedido);
                        cmd.Parameters.AddWithValue("@CodCliente", pedido.codCliente);
                        cmd.Parameters.AddWithValue("@CodEmpleado", pedido.codEmpleado);
                        cmd.Parameters.AddWithValue("@FechaEntrega", pedido.fecEntrega);
                        cmd.Parameters.AddWithValue("@FechaEnvio", pedido.fecEnvio);
                        cmd.Parameters.AddWithValue("@EstadoEnvio", pedido.estadoEnvio);
                        cmd.Parameters.AddWithValue("@Cantidad", pedido.cantidad);
                        cmd.Parameters.AddWithValue("@DireccionDestino", pedido.direccionDestino);
                        cmd.Parameters.AddWithValue("@CiudadDestino", pedido.ciudadDestino);

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha registrado {c} pedido";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;
        }
        public IEnumerable<PedidoLista> GetAll()
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            List<PedidoLista> tempo = new List<PedidoLista>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_PEDIDOS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempo.Add(new PedidoLista()
                            {
                                codPedido = reader.GetString(0),
                                nomCliente = reader.GetString(1),
                                nomEmpleado = reader.GetString(2),
                                fecPedido = reader.GetDateTime(3),
                                fecEnvio = reader.GetDateTime(4),
                                estadoEnvio = reader.GetString(5),
                                cantidad = reader.GetInt16(6),
                                direccionDestino = reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return tempo;
        }

        public IEnumerable<PedidoLista> GetByDateAndDni(DateTime? fechaPed, string dni)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            List<PedidoLista> tempo = new List<PedidoLista>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_FILTRAR_FECHA_X_DNI", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (fechaPed.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@FecRegis", fechaPed.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FecRegis", DBNull.Value);
                    }

                    if (string.IsNullOrWhiteSpace(dni))
                    {
                        cmd.Parameters.AddWithValue("@DniCli", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DniCli", dni.Trim());
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempo.Add(new PedidoLista()
                            {
                                codPedido = reader.GetString(0),
                                nomCliente = reader.GetString(1),
                                dniCli = reader.GetString(2),
                                nomEmpleado = reader.GetString(3),
                                fecPedido = reader.GetDateTime(4).Date,
                                fecEnvio = reader.GetDateTime(5).Date,
                                estadoEnvio = reader.GetString(6),
                                cantidad = reader.GetInt16(7),
                                direccionDestino = reader.GetString(8),
                            });
                        }
                    }
                }
            }
            return tempo;
        }
    }
}
