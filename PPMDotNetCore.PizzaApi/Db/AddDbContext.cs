﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPMDotNetCore.PizzaApi.Db
{
    internal class AddDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<PizzaModel> Pizza { get; set; }
        public DbSet<PizzaExtraModel> PizzaExtra { get; set; }
        public DbSet<PizzaOrderModel> PizzaOrders { get; set; }
        public DbSet<PizzaOrderDetailModel> PizzaOrderDetails { get; set; }
    }
    [Table("Tbl_Pizza")]
    public class PizzaModel
    {
        [Key]
        [Column("PizzaId")]
        public int Id { get; set; }
        [Column("Pizza")]
        public string Name { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceStr { get { return "$" + Price; } }
    }
    [Table("Table_PizzaExtra")]
    public class PizzaExtraModel
    {
        [Key]
        public int PizzaExtraId { get; set; }
        public string PizzaExtraName { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string PriceStr { get { return "$" + Price; } }
    }
    public class OrderRequest
    {
        public int PizzaId { get; set; }
        public int[] Extra { get; set; }
    }
    [Table("Tbl_PizzaOrder")]
    public class PizzaOrderModel
    {
        [Key]
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalAmount { get; set; }
    }
    [Table("Tbl_PizzaOrderDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
    }
    public class OrderMessage
    {
        public string message { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
