using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class SitProfSubsidio
{
    public byte Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Detalhes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
