using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeradorDeRotas.Models;

namespace GeradorDeRotas.Data
{
    public class GeradorDeRotasContext : DbContext
    {
        public GeradorDeRotasContext (DbContextOptions<GeradorDeRotasContext> options)
            : base(options)
        {
        }

        public DbSet<GeradorDeRotas.Models.Cidade> Cidade { get; set; }

        public DbSet<GeradorDeRotas.Models.Equipe> Equipe { get; set; }

        public DbSet<GeradorDeRotas.Models.Pessoa> Pessoa { get; set; }
    }
}
