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
    public class AlquilarBll
    {
        public static bool Guardar(Alquileres alquileres)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Alquileres.Add(alquileres) != null)
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

        

        public static bool Modificar(Alquileres alquileres)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(alquileres).State = EntityState.Modified;
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
                var eliminar = contexto.Alquileres.Find(id);
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


        public static Alquileres Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Alquileres alquileres = new Alquileres();

            try
            {
                alquileres = contexto.Alquileres.Find(id);

            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return alquileres;
        }

        public static List<Alquileres> GetList(Expression<Func<Alquileres, bool>> alquileres)
        {
            List<Alquileres> lista = new List<Alquileres>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Alquileres.Where(alquileres).ToList();
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
