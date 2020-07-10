using System;
using System.Collections.Generic;
using System.Text;
using Renta_Car.DAL;
using Renta_Car.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Renta_Car.RentaBll
{
    public class ProveedorBll
    {
        public static bool Guardar(Proveedores proveedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Proveedores.Add(proveedores) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }


        public static bool Modificar(Proveedores proveedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(proveedores).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Proveedores.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }


        public static Proveedores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Proveedores proveedores = new Proveedores();

            try
            {
                proveedores = contexto.Proveedores.Find(id);

            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proveedores;
        }

        public static List<Proveedores> GetList(Expression<Func<Proveedores, bool>> proveedores)
        {
            List<Proveedores> lista = new List<Proveedores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Proveedores.Where(proveedores).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
