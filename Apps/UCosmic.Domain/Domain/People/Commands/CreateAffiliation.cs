﻿using System;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using UCosmic.Domain.Establishments;

namespace UCosmic.Domain.People
{
    public class CreateAffiliationCommand
    {
        public int PersonId { get; set; }
        public int EstablishmentId { get; set; }
        public bool IsClaimingStudent { get; set; }
        public bool IsClaimingEmployee { get; set; }
    }

    public class CreateAffiliationHandler : IHandleCommands<CreateAffiliationCommand>
    {
        private readonly ICommandEntities _entities;

        public CreateAffiliationHandler(ICommandEntities entities)
        {
            _entities = entities;
        }

        public void Handle(CreateAffiliationCommand command)
        {
            if (command == null) throw new ArgumentNullException("command");

            // get the person
            var person = _entities.Get<Person>()
                .EagerLoad(_entities, new Expression<Func<Person, object>>[]
                {
                    p => p.Affiliations,
                })
                .By(command.PersonId);

            // construct the affiliation
            var affiliation = new Affiliation
            {
                EstablishmentId = command.EstablishmentId,
                IsClaimingStudent = command.IsClaimingStudent,
                IsClaimingEmployee = command.IsClaimingEmployee,
                IsDefault = !person.Affiliations.Any(a => a.IsDefault),
            };
            person.Affiliations.Add(affiliation);

            // store
            _entities.Create(affiliation);
        }
    }

    public class CreateAffiliationValidator : AbstractValidator<CreateAffiliationCommand>
    {
        public CreateAffiliationValidator(IQueryEntities entities)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            Person person = null;
            Establishment establishment = null;

            var establishmentLoad = new Expression<Func<Establishment, object>>[]
            {
                e => e.Type.Category,
            };
            var personLoad = new Expression<Func<Person, object>>[]
            {
                p => p.Affiliations.Select(a => a.Establishment)
            };

            RuleFor(p => p.EstablishmentId)
                // establishment id must exist in database
                .Must(p => ValidateEstablishment.IdMatchesEntity(p, entities, establishmentLoad, out establishment))
                    .WithMessage(ValidateEstablishment.FailedBecauseIdMatchedNoEntity,
                        p => p.EstablishmentId)
            ;

            RuleFor(p => p.IsClaimingStudent)
                // cannot claim student unless affiliation establishment is an academic institution
                .Must(p => ValidateAffiliation.EstablishmentIsInstitutionWhenIsClaimingStudent(p, establishment))
                    .When(p => establishment != null)
                    .WithMessage(ValidateAffiliation.FailedBecauseIsClaimingStudentButEstablishmentIsNotInstitution,
                        p => p.EstablishmentId)
            ;

            RuleFor(p => p.PersonId)
                // person id must exist in database
                .Must(p => ValidatePerson.IdMatchesEntity(p, entities, personLoad, out person))
                    .WithMessage(ValidatePerson.FailedBecauseIdMatchedNoEntity,
                        p => p.PersonId)
                // cannot create a duplicate affiliation
                .Must((o, p) => ValidatePerson.IsNotAlreadyAffiliatedWithEstablishment(person, o.EstablishmentId))
                    .WithMessage(ValidatePerson.FailedBecausePersonIsAlreadyAffiliatedWithEstablishment,
                        p => p.PersonId, p => p.EstablishmentId)
            ;
        }
    }
}
