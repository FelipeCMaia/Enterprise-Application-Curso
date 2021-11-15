using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.Messages.Integration
{
    public class ResponseMessage: Message
    {
        public ValidationResult ValidationResult{ get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

    }
}
