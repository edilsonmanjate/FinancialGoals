﻿using FinancialGoals.Application.Common.Bases;

namespace FinancialGoals.Application.Common.Exceptions;

public class ValidationExceptionCustom : Exception
{
    public IEnumerable<BaseError> Errors { get; }

    public ValidationExceptionCustom()
        : base("One or more validation failures have occured.")
    {
        Errors = new List<BaseError>();
    }

    public ValidationExceptionCustom(IEnumerable<BaseError> errors)
        : this()
    {
        Errors = errors;
    }
}
