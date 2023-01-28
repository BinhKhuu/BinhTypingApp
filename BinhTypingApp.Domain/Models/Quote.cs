using System;
using System.Collections.Generic;

namespace BinhTypingApp.Domain.Models;

public partial class Quote
{
    public int Id { get; set; }

    public Guid? QuoteId { get; set; }

    public string? QuoteValue { get; set; }

    public string? QuoteSource { get; set; }

    public int? QuoteLength { get; set; }

    public string? QuoteLanguage { get; set; }

    public string? QuoteSize { get; set; }

    public virtual Language? QuoteLanguageNavigation { get; set; }
}
