using System;
using System.Collections.Generic;

namespace RegistrationManagmentSimplified.Models;

public partial class RegimesPresenca
{
    public byte Id { get; set; }

    public string NomeRegime { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Formacao> Formacos { get; } = new List<Formacao>();
}
