using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Inscricao
{
    public ulong Id { get; set; }

    public ulong FormandoId { get; set; }

    public ulong FormacaoId { get; set; }

    public DateOnly DataInscricao { get; set; }

    public byte Preferencia { get; set; }

    public byte IdEstado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Formacao Formacao { get; set; } = null!;

    public virtual Formando Formando { get; set; } = null!;

    public virtual EstadoInscricao IdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<IncricaoRequisito> IncricaoRequisitos { get; } = new List<IncricaoRequisito>();
}
