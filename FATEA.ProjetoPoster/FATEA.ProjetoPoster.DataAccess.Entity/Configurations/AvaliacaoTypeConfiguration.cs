using FATEA.DataAccess.Entity.Common;
using FATEA.ProjetoPoster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.DataAccess.Entity.Configurations
{
    class AvaliacaoTypeConfiguration : FATEATypeConfiguration<Avaliacao>
    {
        public override void ConfigureFields()
        {
            Property(p => p.Id)
                .HasColumnName("AVA_ID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(p => p.NotaTema)
                .HasColumnName("AVA_NOTA_TEMA")
                .IsRequired();
            Property(p => p.NotaIntroducao)
                .HasColumnName("AVA_NOTA_INTRODUCAO")
                .IsRequired();
            Property(p => p.NotaDesenvolvimento)
                .HasColumnName("AVA_NOTA_DESENVOLVIMENTO")
                .IsRequired();
            Property(p => p.NotaResultados)
                .HasColumnName("AVA_NOTA_RESULTADOS")
                .IsRequired();
            Property(p => p.NotaConclusao)
                .HasColumnName("AVA_NOTA_CONCLUSAO")
                .IsRequired();
            Property(p => p.NotaFinal)
                .HasColumnName("AVA_NOTA_FINAL")
                .IsRequired();
            Property(p => p.PosterId)
                .HasColumnName("POS_ID")
                .IsRequired();
            Property(p => p.AvaliadorId)
                .HasColumnName("AVL_ID")
                .IsRequired();
        }

        public override void ConfigureForeignKeys()
        {
            HasRequired(r => r.Poster)
                .WithMany(m => m.Avaliacoes)
                .HasForeignKey(fk => fk.PosterId)
                .WillCascadeOnDelete(false);
        }

        public override void ConfigureOthers()
        {

        }

        public override void ConfigurePrimaryKeys()
        {
            HasKey(pk => pk.Id);
        }

        public override void ConfigureTableName()
        {
            ToTable("AVA_AVALIACAO");
        }
    }
}
