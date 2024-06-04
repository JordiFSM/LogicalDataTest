using System;
using System.Collections.Generic;

namespace LogicalData.Data.Context;

/// <summary>
/// Almacena los items de las ordenes del sistema.
/// </summary>
public partial class Item
{
    public int Id { get; set; }

    public int OrdenId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal Total { get; set; }

    public virtual Orden Orden { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
