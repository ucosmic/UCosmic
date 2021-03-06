﻿using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using UCosmic.Domain.Identity;

namespace UCosmic.Www.Mvc.Areas.Identity.Models
{
    public class SignUpForm : IModelSigningEmail
    {
        public SignUpForm(HttpContextBase httpContext, TempDataDictionary tempData, string returnUrl)
        {
            var cookieValue = httpContext.SigningEmailAddressCookie();
            EmailAddress = cookieValue ?? tempData.SigningEmailAddress();
            ReturnUrl = returnUrl;
        }

        public SignUpForm() { }

        [DataType(DataType.EmailAddress)]
        [UIHint(SignOnForm.EmailAddressUiHint)]
        [Display(Name = SignOnForm.EmailAddressDisplayName, Prompt = SignOnForm.EmailAddressDisplayPrompt)]
        public string EmailAddress { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }

        [Display(Name = "Email me a confirmation code at the address above.")]
        public bool AcceptTerms { get; set; }

        public bool RememberMe { get { return false; } }
    }

    public static class SignUpProfiler
    {
        public class ModelToCommandProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<SignUpForm, SendCreatePasswordMessageCommand>()
                    .ForMember(d => d.SendFromUrl, o => o.Ignore())
                    .ForMember(d => d.ConfirmationToken, o => o.Ignore())
                ;
            }
        }
    }
}