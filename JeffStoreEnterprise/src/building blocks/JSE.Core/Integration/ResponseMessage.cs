using FluentValidation.Results;
using JSE.Core.Messages;

namespace JSE.Core.Integration
{
    public  class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult) 
        {
            ValidationResult = validationResult;
        }
    }
}
