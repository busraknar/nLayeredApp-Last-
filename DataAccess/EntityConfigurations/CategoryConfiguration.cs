using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
             // senin id alanın vardır zorunludur
            builder.ToTable("Categories").HasKey(b => b.Id); // category tablosuna map olacaksın
            builder.Property(b => b.Id ).HasColumnName("CategoryId").IsRequired(); 
            builder.Property(b => b.Name).HasColumnName("CategoryName").IsRequired(); // senin id alanın vardır zorunludur
            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Categories_CategoryName").IsUnique(); // UNİQUEkey ile işaretler alanlar veritabanında bir daha terar edemez anlamında. uniquekey default olarak tekrar edilemez.

            builder.HasMany(b => b.Products); // bire çok ilişki categorynin birden fazla ürünü vardır.

          builder.HasQueryFilter(b => !b.DeletedDate.HasValue); // benim tüm sorgularıma(selectlerime) ben sana hiç söylemeden benim bu filtremi(where koşulunu) uygula. yani where DeletedDate is null uygula demek. Bir nesneye default değer koymak istiyorsak bunu yapıyoruz.

            //queryfilter --> 
        }
    }
}
