using FATEA.DataAccess.Entity.Common;
using FATEA.ProjetoPoster.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.DataAccess.Entity.Configurations
{
    public class EventoTypeConfiguration : FATEATypeConfiguration<Evento>
    {
        public override void ConfigureTableName()
        {
            ToTable("EVN_EVENTO");
        }

        public override void ConfigureFields()
        {
            Property(a => a.Id)
                .HasColumnName("EVN_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(a => a.Nome)
                .HasColumnName("EVN_NOME")
                .HasMaxLength(100)
                .IsRequired();
            Property(a => a.Tema)
                .HasColumnName("EVN_TEMA")
                .HasMaxLength(100)
                .IsRequired();
            Property(a => a.Descricao)
                .HasColumnName("EVN_DESCRICAO")
                .HasMaxLength(150)
                .IsRequired();
            Property(a => a.NumMaximoAutores)
                .HasColumnName("EVN_NUMMAXIMOAUTORES")
                .IsRequired();
            Property(a => a.NumAvaliadores)
                .HasColumnName("EVN_NUMAVALIADORES")
                .IsRequired();
            Property(a => a.Status)
                .HasColumnName("EVN_STATUS")
                .IsRequired();
            Property(a => a.DataInicio)
                .HasColumnName("EVN_DATAINICIO")
                .IsRequired();
            Property(a => a.DataFim)
                .HasColumnName("EVN_DATAFIM")
                .IsRequired();
            Property(a => a.Informacoes)
                .HasColumnName("EVN_INFORMACOES")
                .HasMaxLength(200)
                .IsRequired();
        }

        public override void ConfigurePrimaryKeys()
        {
            
        }

        public override void ConfigureForeignKeys()
        {
            
        }

        public override void ConfigureOthers()
        {
            
        }
    }
}
