﻿namespace CustomerBase.API.Business.Domain.Handlers.ValidationHandler;
public sealed class ValidationResponse
{
    public Dictionary<string, string> Errors { get; private set; }
    public bool Valid => Errors.Count == 0;

    private ValidationResponse(Dictionary<string, string> errors)
    {
        Errors = errors;
    }

    public static ValidationResponse CreateResponse(Dictionary<string, string> errors)
    {
        return new ValidationResponse(errors);
    }
}
