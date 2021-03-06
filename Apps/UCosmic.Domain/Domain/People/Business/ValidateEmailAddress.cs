﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;

namespace UCosmic.Domain.People
{
    public static class ValidateEmailAddress
    {
        #region Value cannot be empty

        public const string FailedBecauseValueWasEmpty =
            "Email value is required.";

        #endregion
        #region Value must be valid email address

        public const string FailedBecauseValueWasNotValidEmailAddress =
            "Email '{0}' is not a valid email address.";

        #endregion
        #region Value matches person entity

        public const string FailedBecauseValueMatchedNoPerson =
            "No person was found for the email address '{0}'.";

        public static bool ValueMatchesPerson(string value, IQueryEntities entities,
            IEnumerable<Expression<Func<Person, object>>> eagerLoad, out Person person)
        {
            if (entities == null)
            {
                person = null;
                return false;
            }

            person = entities.Query<Person>().EagerLoad(entities, eagerLoad).ByEmail(value);

            // return true (valid) if there is an entity
            return person != null;
        }

        public static bool ValueMatchesPerson(string value, IQueryEntities entities,
            IEnumerable<Expression<Func<Person, object>>> eagerLoad = null)
        {
            Person person;
            return ValueMatchesPerson(value, entities, eagerLoad, out person);
        }

        public static bool ValueMatchesPerson(string value, IQueryEntities entities, out Person person)
        {
            return ValueMatchesPerson(value, entities, null, out person);
        }

        #endregion
        #region Must be confirmed

        public const string FailedBecauseIsNotConfirmed =
            "Ownership of the email address '{0}' has not been confirmed.";

        public static bool IsConfirmed(EmailAddress entity)
        {
            // return true (valid) if the email is confirmed
            return entity != null && entity.IsConfirmed;
        }

        #endregion
        #region Number and Principal matches entity

        public const string FailedBecauseNumberAndPrincipalMatchedNoEntity =
            "Email with number '{0}' could not be found for user {1}.";

        public static bool NumberAndPrincipalMatchesEntity(int number, IPrincipal principal, IQueryEntities entities,
            out EmailAddress entity)
        {
            if (entities == null)
            {
                entity = null;
                return false;
            }

            entity = entities.Query<EmailAddress>().ByUserNameAndNumber(principal.Identity.Name, number);

            // return true (valid) if there is an entity
            return entity != null;
        }

        #endregion
        #region New value matches previous value case invariantly

        public const string FailedBecauseNewValueDidNotMatchCurrentValueCaseInvsensitively =
            "Email address '{0}' does not match previous spelling case insensitively.";

        public static bool NewValueMatchesCurrentValueCaseInsensitively(string newValue, EmailAddress email)
        {
            return email != null && email.Value.Equals(newValue, StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}
