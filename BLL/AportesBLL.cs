using Microsoft.EntityFrameworkCore;
using P1_AP1_Stephany_2018_0654.DAL;
using P1_AP1_Stephany_2018_0654.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Stephany_2018_0654.BLL
{
   public class AportesBLL
    {
        /// <summary>
        /// Permite Guardar una entidad en la base de datos
        /// </summary>

        private static bool Insertar(Aportes Aportes)
        {
            bool paso = false;
            //Creamos una instancia del contexto para poder conectar con la DB
            Contexto db = new Contexto();
            try
            {
                if (db.Aportes.Add(Aportes) != null)

                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }

        /// <summary>
        /// Permite Modificar una entidad en la base de datos
        /// </summary>
        private static bool Modificar(Aportes Aportes)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(Aportes).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }

        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                Aportes Aportes = db.Aportes.Find(id);

                if (Existe(id))
                {
                    db.Aportes.Remove(Aportes);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        public static Aportes Buscar(int id)
        {
            Contexto db = new Contexto();
            Aportes Aportes = new Aportes();
            try
            {
                Aportes = db.Aportes.Find(id);

            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();
            }
            return Aportes;
        }
        /// <summary>
        /// Permite extraer una lista de Usuario de la base de datos
        /// </summary>
        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> expression)
        {
            List<Aportes> Aportes = new List<Aportes>();
            Contexto db = new Contexto();
            try
            {
                Aportes = db.Aportes.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Aportes;
        }

        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Aportes.Any(x => x.AporteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static bool Guardar(Aportes Aportes)
        {
            if (!Existe(Aportes.AporteId))
                return Insertar(Aportes);
            else
                return Modificar(Aportes);
        }
    }
}
