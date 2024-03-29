﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Store.Model
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Model.Category.Products))]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(Model.Supplier.Products))]
        public virtual Supplier Supplier { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
