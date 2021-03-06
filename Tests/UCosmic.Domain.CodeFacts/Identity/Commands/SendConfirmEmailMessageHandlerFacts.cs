﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Should;
using UCosmic.Domain.Establishments;
using UCosmic.Domain.People;

namespace UCosmic.Domain.Identity
{
    public static class SendConfirmEmailMessageHandlerFacts
    {
        [TestClass]
        public class TheHandleMethod
        {
            [TestMethod]
            public void ThrowsArgumentNullException_WhenCommandArgIsNull()
            {
                var handler = new SendConfirmEmailMessageHandler(null, null, null);
                ArgumentNullException exception = null;
                try
                {
                    handler.Handle(null);
                }
                catch (ArgumentNullException ex)
                {
                    exception = ex;
                }

                exception.ShouldNotBeNull();
                // ReSharper disable PossibleNullReferenceException
                exception.ParamName.ShouldEqual("command");
                // ReSharper restore PossibleNullReferenceException
            }

            [TestMethod]
            public void ExecutesQuery_ForPerson()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.ResetPassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                scenarioOptions.Entities.Verify(m => m.Get<Person>(),
                    Times.Once());
            }

            [TestMethod]
            public void GeneratesSecretCode_WithTwelveCharacters()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.ResetPassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                scenarioOptions.OutConfirmation.SecretCode.Length.ShouldEqual(12);
            }

