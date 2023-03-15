using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class EstadoInscricao
{
    public byte Id { get; set; }

    public string NomeEstado { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Inscricao> Inscricos { get; } = new List<Inscricao>();
}
