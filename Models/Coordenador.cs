using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class Coordenador
{
    public ulong Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string? AvatarPath { get; set; } = null;

    public DateTime? CreatedAt { get; set; } = null;

    public DateTime? UpdatedAt { get; set; } = null;
    public virtual ICollection<Formacao> Formacos { get; } = new List<Formacao>();
}
