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
                int nuevoId = _acceso.EscribirYObtenerID(
                    "INSERT INTO UnidadesDeVenta (Nombre, Descripcion, Tipo) VALUES (@Nombre, @Descripcion, 'Articulo')",
                    new[] { new SqlParameter("@Nombre", articulo.Nombre),
                            new SqlParameter("@Descripcion", (object)articulo.Descripcion ?? DBNull.Value) });
                _acceso.Escribir("INSERT INTO Articulos (Id, PrecioBase) VALUES (@Id, @PrecioBase)",
                    new[] { new SqlParameter("@Id", nuevoId),
                            new SqlParameter("@PrecioBase", articulo.PrecioBase) });
                articulo.Id = nuevoId;
                return nuevoId;
            }
            catch (Exception ex) { throw new Exception($"Error al guardar artículo '{articulo.Nombre}': {ex.Message}", ex); }
        }

        public void ActualizarArticulo(Articulo articulo)
        {
            try
            {
                _acceso.Escribir("UPDATE UnidadesDeVenta SET Nombre=@Nombre, Descripcion=@Descripcion WHERE Id=@Id",
                    new[] { new SqlParameter("@Nombre", articulo.Nombre),
                            new SqlParameter("@Descripcion", (object)articulo.Descripcion ?? DBNull.Value),
                            new SqlParameter("@Id", articulo.Id) });
                _acceso.Escribir("UPDATE Articulos SET PrecioBase=@PrecioBase WHERE Id=@Id",
                    new[] { new SqlParameter("@PrecioBase", articulo.PrecioBase),
                            new SqlParameter("@Id", articulo.Id) });
            }
            catch (Exception ex) { throw new Exception($"Error al actualizar artículo #{articulo.Id}: {ex.Message}", ex); }
        }

        public int GuardarLote(Lote lote)
        {
            try
            {
                int nuevoId = _acceso.EscribirYObtenerID(
                    "INSERT INTO UnidadesDeVenta (Nombre, Descripcion, Tipo) VALUES (@Nombre, @Descripcion, 'Lote')",
                    new[] { new SqlParameter("@Nombre", lote.Nombre),
                            new SqlParameter("@Descripcion", (object)lote.Descripcion ?? DBNull.Value) });
                lote.Id = nuevoId;
                return nuevoId;
            }
            catch (Exception ex) { throw new Exception($"Error al guardar lote '{lote.Nombre}': {ex.Message}", ex); }
        }

        public void ActualizarLote(Lote lote)
        {
            try
            {
                _acceso.Escribir("UPDATE UnidadesDeVenta SET Nombre=@Nombre, Descripcion=@Descripcion WHERE Id=@Id",
                    new[] { new SqlParameter("@Nombre", lote.Nombre),
                            new SqlParameter("@Descripcion", (object)lote.Descripcion ?? DBNull.Value),
                            new SqlParameter("@Id", lote.Id) });
            }
            catch (Exception ex) { throw new Exception($"Error al actualizar lote #{lote.Id}: {ex.Message}", ex); }
        }

        public void GuardarRelacionLote(int idLotePadre, int idComponenteHijo)
        {
            try
            {
                DataTable check = _acceso.Leer(
                    "SELECT COUNT(1) FROM Lote_Contenido WHERE IdLotePadre=@P AND IdComponenteHijo=@H",
                    new[] { new SqlParameter("@P", idLotePadre), new SqlParameter("@H", idComponenteHijo) });
                if (Convert.ToInt32(check.Rows[0][0]) > 0)
                    throw new InvalidOperationException("El componente ya pertenece a este lote.");
                _acceso.Escribir("INSERT INTO Lote_Contenido (IdLotePadre, IdComponenteHijo) VALUES (@P, @H)",
                    new[] { new SqlParameter("@P", idLotePadre), new SqlParameter("@H", idComponenteHijo) });
            }
            catch (Exception ex) { throw new Exception($"Error al agregar componente: {ex.Message}", ex); }
        }

        public void EliminarRelacionLote(int idLotePadre, int idComponenteHijo)
        {
            try
            {
                _acceso.Escribir("DELETE FROM Lote_Contenido WHERE IdLotePadre=@P AND IdComponenteHijo=@H",
                    new[] { new SqlParameter("@P", idLotePadre), new SqlParameter("@H", idComponenteHijo) });
            }
            catch (Exception ex) { throw new Exception($"Error al eliminar relación: {ex.Message}", ex); }
        }

        public void Eliminar(int id)
        {
            try
            {
                DataTable tipoT = _acceso.Leer("SELECT Tipo FROM UnidadesDeVenta WHERE Id=@Id",
                    new[] { new SqlParameter("@Id", id) });
                if (tipoT.Rows.Count == 0) return;
                EliminarNodo(id, tipoT.Rows[0]["Tipo"].ToString());
            }
            catch (Exception ex) { throw new Exception($"Error al eliminar unidad #{id}: {ex.Message}", ex); }
        }

        public void DesvinculrComponentes(int idLote)
        {
            try
            {
                _acceso.Escribir("DELETE FROM Lote_Contenido WHERE IdLotePadre=@Id",
                    new[] { new SqlParameter("@Id", idLote) });
            }
            catch (Exception ex) { throw new Exception($"Error al desvincular componentes del lote #{idLote}: {ex.Message}", ex); }
        }

        public void EliminarRecursivo(int id)
        {
            try
            {
                DataTable tipoT = _acceso.Leer("SELECT Tipo FROM UnidadesDeVenta WHERE Id=@Id",
                    new[] { new SqlParameter("@Id", id) });
                if (tipoT.Rows.Count == 0) return;
                string tipo = tipoT.Rows[0]["Tipo"].ToString();

                if (tipo == "Lote")
                {
                    DataTable hijos = _acceso.Leer(
                        "SELECT IdComponenteHijo FROM Lote_Contenido WHERE IdLotePadre=@Id",
                        new[] { new SqlParameter("@Id", id) });
                    _acceso.Escribir("DELETE FROM Lote_Contenido WHERE IdLotePadre=@Id",
                        new[] { new SqlParameter("@Id", id) });
                    foreach (DataRow hijo in hijos.Rows)
                        EliminarRecursivo(Convert.ToInt32(hijo["IdComponenteHijo"]));
                }

                EliminarNodo(id, tipo);
            }
            catch (Exception ex) { throw new Exception($"Error al eliminar recursivamente #{id}: {ex.Message}", ex); }
        }

        public bool TieneSubastaActiva(int id)
        {
            try
            {
                DataTable t = _acceso.Leer(
                    "SELECT COUNT(1) FROM Subastas WHERE UnidadVentaId=@Id AND Activa=1",
                    new[] { new SqlParameter("@Id", id) });
                return Convert.ToInt32(t.Rows[0][0]) > 0;
            }
            catch (Exception ex) { throw new Exception($"Error al verificar subasta activa: {ex.Message}", ex); }
        }

        public bool TieneSubastaActivaRecursiva(int id)
        {
            try
            {
                string q = @"WITH CTE AS (
                    SELECT @Id AS Id
                    UNION ALL
                    SELECT lc.IdComponenteHijo
                    FROM   Lote_Contenido lc
                    INNER JOIN CTE ON lc.IdLotePadre = CTE.Id
                )
                SELECT COUNT(1)
                FROM   Subastas s
                INNER JOIN CTE ON s.UnidadVentaId = CTE.Id
                WHERE  s.Activa = 1";
                DataTable t = _acceso.Leer(q, new[] { new SqlParameter("@Id", id) });
                return Convert.ToInt32(t.Rows[0][0]) > 0;
            }
            catch (Exception ex) { throw new Exception($"Error al verificar subastas activas en árbol: {ex.Message}", ex); }
        }

        public int ObtenerLotePadreDeComponente(int componenteId)
        {
            try
            {
                DataTable t = _acceso.Leer("SELECT TOP 1 IdLotePadre FROM Lote_Contenido WHERE IdComponenteHijo=@Id",
                    new[] { new SqlParameter("@Id", componenteId) });
                return t.Rows.Count == 0 ? 0 : Convert.ToInt32(t.Rows[0]["IdLotePadre"]);
            }
            catch (Exception ex) { throw new Exception($"Error al buscar lote padre: {ex.Message}", ex); }
        }

        public UnidadDeVenta ObtenerPorId(int id)
        {
            try
            {
                DataTable tabla = _acceso.Leer(
                    "SELECT Id, Nombre, Descripcion, Tipo FROM UnidadesDeVenta WHERE Id=@Id",
                    new[] { new SqlParameter("@Id", id) });
                return tabla.Rows.Count == 0 ? null : ConstruirNodo(tabla.Rows[0]);
            }
            catch (Exception ex) { throw new Exception($"Error al obtener unidad #{id}: {ex.Message}", ex); }
        }

        public List<UnidadDeVenta> ObtenerTodos()
        {
            try
            {
                DataTable tabla = _acceso.Leer(
                    "SELECT Id, Nombre, Descripcion, Tipo FROM UnidadesDeVenta ORDER BY Tipo, Nombre");
                var lista = new List<UnidadDeVenta>();
                foreach (DataRow fila in tabla.Rows)
                    lista.Add(ConstruirNodo(fila));
                return lista;
            }
            catch (Exception ex) { throw new Exception($"Error al obtener unidades de venta: {ex.Message}", ex); }
        }

        public List<Articulo> ObtenerArticulos()
        {
            try
            {
                DataTable tabla = _acceso.Leer(
                    "SELECT u.Id, u.Nombre, u.Descripcion, a.PrecioBase " +
                    "FROM UnidadesDeVenta u JOIN Articulos a ON u.Id=a.Id ORDER BY u.Nombre");
                var lista = new List<Articulo>();
                foreach (DataRow fila in tabla.Rows)
                    lista.Add(new Articulo(Convert.ToInt32(fila["Id"]), fila["Nombre"].ToString(),
                        fila["Descripcion"].ToString(), Convert.ToDecimal(fila["PrecioBase"])));
                return lista;
            }
            catch (Exception ex) { throw new Exception($"Error al obtener artículos: {ex.Message}", ex); }
        }

        public List<Lote> ObtenerLotes()
        {
            try
            {
                DataTable tabla = _acceso.Leer(
                    "SELECT Id, Nombre, Descripcion FROM UnidadesDeVenta WHERE Tipo='Lote' ORDER BY Nombre");
                var lista = new List<Lote>();
                foreach (DataRow fila in tabla.Rows)
                    lista.Add(new Lote(Convert.ToInt32(fila["Id"]),
                        fila["Nombre"].ToString(), fila["Descripcion"].ToString()));
                return lista;
            }
            catch (Exception ex) { throw new Exception($"Error al obtener lotes: {ex.Message}", ex); }
        }

        private void EliminarNodo(int id, string tipo)
        {
            _acceso.Escribir(
                @"DELETE FROM HistorialSubastas WHERE SubastaId IN
                  (SELECT Id FROM Subastas WHERE UnidadVentaId=@Id)",
                new[] { new SqlParameter("@Id", id) });

            _acceso.Escribir(
                @"DELETE FROM Suscripciones WHERE SubastaId IN
                  (SELECT Id FROM Subastas WHERE UnidadVentaId=@Id)",
                new[] { new SqlParameter("@Id", id) });

            _acceso.Escribir(
                "DELETE FROM HistorialSubastas WHERE UnidadVentaId=@Id",
                new[] { new SqlParameter("@Id", id) });

            _acceso.Escribir(
                "DELETE FROM Subastas WHERE UnidadVentaId=@Id",
                new[] { new SqlParameter("@Id", id) });

            _acceso.Escribir(
                "DELETE FROM Lote_Contenido WHERE IdComponenteHijo=@Id",
                new[] { new SqlParameter("@Id", id) });

            if (tipo == "Articulo")
                _acceso.Escribir(
                    "DELETE FROM Articulos WHERE Id=@Id",
                    new[] { new SqlParameter("@Id", id) });

            _acceso.Escribir(
                "DELETE FROM UnidadesDeVenta WHERE Id=@Id",
                new[] { new SqlParameter("@Id", id) });
        }

        private UnidadDeVenta ConstruirNodo(DataRow fila)
        {
            int id = Convert.ToInt32(fila["Id"]);
            string nombre = fila["Nombre"].ToString();
            string descripcion = fila["Descripcion"].ToString();
            string tipo = fila["Tipo"].ToString();

            if (tipo == "Articulo")
            {
                DataTable p = _acceso.Leer("SELECT PrecioBase FROM Articulos WHERE Id=@Id",
                    new[] { new SqlParameter("@Id", id) });
                decimal precio = p.Rows.Count > 0 ? Convert.ToDecimal(p.Rows[0]["PrecioBase"]) : 0;
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
                    UnidadDeVenta comp = ObtenerPorId(Convert.ToInt32(hijo["IdComponenteHijo"]));
                    if (comp != null) lote.Agregar(comp);
                }
                return lote;
            }
        }
    }
}
