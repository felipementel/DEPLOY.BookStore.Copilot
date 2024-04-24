﻿using FluentValidation.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DEPLOY.BookStore.Domain.Aggregates
{
    [ExcludeFromCodeCoverage]
    public record BaseEntity<Tid>
    {
        public Tid Id { get; set; }

        public List<string> Erros { get; set; }
    }
}