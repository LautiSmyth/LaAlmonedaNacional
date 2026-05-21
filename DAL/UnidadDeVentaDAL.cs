using BE;
using System.Data.SqlClient;

namespace DAL
{
    public class UnidadDeVentaDAL
    {
        public void GuardarArticulo(Articulo articulo)
        {
            string queryBase = "INSERT INTO UnidadesDeVenta (Id, Nombre, Descripcion) VALUES (@Id, @Nombre, @Descripcion)";
            SqlParameter[] pBase = {
                new SqlParameter("@Id",          articulo.Id),
                new SqlParameter("@Nombre",      articulo.Nombre),
                new SqlParameter("@Descripcion", articulo.Descripcion)
            };
            Acceso.GetInstance().Escribir(queryBase, pBase);

            string queryArt = "INSERT INTO Articulos (Id, PrecioBase) VALUES (@Id, @PrecioBase)";
            SqlParameter[] pArt = {
                new SqlParameter("@Id",         articulo.Id),
                new SqlParameter("@PrecioBase", articulo.ObtenerPrecio())
            };
            Acceso.GetInstance().Escribir(queryArt, pArt);
        }

        public void GuardarLote(Lote lote)
        {
            string queryBase = "INSERT INTO UnidadesDeVenta (Id, Nombre, Descripcion) VALUES (@Id, @Nombre, @Descripcion)";
            SqlParameter[] pBase = {
                new SqlParameter("@Id",          lote.Id),
                new SqlParameter("@Nombre",      lote.Nombre),
                new SqlParameter("@Descripcion", lote.Descripcion)
            };
            Acceso.GetInstance().Escribir(queryBase, pBase);
        }

        public void GuardarRelacionLote(int idLotePadre, int idComponenteHijo)
        {
            string queryRelacion = "INSERT INTO Lote_Contenido (IdLotePadre, IdComponenteHijo) VALUES (@IdLotePadre, @IdComponenteHijo)";
            SqlParameter[] parametros = {
                new SqlParameter("@IdLotePadre",      idLotePadre),
                new SqlParameter("@IdComponenteHijo", idComponenteHijo)
            };
            Acceso.GetInstance().Escribir(queryRelacion, parametros);
        }
    }
}
