using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagement.Business.ValidationRules.FluentValidation
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> StartsWithUpperCase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(name => !string.IsNullOrEmpty(name) && char.IsUpper(name[0])).WithMessage("İlk harf büyük olmalı");
        }

        public static IRuleBuilderOptions<T, string> NoSqlInjectionPatterns<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(value =>
                string.IsNullOrEmpty(value) ||
                !Regex.IsMatch(value, @"(\b(DROP|ALTER|INSERT|DELETE|UPDATE|SELECT|EXEC)\b|--|;|')",
                               RegexOptions.IgnoreCase))
            .WithMessage("Geçersiz veya tehlikeli giriş tespit edildi.");
        }

        public static IRuleBuilderOptions<T, string> NoHtmlTags<T>(
        this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(value =>
                    string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"<.*?>"))
                .WithMessage("HTML etiketlerine izin verilmiyor.");
        }

        public static IRuleBuilderOptions<T, string> OnlySafeCharacters<T>(
        this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(value =>
                    string.IsNullOrEmpty(value) || Regex.IsMatch(value, @"^[a-zA-Z0-9\s]+$"))
                .WithMessage("Sadece harf, rakam ve boşluk kullanılabilir.");
        }
    }
}
