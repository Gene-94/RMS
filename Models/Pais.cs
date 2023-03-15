using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Pais
{
    public byte Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Formando> FormandoNacionalidades { get; } = new List<Formando>();

    public virtual ICollection<Formando> FormandoNaturalidades { get; } = new List<Formando>();
}
