using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Habilitacao
{
    public byte Id { get; set; }

    public string NomeDescritivo { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Formando> Formandos { get; } = new List<Formando>();
}
