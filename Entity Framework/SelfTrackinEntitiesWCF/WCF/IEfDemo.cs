using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entidades;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEfDemo
    {
        [OperationContract]
        List<Pais> ObtenerPaises();

        [OperationContract]
        int Modificar(Pais pais);

        [OperationContract]
        Pais ObtenerPaisPorId(int id);

        [OperationContract]
        int InsertarPais(Pais pais);

        [OperationContract]
        int ModificarPaisPorId(int id);
    }


   
}
