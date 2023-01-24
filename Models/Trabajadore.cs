using System;
using System.Collections.Generic;

namespace SisalrilProject.Models;

public partial class Trabajadore
{
    public int IdTrabajador { get; set; }

    public string? TrabajadorNombre { get; set; }

    public decimal? TrabajadorTarifa { get; set; }

    public string? Oficio { get; set; }

    public int? TrabajadorSupervisor { get; set; }

    public virtual ICollection<Asignacione> Asignaciones { get; } = new List<Asignacione>();
}