            [TestMethod]
            public void CreatesConfrimation_With_EmailAddres_Intent_AndSecretCode()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.CreatePassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                scenarioOptions.Entities.Verify(m => m.
                    Create(It.Is(ConfirmationEntityBasedOn(scenarioOptions))),
                    Times.Once());
                scenarioOptions.OutConfirmation.EmailAddress.ShouldEqual(scenarioOptions.Person.GetEmail(emailAddress));
                scenarioOptions.OutConfirmation.Intent.ShouldEqual(command.Intent);
            }

            [TestMethod]
            public void SetsCommandProperty_ConfirmationToken()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.CreatePassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                command.ConfirmationToken.ShouldEqual(scenarioOptions.OutConfirmation.Token);
            }

            [TestMethod]
            public void ExecutesQuery_ForEmailTemplate()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.CreatePassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                scenarioOptions.QueryProcessor.Verify(m => m.
                    Execute(It.Is(EmailTemplateQueryBasedOn(command))),
                    Times.Once());
            }

            [TestMethod]
            public void ExecutesQuery_ForEmailFormatters()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.CreatePassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                scenarioOptions.QueryProcessor.Verify(m => m.
                    Execute(It.Is(FormattersQueryBasedOn(scenarioOptions))),
                    Times.Once());
            }

            [TestMethod]
            public void ExecutesQuery_ToComposeEmailMessage()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.CreatePassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                scenarioOptions.QueryProcessor.Verify(m => m.
                    Execute(It.Is(CompositionQueryBasedOn(scenarioOptions))),
                    Times.Once());
            }

            [TestMethod]
            public void CreatesEmailMessage()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.CreatePassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                scenarioOptions.Entities.Verify(m => m.
                    Create(It.Is(MessageEntityBasedOn(scenarioOptions))),
                    Times.Once());
            }

            [TestMethod]
            public void InvokesNestedHandler()
            {
                const string emailAddress = "someone";
                var command = new SendConfirmEmailMessageCommand
                {
                    EmailAddress = emailAddress,
                    Intent = EmailConfirmationIntent.ResetPassword,
                    SendFromUrl = "test",
                };
                var scenarioOptions = new ScenarioOptions(command);
                var handler = CreateHandler(scenarioOptions);

                handler.Handle(command);

                scenarioOptions.NestedHandler.Verify(m => m.
                    Handle(It.Is(NestedCommandBasedOn(scenarioOptions))),
                    Times.Once());
            }
        }

        private class ScenarioOptions
        {
            internal ScenarioOptions(SendConfirmEmailMessageCommand command)
            {
                Command = command;
                Person = new Person
                {
                    RevisionId = 6,
                    Emails = new[]
                    {
                        new EmailAddress
                        {
                            Value = command.EmailAddress,
                        },
                    },
                };
                EmailMessage = new EmailMessage
                {
                    ToPerson = Person,
                    Number = 7,
                };
                EmailTemplate = new EmailTemplate();
            }
            internal SendConfirmEmailMessageCommand Command { get; private set; }
            internal Person Person { get; private set; }
            internal EmailTemplate EmailTemplate { get; private set; }
            internal EmailMessage EmailMessage { get; private set; }
            internal EmailConfirmation OutConfirmation { get; set; }
            internal Mock<IProcessQueries> QueryProcessor { get; set; }
            internal Mock<ICommandEntities> Entities { get; set; }
            internal Mock<IHandleCommands<SendEmailMessageCommand>> NestedHandler { get; set; }
        }

        private static SendConfirmEmailMessageHandler CreateHandler(ScenarioOptions scenarioOptions)
        {
            var queryProcessor = new Mock<IProcessQueries>(MockBehavior.Strict);
            scenarioOptions.QueryProcessor = queryProcessor;
            queryProcessor.Setup(m => m
                .Execute(It.Is(EmailTemplateQueryBasedOn(scenarioOptions.Command))))
                .Returns(scenarioOptions.EmailTemplate);
            queryProcessor.Setup(m => m
                .Execute(It.Is(FormattersQueryBasedOn(scenarioOptions))))
                .Returns(null as IDictionary<string, string>);
            queryProcessor.Setup(m => m
                .Execute(It.Is(CompositionQueryBasedOn(scenarioOptions))))
                .Returns(scenarioOptions.EmailMessage);

            var entities = new Mock<ICommandEntities>(MockBehavior.Strict).Initialize();
            scenarioOptions.Entities = entities;
            entities.Setup(m => m.Get<Person>()).Returns(new[] { scenarioOptions.Person }.AsQueryable);
            entities.Setup(m => m.Create(It.Is(ConfirmationEntityBasedOn(scenarioOptions))))
                .Callback((Entity entity) => scenarioOptions.OutConfirmation = (EmailConfirmation)entity);
            entities.Setup(m => m.Create(It.Is(MessageEntityBasedOn(scenarioOptions))));

            var nestedHandler = new Mock<IHandleCommands<SendEmailMessageCommand>>(MockBehavior.Strict);
            scenarioOptions.NestedHandler = nestedHandler;
            nestedHandler.Setup(m => m.Handle(It.Is(NestedCommandBasedOn(scenarioOptions))));

            return new SendConfirmEmailMessageHandler(queryProcessor.Object, entities.Object, nestedHandler.Object);
        }

        private static Expression<Func<GetEmailTemplateByNameQuery, bool>> EmailTemplateQueryBasedOn(SendConfirmEmailMessageCommand command)
        {
            return q => q.Name == command.TemplateName.AsSentenceFragment();
        }

        private static Expression<Func<GetConfirmEmailFormattersQuery, bool>> FormattersQueryBasedOn(ScenarioOptions scenarioOptions)
        {
            return e =>
                e.Confirmation.EmailAddress == scenarioOptions.Person.GetEmail(scenarioOptions.Command.EmailAddress) &&
                e.Confirmation.Intent == scenarioOptions.Command.Intent
            ;
        }

        private static Expression<Func<ComposeEmailMessageQuery, bool>> CompositionQueryBasedOn(ScenarioOptions scenarioOptions)
        {
            return q =>
                   q.Template == scenarioOptions.EmailTemplate &&
                   q.ToEmailAddress == scenarioOptions.Person.GetEmail(scenarioOptions.Command.EmailAddress)
            ;
        }

        private static Expression<Func<EmailConfirmation, bool>> ConfirmationEntityBasedOn(ScenarioOptions scenarioOptions)
        {
            return e =>
                e.EmailAddress == scenarioOptions.Person.GetEmail(scenarioOptions.Command.EmailAddress) &&
                e.Intent == scenarioOptions.Command.Intent
            ;
        }

        private static Expression<Func<EmailMessage, bool>> MessageEntityBasedOn(ScenarioOptions scenarioOptions)
        {
            return e => e == scenarioOptions.EmailMessage;
        }

        private static Expression<Func<SendEmailMessageCommand, bool>> NestedCommandBasedOn(ScenarioOptions scenarioOptions)
        {
            return c =>
                c.PersonId == scenarioOptions.EmailMessage.ToPerson.RevisionId &&
                c.MessageNumber == scenarioOptions.EmailMessage.Number
            ;
        }
    }
}
