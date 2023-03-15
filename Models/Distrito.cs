using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Distrito
{
    public byte Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Concelho> Concelhos { get; } = new List<Concelho>();
}
