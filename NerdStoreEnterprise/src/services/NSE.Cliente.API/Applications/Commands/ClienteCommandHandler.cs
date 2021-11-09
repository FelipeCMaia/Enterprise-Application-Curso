using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Applications.Commands
{
    public class ClienteCommandHandler : IRequestHandler<RegistrarClientCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email)

            return message.ValidationResult;

        }                
    }
}
