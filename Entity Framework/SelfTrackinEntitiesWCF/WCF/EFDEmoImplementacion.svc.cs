using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entidades;
using AccesoDatos;

namespace WCF
{
    public class Service1 : IEfDemo
    {
        #region Implementation of IEfDemo

        public List<Pais> ObtenerPaises()
        {
            using (EFDemoEntities context = new EFDemoEntities())
            {
                return (from p in context.Pais
                        select p).ToList();
            }
        }

        public int Modificar(Pais pais)
        {
            using (EFDemoEntities context = new EFDemoEntities())
            {
                context.Pais.ApplyChanges(pais);
                return context.SaveChanges();
            }
        }

        public Pais ObtenerPaisPorId(int id)
        {
            using (EFDemoEntities context = new EFDemoEntities())
            {
                return (from p in context.Pais
                        where p.Id == id
                        select p).First();
            }
        }

        public int InsertarPais(Pais pais)
        {
            using (EFDemoEntities context = new EFDemoEntities())
            {
                context.Pais.AddObject(pais);
                return context.SaveChanges();
            }
        }

        public int ModificarPaisPorId(int id)
        {
            using (EFDemoEntities context = new EFDemoEntities())
            {
                Pais pais = (from p in context.Pais
                             where p.Id == id
                             select p).FirstOrDefault();
                pais.Nombre = "Editadote";
                context.Pais.ApplyChanges(pais);
                return context.SaveChanges();
            }
        }

        #endregion
    }
}
