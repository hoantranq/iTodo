namespace iTodo.Application.Common.Exceptions;

public class BadRequestException : Exception
{
    public string[] Errors { get; set; } = default!;

    public BadRequestException(string message) : base(message)
	{

	}

	public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
	{
        Errors = errors;
    }
}