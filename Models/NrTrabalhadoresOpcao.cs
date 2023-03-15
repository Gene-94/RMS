using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class NrTrabalhadoresOpcao
{
    public byte Id { get; set; }

    public string NomeOpcao { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Empresa> Empresas { get; } = new List<Empresa>();
}
