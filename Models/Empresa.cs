using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Empresa
{
    public ulong Id { get; set; }

    public string NomeEmpresa { get; set; } = null!;

    public string NifEmpresa { get; set; } = null!;

    public string? MoradaEmpresa { get; set; }

    public string? PostalEmpresa { get; set; }

    public byte NrTrabalhadoresId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Formando> Formandos { get; } = new List<Formando>();

    public virtual NrTrabalhadoresOpcao NrTrabalhadores { get; set; } = null!;
}
