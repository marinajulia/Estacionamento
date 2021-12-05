using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data
{
    public static class BaseMap
    {
        public static ModelBuilder CreateMap(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SectionNewsEntity>()
            //    .HasOne(x => x.news)
            //    .WithMany(x => x.Sections)
            //    .HasForeignKey(x => x.id_news);

            //modelBuilder.Entity<FeedbackEntity>()
            //    .HasOne(x => x.news)
            //    .WithMany(x => x.Feedback)
            //    .HasForeignKey(x => x.id_news);

            //return modelBuilder;
        }
    }
}
