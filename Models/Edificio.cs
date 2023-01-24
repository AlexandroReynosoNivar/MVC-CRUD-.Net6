using System;
using System.Collections.Generic;

namespace SisalrilProject.Models;

public partial class Edificio
{
    public int IdEdificio { get; set; }

    public string? EdificioDireccion { get; set; }

    public string? TipoEdificio { get; set; }

    public int? NivelCalidad { get; set; }

    public int? Categoria { get; set; }

    public virtual ICollection<Asignacione> Asignaciones { get; } = new List<Asignacione>();
}
