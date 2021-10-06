using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciamento_Empresas.Models;
//using BC = BCrypt.Net.BCrypt;


namespace Gerenciamento_Empresas.Models
{
    public class InicializaBD
    {
        public static void Initialize(Contexto contexto)
        {

            if (contexto.Database.CanConnect())
            {
                contexto.Database.CanConnect();
            }
            else
            {
                contexto.Database.EnsureCreated();
            }
            contexto.SaveChanges();
        }
    }
}