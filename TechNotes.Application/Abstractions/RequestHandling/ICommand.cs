
using MediatR;
using TechNotes.Domain.Abstractions;

namespace TechNotes.Application.Abstractions.RequestHandling;

public interface ICommand : IRequest<Result>
{

}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{

}
