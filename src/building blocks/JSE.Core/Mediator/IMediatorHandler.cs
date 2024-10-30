using FluentValidation.Results;
using JSE.Core.Messages;

namespace JSE.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;

        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
