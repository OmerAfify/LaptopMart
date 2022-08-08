using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LaptopMart.Models
{
    public partial class LapShopContext : DbContext
    {
        public LapShopContext()
        {
        }

        public LapShopContext(DbContextOptions<LapShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessInfo> TbBusinessInfos { get; set; }
        public virtual DbSet<CashTransacion> TbCashTransacions { get; set; }
        public virtual DbSet<Category> TbCategories { get; set; }
        public virtual DbSet<Customer> TbCustomers { get; set; }
        public virtual DbSet<customerItem> TbCustomerItems { get; set; }
        public virtual DbSet<Item> TbItems { get; set; }
        public virtual DbSet<ItemDiscount> TbItemDiscounts { get; set; }
        public virtual DbSet<ItemImage> TbItemImages { get; set; }
        public virtual DbSet<ItemType> TbItemTypes { get; set; }
        public virtual DbSet<OS> TbOs { get; set; }
        public virtual DbSet<PurchaseInvoice> TbPurchaseInvoices { get; set; }
        public virtual DbSet<PurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
        public virtual DbSet<salesInvoice> TbSalesInvoices { get; set; }
        public virtual DbSet<salesInvoiceItem> TbSalesInvoiceItems { get; set; }
        public virtual DbSet<slider> TbSliders { get; set; }
        public virtual DbSet<Supplier> TbSuppliers { get; set; }
        public virtual DbSet<VwItem> VwItems { get; set; }
        public virtual DbSet<VwItemCategory> VwItemCategories { get; set; }
        public virtual DbSet<VwItemsOutOfInvoice> VwItemsOutOfInvoices { get; set; }
        public virtual DbSet<VwSalesInvoice> VwSalesInvoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BusinessInfo>(entity =>
            {
                entity.HasKey(e => e.businessInfoId);

                entity.ToTable("TbBusinessInfo");

                entity.HasIndex(e => e.customerId, "IX_TbBusinessInfo_CutomerId")
                    .IsUnique();

                entity.Property(e => e.budget).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.businessCardNumber).HasMaxLength(20);

                entity.HasOne(d => d.cutomer)
                    .WithOne(p => p.businessInfo)
                    .HasForeignKey<BusinessInfo>(d => d.customerId);
            });

            modelBuilder.Entity<CashTransacion>(entity =>
            {
                entity.HasKey(e => e.cashTransactionId);

                entity.ToTable("TbCashTransacion");

                entity.Property(e => e.cashDate).HasColumnType("datetime");

                entity.Property(e => e.cashValue).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.categoryId);

                entity.Property(e => e.categoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.createdBy)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
                entity.Property(e => e.createdDate).HasDefaultValueSql("getDate()");

                entity.Property(e => e.imageName)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.showInHomePage)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });



            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.customerId);

                entity.Property(e => e.customerName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<customerItem>(entity =>
            {
                entity.HasKey(e => new { e.itemId, e.customerId });

                entity.HasIndex(e => e.customerId, "IX_TbCustomerItems_CustomerId");

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.customerItems)
                    .HasForeignKey(d => d.customerId);

                entity.HasOne(d => d.item)
                    .WithMany(p => p.customerItems)
                    .HasForeignKey(d => d.itemId);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.itemId);

                entity.HasIndex(e => e.itemTypeId, "IX_TbItems_ItemTypeId");

                entity.HasIndex(e => e.osId, "IX_TbItems_OsId");

                entity.Property(e => e.createdBy)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.createdDate).HasDefaultValueSql("('2020-09-20T00:00:00.0000000')");

                entity.Property(e => e.imageName).HasMaxLength(200);

                entity.Property(e => e.itemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.itemTypeId).HasDefaultValueSql("((0))");

                entity.Property(e => e.osId).HasDefaultValueSql("((0))");

                entity.Property(e => e.purchasePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.salesPrice).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.category)
                    .WithMany(p => p.items)
                    .HasForeignKey(d => d.categoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItems_TbCategories");

                entity.HasOne(d => d.itemType)
                    .WithMany(p => p.items)
                    .HasForeignKey(d => d.itemTypeId)
                    .HasConstraintName("FK_TbItems_TbItemTypes");

                entity.HasOne(d => d.os)
                    .WithMany(p => p.items)
                    .HasForeignKey(d => d.osId)
                    .HasConstraintName("FK_TbItems_TbOs");
            });

            modelBuilder.Entity<ItemDiscount>(entity =>
            {
                entity.HasKey(e => e.itemDiscountId);

                entity.ToTable("TbItemDiscount");

                entity.HasIndex(e => e.itemId, "IX_TbItemDiscount_ItemId");

                entity.Property(e => e.discountPercent).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.item)
                    .WithMany(p => p.itemDiscounts)
                    .HasForeignKey(d => d.itemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItemDiscounts_TbItems");
            });

            modelBuilder.Entity<ItemImage>(entity =>
            {
                entity.HasKey(e => e.imageId);

                entity.Property(e => e.imageName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.item)
                    .WithMany(p => p.itemImages)
                    .HasForeignKey(d => d.itemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItemImages_TbItems");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => e.itemTypeId);

                entity.Property(e => e.createdBy).IsRequired();

                entity.Property(e => e.itemTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OS>(entity =>
            {
                entity.HasKey(e => e.osId);

                entity.Property(e => e.createdBy).IsRequired();

                entity.Property(e => e.imageName).IsRequired();

                entity.Property(e => e.osName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PurchaseInvoice>(entity =>
            {
                entity.HasKey(e => e.invoiceId);

                entity.Property(e => e.invoiceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.supplier)
                    .WithMany(p => p.purchaseInvoices)
                    .HasForeignKey(d => d.supplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoices_TbSuppliers");
            });

            modelBuilder.Entity<PurchaseInvoiceItem>(entity =>
            {
                entity.HasKey(e => e.invoiceItemId);

                entity.Property(e => e.invoiceItemId).ValueGeneratedNever();

                entity.Property(e => e.invoicePrice).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.qty).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.invoice)
                    .WithMany(p => p.purchaseInvoiceItems)
                    .HasForeignKey(d => d.invoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoiceItems_TbPurchaseInvoices");

                entity.HasOne(d => d.item)
                    .WithMany(p => p.purchaseInvoiceItems)
                    .HasForeignKey(d => d.itemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoiceItems_TbItems");
            });

            modelBuilder.Entity<salesInvoice>(entity =>
            {
                entity.HasKey(e => e.invoiceId);

                entity.Property(e => e.createdBy)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.createdDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.deliveryDate).HasColumnType("datetime");

                entity.Property(e => e.invoiceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<salesInvoiceItem>(entity =>
            {
                entity.HasKey(e => e.invoiceItemId);

                entity.Property(e => e.invoicePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.qty).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.invoice)
                    .WithMany(p => p.salesInvoiceItems)
                    .HasForeignKey(d => d.invoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoiceItems_TbSalesInvoices");

                entity.HasOne(d => d.item)
                    .WithMany(p => p.salesInvoiceItems)
                    .HasForeignKey(d => d.itemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoiceItems_TbItems");
            });

            modelBuilder.Entity<slider>(entity =>
            {
                entity.HasKey(e => e.sliderId);

                entity.ToTable("TbSlider");

                entity.Property(e => e.description).HasMaxLength(500);

                entity.Property(e => e.imageName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.title).HasMaxLength(200);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK_TbSupplier");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<VwItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwItems");

                entity.Property(e => e.categoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.createdBy).IsRequired();

                entity.Property(e => e.imageName).HasMaxLength(200);

                entity.Property(e => e.itemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.itemTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.osName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.purchasePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.salesPrice).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<VwItemCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwItemCategories");

                entity.Property(e => e.categoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.imageName).HasMaxLength(200);

                entity.Property(e => e.itemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.purchasePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.salesPrice).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<VwItemsOutOfInvoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwItemsOutOfInvoices");

                entity.Property(e => e.categoryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.invoicePrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.itemName).HasMaxLength(100);

                entity.Property(e => e.purchasePrice).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<VwSalesInvoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwSalesInvoices");

                entity.Property(e => e.deliveryDate).HasColumnType("datetime");

                entity.Property(e => e.invoiceDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
