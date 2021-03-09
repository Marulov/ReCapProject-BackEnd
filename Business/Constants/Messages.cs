using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductNameInValid = "Ürün ismi geçersiz";
        public static string ProductAdded = "Ürün eklendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string CarNotHere = "Arabanın teslim adresini girmelisiniz";
        public static string FailAddedImageLimit = "Bir arabanın en fazla 5 resmi olabilir!";
        public static string AuthorizationDenied = "Yetkiniz yok!";
    }
}
