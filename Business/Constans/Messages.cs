using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
   public static class Messages
    {
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";

        public static string UnitPrice = "Lütfen günlük fiyatı 0'dan büyük giriniz.";
        public static string NameValid = "İsim uzunluğu 1 karakterden fazla olamalıdır.";
        public static string GetAll = "Ürünler Listelendi";
        public static string Password = "Parolanız en az 8 karakter olmalıdır.";
        public static string RentalAddedError = "Bu araç şu an kullanımda olduğu için kiralanamaz";
        public static string RentalAddedSuccess = "araç başarıyla kiralandı";
        public static string AddCarImageMessage;
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError="Şifre yanlış";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
        internal static string AuthorizationDenied = "Yetkiniz yok";
        
    }
}
