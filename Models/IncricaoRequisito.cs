using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class IncricaoRequisito
{
    public byte RequisitoId { get; set; }

    public ulong InscricaoId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Inscricao Inscricao { get; set; } = null!;

    public virtual Requisito Requisito { get; set; } = null!;
}
