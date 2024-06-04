using System;
using System.Collections.Generic;

namespace LogicalData.Data.Context;

/// <summary>
/// Almacena los usuarios del sistema.
/// </summary>
public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Username { get; set; } = null!;

    public byte[] Contrasenia { get; set; } = null!;

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
