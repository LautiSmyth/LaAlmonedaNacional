using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UnidadDeVentaDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public int GuardarArticulo(Articulo articulo)
        {
            try
            {
                string qBase = @"INSERT INTO UnidadesDeVenta (Nombre, Descripcion, Tipo)
                                 VALUES (@Nombre, @Descripcion, 'Articulo')";
                SqlParameter[] pBase = {
                    new SqlParameter("@Nombre",      articulo.Nombre),
                    new SqlParameter("@Descripcion", articulo.Descripcion)
                };
                int nuevoId = _acceso.EscribirYObtenerID(qBase, pBase);
                string qArt = "INSERT INTO Articulos (Id, PrecioBase) VALUES (@Id, @PrecioBase)";
                SqlParameter[] pArt = {
                    new SqlParameter("@Id",         nuevoId),
                    new SqlParameter("@PrecioBase", articulo.PrecioBase)
                };
                _acceso.Escribir(qArt, pArt);
                articulo.Id = nuevoId;
                return nuevoId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar artículo '{articulo.Nombre}': {ex.Message}", ex);
            }
        }

        public void ActualizarArticulo(Articulo articulo)
        {
            try
            {
                string qBase = @"UPDATE UnidadesDeVenta SET Nombre=@Nombre, Descripcion=@Descripcion WHERE Id=@Id";
                SqlParameter[] pBase = {
                    new SqlParameter("@Nombre",      articulo.Nombre),
                    new SqlParameter("@Descripcion", articulo.Descripcion),
                    new SqlParameter("@Id",          articulo.Id)
                };
                _acceso.Escribir(qBase, pBase);
                string qArt = "UPDATE Articulos SET PrecioBase=@PrecioBase WHERE Id=@Id";
                SqlParameter[] pArt = {
                    new SqlParameter("@PrecioBase", articulo.PrecioBase),
                    new SqlParameter("@Id",         articulo.Id)
                };
                _acceso.Escribir(qArt, pArt);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar artículo #{articulo.Id}: {ex.Message}", ex);
            }
        }

        public int GuardarLote(Lote lote)
        {
            try
            {
                string qBase = @"INSERT INTO UnidadesDeVenta (Nombre, Descripcion, Tipo)
                                 VALUES (@Nombre, @Descripcion, 'Lote')";
                SqlParameter[] pBase = {
                    new SqlParameter("@Nombre",      lote.Nombre),
                    new SqlParameter("@Descripcion", lote.Descripcion)
                };
                int nuevoId = _acceso.EscribirYObtenerID(qBase, pBase);
                lote.Id = nuevoId;
                return nuevoId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar lote '{lote.Nombre}': {ex.Message}", ex);
            }
        }

        public void ActualizarLote(Lote lote)
        {
            try
            {
                string q = @"UPDATE UnidadesDeVenta SET Nombre=@Nombre, Descripcion=@Descripcion WHERE Id=@Id";
                SqlParameter[] p = {
                    new SqlParameter("@Nombre",      lote.Nombre),
                    new SqlParameter("@Descripcion", lote.Descripcion),
                    new SqlParameter("@Id",          lote.Id)
                };
                _acceso.Escribir(q, p);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar lote #{lote.Id}: {ex.Message}", ex);
            }
        }

        public void GuardarRelacionLote(int idLotePadre, int idComponenteHijo)
        {
            try
            {
                string qCheck = @"SELECT COUNT(1) FROM Lote_Contenido WHERE IdLotePadre=@P AND IdComponenteHijo=@H";
                DataTable check = _acceso.Leer(qCheck, new[] {
                    new SqlParameter("@P", idLotePadre),
                    new SqlParameter("@H", idComponenteHijo)
                });
                if (Convert.ToInt32(check.Rows[0][0]) > 0)
                    throw new InvalidOperationException("El componente ya pertenece a este lote.");
                string q = @"INSERT INTO Lote_Contenido (IdLotePadre, IdComponenteHijo) VALUES (@IdLotePadre, @IdComponenteHijo)";
                SqlParameter[] p = {
                    new SqlParameter("@IdLotePadre",      idLotePadre),
                    new SqlParameter("@IdComponenteHijo", idComponenteHijo)
                };
                _acceso.Escribir(q, p);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar componente #{idComponenteHijo} al lote #{idLotePadre}: {ex.Message}", ex);
            }
        }

        public void EliminarRelacionLote(int idLotePadre, int idComponenteHijo)
        {
            try
            {
                string q = @"DELETE FROM Lote_Contenido WHERE IdLotePadre=@P AND IdComponenteHijo=@H";
                _acceso.Escribir(q, new[] {
                    new SqlParameter("@P", idLotePadre),
                    new SqlParameter("@H", idComponenteHijo)
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar relación: {ex.Message}", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                _acceso.Escribir("DELETE FROM UnidadesDeVenta WHERE Id=@Id",
                    new[] { new SqlParameter("@Id", id) });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar unidad #{id}: {ex.Message}", ex);
            }
        }

        public int ObtenerLotePadreDeComponente(int componenteId)
        {
            try
            {
                string q = "SELECT TOP 1 IdLotePadre FROM Lote_Contenido WHERE IdComponenteHijo=@Id";
                DataTable t = _acceso.Leer(q, new[] { new SqlParameter("@Id", componenteId) });
                if (t.Rows.Count == 0) return 0;
                return Convert.ToInt32(t.Rows[0]["IdLotePadre"]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar lote padre: {ex.Message}", ex);
            }
        }

        public UnidadDeVenta ObtenerPorId(int id)
        {
            try
            {
                string q = "SELECT Id, Nombre, Descripcion, Tipo FROM UnidadesDeVenta WHERE Id=@Id";
                DataTable tabla = _acceso.Leer(q, new[] { new SqlParameter("@Id", id) });
                if (tabla.Rows.Count == 0) return null;
                return ConstruirNodo(tabla.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener unidad #{id}: {ex.Message}", ex);
            }
        }

        public List<UnidadDeVenta> ObtenerTodos()
        {
            try
            {
                string q = @"SELECT Id, Nombre, Descripcion, Tipo FROM UnidadesDeVenta ORDER BY Tipo, Nombre";
                DataTable tabla = _acceso.Leer(q);
                var lista = new List<UnidadDeVenta>();
                foreach (DataRow fila in tabla.Rows)
                    lista.Add(ConstruirNodo(fila));
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener unidades de venta: {ex.Message}", ex);
            }
        }

        public List<Articulo> ObtenerArticulos()
        {
            try
            {
                string q = @"SELECT u.Id, u.Nombre, u.Descripcion, a.PrecioBase
                             FROM UnidadesDeVenta u JOIN Articulos a ON u.Id = a.Id ORDER BY u.Nombre";
                DataTable tabla = _acceso.Leer(q);
                var lista = new List<Articulo>();
                foreach (DataRow fila in tabla.Rows)
                    lista.Add(new Articulo(
                        Convert.ToInt32(fila["Id"]), fila["Nombre"].ToString(),
                        fila["Descripcion"].ToString(), Convert.ToDecimal(fila["PrecioBase"])));
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener artículos: {ex.Message}", ex);
            }
        }

        public List<Lote> ObtenerLotes()
        {
            try
            {
                string q = "SELECT Id, Nombre, Descripcion FROM UnidadesDeVenta WHERE Tipo='Lote' ORDER BY Nombre";
                DataTable tabla = _acceso.Leer(q);
                var lista = new List<Lote>();
                foreach (DataRow fila in tabla.Rows)
                    lista.Add(new Lote(Convert.ToInt32(fila["Id"]),
                        fila["Nombre"].ToString(), fila["Descripcion"].ToString()));
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener lotes: {ex.Message}", ex);
            }
        }

        private UnidadDeVenta ConstruirNodo(DataRow fila)
        {
            int id = Convert.ToInt32(fila["Id"]);
            string nombre = fila["Nombre"].ToString();
            string descripcion = fila["Descripcion"].ToString();
            string tipo = fila["Tipo"].ToString();
            if (tipo == "Articulo")
            {
                DataTable pTabla = _acceso.Leer("SELECT PrecioBase FROM Articulos WHERE Id=@Id",
                    new[] { new SqlParameter("@Id", id) });
                decimal precio = pTabla.Rows.Count > 0 ? Convert.ToDecimal(pTabla.Rows[0]["PrecioBase"]) : 0;
                return new Articulo(id, nombre, descripcion, precio);
            }
            else
            {
                var lote = new Lote(id, nombre, descripcion);
                DataTable hijos = _acceso.Leer(
                    "SELECT IdComponenteHijo FROM Lote_Contenido WHERE IdLotePadre=@Id",
                    new[] { new SqlParameter("@Id", id) });
                foreach (DataRow hijo in hijos.Rows)
                {
                    UnidadDeVenta componente = ObtenerPorId(Convert.ToInt32(hijo["IdComponenteHijo"]));
                    if (componente != null) lote.Agregar(componente);
                }
                return lote;
            }
        }
    }
}
