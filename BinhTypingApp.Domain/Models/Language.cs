using System;
using System.Collections.Generic;

namespace BinhTypingApp.Domain.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Language1 { get; set; } = null!;

    public virtual ICollection<Quote> Quotes { get; } = new List<Quote>();
}
