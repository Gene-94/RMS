using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Requisito
{
    public byte Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<FormacaoRequisito> FormacaoRequisitos { get; } = new List<FormacaoRequisito>();

    public virtual ICollection<IncricaoRequisito> IncricaoRequisitos { get; } = new List<IncricaoRequisito>();
}
