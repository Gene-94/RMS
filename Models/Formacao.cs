using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Formacao
{
    public ulong Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public byte? RegimePresencaId { get; set; }

    public byte? RegimeHorarioId { get; set; }

    public ushort? DuracaoHoras { get; set; }

    public DateOnly? DataInicioPrevista { get; set; }

    public ulong? CoordenadorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Coordenador? Coordenador { get; set; }

    public virtual ICollection<FormacaoRequisito> FormacaoRequisitos { get; } = new List<FormacaoRequisito>();

    public virtual ICollection<Inscricao> Inscricos { get; } = new List<Inscricao>();

    public virtual RegimesHorario? RegimeHorario { get; set; }

    public virtual RegimesPresenca? RegimePresenca { get; set; }
}
