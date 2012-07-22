﻿using System;
using System.Linq;
using System.Security.Principal;

namespace UCosmic.Domain.InstitutionalAgreements
{
    public class DetachFileFromAgreementCommand
    {
        public DetachFileFromAgreementCommand(IPrincipal principal, Guid fileGuid, Guid agreementGuid)
        {
            if (principal == null) throw new ArgumentNullException("principal");
            Principal = principal;

            if (fileGuid == Guid.Empty) throw new ArgumentException("Cannot be empty", "fileGuid");
            FileGuid = fileGuid;

            if (agreementGuid == Guid.Empty) throw new ArgumentException("Cannot be empty", "agreementGuid");
            AgreementGuid = agreementGuid;
        }

        public IPrincipal Principal { get; private set; }
        public Guid FileGuid { get; private set; }
        public Guid AgreementGuid { get; private set; }
        public bool IsNewlyDetached { get; internal set; }
    }

    public class DetachFileFromAgreementHandler : IHandleCommands<DetachFileFromAgreementCommand>
    {
        private readonly ICommandEntities _entities;

        public DetachFileFromAgreementHandler(ICommandEntities entities)
        {
            _entities = entities;
        }

        public void Handle(DetachFileFromAgreementCommand command)
        {
            if (command == null) throw new ArgumentNullException("command");

            // todo: this should be FindByPrimaryKey
            var entity = _entities.Get2<InstitutionalAgreementFile>()
                .SingleOrDefault(x =>
                    x.EntityId == command.FileGuid &&
                    x.Agreement.EntityId == command.AgreementGuid
                );

            if (entity == null) return;
            _entities.Purge(entity);
            command.IsNewlyDetached = true;
        }
    }
}
