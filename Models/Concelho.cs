using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Concelho
{
    public ushort Id { get; set; }

    public string Nome { get; set; } = null!;

    public byte DistritoId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Distrito Distrito { get; set; } = null!;

    public virtual ICollection<Formando> Formandos { get; } = new List<Formando>();
}
