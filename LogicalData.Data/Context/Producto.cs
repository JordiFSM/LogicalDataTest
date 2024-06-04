using System;
using System.Collections.Generic;

namespace LogicalData.Data.Context;

/// <summary>
/// Almacena los productos del sistema.
/// </summary>
public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public decimal Precio { get; set; }

    public bool Iva { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
