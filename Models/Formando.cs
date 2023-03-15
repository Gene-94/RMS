using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Formando
{
    public ulong Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telemovel { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public byte TipoDocumentoId { get; set; }

    public byte? EstadoCivilId { get; set; }

    public string NrDocumento { get; set; } = null!;

    public DateOnly ValidadeDocumento { get; set; }

    public string Niss { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public byte? NacionalidadeId { get; set; }

    public byte? NaturalidadeId { get; set; }

    public byte HabilitacoesId { get; set; }

    public string? AreaCurso { get; set; }

    public ushort? AnoConclusao { get; set; }

    public string? EstabelecimentoEnino { get; set; }

    public string Certificado { get; set; } = null!;

    public string Emprego { get; set; } = null!;

    public byte SubsidioId { get; set; }

    public string? UltimaProff { get; set; }

    public DateOnly? InicioProff { get; set; }

    public DateOnly? FimProff { get; set; }

    public ulong? EmpresaId { get; set; }

    public string Morada { get; set; } = null!;

    public ushort ConcelhoId { get; set; }

    public string CodPostal { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Concelho Concelho { get; set; } = null!;

    public virtual Empresa? Empresa { get; set; }

    public virtual EstadoCivil? EstadoCivil { get; set; }

    public virtual Habilitacao Habilitacoes { get; set; } = null!;

    public virtual ICollection<Inscricao> Inscricos { get; } = new List<Inscricao>();

    public virtual Pais? Nacionalidade { get; set; }

    public virtual Pais? Naturalidade { get; set; }

    public virtual Subsidio Subsidio { get; set; } = null!;

    public virtual TiposDocumento TipoDocumento { get; set; } = null!;
}
