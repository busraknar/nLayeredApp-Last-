using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
       
public void Configure(EntityTypeBuilder<Product> builder)
        {
            // senin id alanın vardır zorunludur
            builder.ToTable("Products").HasKey(b => b.Id); // products tablosuna map olacaksın
            builder.Property(b => b.Id).HasColumnName("ProductId").IsRequired();

            builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
            builder.Property(b => b.ProductName).HasColumnName("ProductName").IsRequired(); // senin id alanın vardır zorunludur

            builder.Property(b => b.UnitPrice).HasColumnName("UnitPrice");

            builder.Property(b => b.UnitsInStock).HasColumnName("UnitsInStock");

            builder.Property(b => b.QuantityPerUnit).HasColumnName("QuantityPerUnit");

            builder.HasIndex(indexExpression: b => b.ProductName, name: "UK_Products_ProductName").IsUnique(); // UNİQUEkey ile işaretler alanlar veritabanında bir daha terar edemez anlamında. uniquekey default olarak tekrar edilemez.

            builder.HasOne(b => b.Category); // bire çok ilişki categorynin birden fazla ürünü vardır.

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); // benim tüm sorgularıma(selectlerime) ben sana hiç söylemeden benim bu filtremi(where koşulunu) uygula. yani where DeletedDate is null uygula demek. Bir nesneye default değer koymak istiyorsak bunu yapıyoruz.
        }

        
    }
}
