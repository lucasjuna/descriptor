﻿// <auto-generated />
using System;
using Descriptor.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Descriptor.Persistence.Migrations
{
    [DbContext(typeof(DescriptorContext))]
    partial class DescriptorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Descriptor.Domain.Entities.ItemReviewStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HsCode");

                    b.Property<string>("ItemId");

                    b.Property<string>("Method");

                    b.Property<DateTime>("ReviewDate");

                    b.Property<long>("ReviewerId");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ReviewerId");

                    b.ToTable("ItemReviewStatus");
                });

            modelBuilder.Entity("Descriptor.Domain.Entities.ProductImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("ItemId");

                    b.HasKey("Id");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Descriptor.Domain.Entities.ReviewerInfo", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("EmpId");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("LastLoginDateTime");

                    b.Property<string>("LastName");

                    b.Property<string>("LoginName");

                    b.HasKey("Id");

                    b.ToTable("ReviewerInfo");
                });

            modelBuilder.Entity("Descriptor.Domain.Entities.SellerInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("Address3");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("EbaySellerUserName")
                        .IsRequired();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastProcessDate");

                    b.Property<string>("State");

                    b.Property<int>("TotalItemsAccepted");

                    b.Property<int>("TotalItemsInReview");

                    b.Property<int>("TotalItemsRejected");

                    b.Property<int>("TotalItemsReviewed");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("EbaySellerUserName")
                        .IsUnique();

                    b.ToTable("SellerInfo");
                });

            modelBuilder.Entity("Descriptor.Domain.Entities.SellerProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("CrossboarderTrade");

                    b.Property<decimal>("EbayBuyItNowPrice");

                    b.Property<string>("EbayDescription");

                    b.Property<string>("EbayItemLocation");

                    b.Property<string>("EbayItemPictureDetails");

                    b.Property<string>("EbayViewItemUrl");

                    b.Property<string>("ItemId");

                    b.Property<string>("SKU");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SellerProductList");
                });

            modelBuilder.Entity("Descriptor.Domain.Entities.ItemReviewStatus", b =>
                {
                    b.HasOne("Descriptor.Domain.Entities.ReviewerInfo", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Descriptor.Domain.Entities.SellerProduct", b =>
                {
                    b.HasOne("Descriptor.Domain.Entities.SellerInfo", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
