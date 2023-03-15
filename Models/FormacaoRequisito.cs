using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class FormacaoRequisito
{
    public byte RequisitoId { get; set; }

    public ulong FormacaoId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Formacao Formacao { get; set; } = null!;

    public virtual Requisito Requisito { get; set; } = null!;
}
