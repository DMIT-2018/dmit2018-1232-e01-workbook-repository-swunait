﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HogWildSystem.Entities;

[Table("Invoice")]
internal partial class Invoice
{
    [Key]
    public int InvoiceID { get; set; }

    public DateTime InvoiceDate { get; set; }

    public int CustomerID { get; set; }

    public int EmployeeID { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Tax { get; set; }

    public bool RemoveFromViewFlag { get; set; }

    [ForeignKey("CustomerID")]
    [InverseProperty("Invoices")]
    public virtual Customer Customer { get; set; }

    [ForeignKey("EmployeeID")]
    [InverseProperty("Invoices")]
    public virtual Employee Employee { get; set; }

    [InverseProperty("Invoice")]
    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
}