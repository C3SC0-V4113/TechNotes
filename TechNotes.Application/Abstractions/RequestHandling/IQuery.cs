using MediatR;
using TechNotes.Domain.Abstractions;

namespace TechNotes.Application.Abstractions.RequestHandling;

public interface IQuery<IResponse> : IRequest<Result<IResponse>>
{

}
