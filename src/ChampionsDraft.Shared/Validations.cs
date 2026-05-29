using ChampionsDraft.Shared.Models;

namespace ChampionsDraft.Shared;

public static class Validations
{
    public static bool ValidateInputParameter<TParam, TResult>(TParam param, out Result<TResult> result) {
        if (param is string str && string.IsNullOrWhiteSpace(str))
        {
            result = Result<TResult>.Failure(new Error($"{nameof(param)} parameter cannot be empty or whitespace.", ErrorType.BadRequest));
            return false;
        }

        if (param is null)
        {
            result = Result<TResult>.Failure(new Error($"{nameof(param)} parameter cannot be null.", ErrorType.BadRequest));
            return false;
        };

        result = Result<TResult>.Success();
        return true;
    }
}
