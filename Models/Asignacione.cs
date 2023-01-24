using System;
using System.Collections.Generic;

namespace SisalrilProject.Models;

public partial class Asignacione
{
    public int IdAsignacion { get; set; }

    public int? IdEdificio { get; set; }

    public int? IdTrabajador { get; set; }

    public DateTime? AsignacionFechaInicio { get; set; }

    public int? AsignacionNoDias { get; set; }

    public virtual Edificio? IdEdificioNavigation { get; set; }

    public virtual Trabajadore? IdTrabajadorNavigation { get; set; }
}
