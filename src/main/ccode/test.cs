
using System.Collections.Generic;
using BCP.Clients.Models.Business;
using BCP.Clients.Validation;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace BCP.Clients.Tests.Validators
{
    public class PhoneValidatorTests
    {
        private readonly AccountPhoneValidator _validator;

        public PhoneValidatorTests()
        {
            _validator = new AccountPhoneValidator();
        }

        public static IEnumerable<object[]> ValidDataFactory()
        {
            yield return new object[]
            {
                new Phone
                {
                    Label = "Business",
                    IsDefault = true,
                    AcceptsTextMessages = true,
                    CountryCode = "1",
                    PhoneNumber = "0123456789",
                },
            };
            yield return new object[]
            {
                new Phone
                {
                    Label = "Business",
                    IsDefault = true,
                    AcceptsTextMessages = true,
                    CountryCode = "1",
                    PhoneNumber = "(012)-34.56789",
                },
            };
            yield return new object[]
            {
                new Phone
                {
                    Label = "Business",
                    IsDefault = true,
                    AcceptsTextMessages = true,
                    CountryCode = "93",
                    PhoneNumber = "123456789",
                },
            };
            yield return new object[]
            {
                new Phone
                {
                    Label = "Business",
                    IsDefault = true,
                    AcceptsTextMessages = true,
                    CountryCode = "93",
                    PhoneNumber = "(12)-34.56789",
                },
            };
            yield return new object[]
            {
                new Phone
                {
                    Label = "Business",
                    IsDefault = true,
                    AcceptsTextMessages = true,
                    CountryCode = "93",
                    PhoneNumber = "123456789.190-29",
                },
            };
            yield return new object[]
            {
                new Phone
                {
                    Label = "Business",
                    IsDefault = true,
                    AcceptsTextMessages = true,
                    CountryCode = "93",
                    PhoneNumber = "(12)-34.56789-3.4-.5-1",
                },
            };
        }

        [Theory]
        [MemberData(nameof(ValidDataFactory))]
        public void ValidatorDoesNotDefineErrorsForValidModel(Phone phone)
        {
            var result = _validator.TestValidate(phone);
            result.IsValid.Should().BeTrue();
        }
    }
}
