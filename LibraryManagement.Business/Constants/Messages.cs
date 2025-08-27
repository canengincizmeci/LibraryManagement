using LibraryManagement.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.Constants
{
    public static class Messages
    {
        public static string AccessTokenCreated = "Token Başarıyla oluşturuldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifra Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserRegistered = "Kullanıcı Kayıt oldu";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string BookAdded = "Kitap Eklendi";
        public static string BookNotAdded = "Kitap Eklenemedi";
    }
}
