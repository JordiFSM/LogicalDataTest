using System;
using System.Collections.Generic;

namespace LogicalData.Data.Context;

/// <summary>
/// Almacena las ordenes del sistema
/// </summary>
public partial class Orden
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Usuario Usuario { get; set; } = null!;
}
