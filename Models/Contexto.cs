using Microsoft.EntityFrameworkCore;
using Gerenciamento_Empresas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Gerenciamento_Empresas.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            InicializaBD.Initialize(this);
        }

        public DbSet<Empresa> Empresa { get; set; }
     
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<Estado> Estado { get; set; }

        public DbSet<Regiao> Regiao { get; set; }

        public DbSet<Cidade> Cidade { get; set; }

        public DbSet<Locais> Locais { get; set; }

        public DbSet<Lote> Lote { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<PessoaVacina> PessoaVacina { get; set; }

        public DbSet<VacinaEmpresa> VacinaEmpresa { get; set; }
    }

}

