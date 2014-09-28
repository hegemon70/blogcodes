using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace EFDemoMulticonexion
{
    class Program
    {
        static void Main(string[] args)
        {
            string conexionMySql = ConfigurationManager.ConnectionStrings["efdemomysqlEntities"].ConnectionString;
            using (EFDemoEntities context = new EFDemoEntities())
            {
                List<Pais> paisesLatinos = (from p in context.Pais
                                     select p).ToList();
            }
            using (EFDemoEntities context = new EFDemoEntities(conexionMySql))
            {
                List<Pais> paisesEuropeos = (from p in context.Pais
                                     select p).ToList();
            }
        }
    }
}
