using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constanst
{
    public static class Messages
    {
        public static readonly string RoomUpdated;
        public static string RoomAdded = "Oda eklendi";
        public static string RoomNameInvalid = "Ürün ismi geçersiz";

        public static string LocationAdded = "Bina eklendi";
        public static string LocationNameInvalid = "Ürün ismi geçersiz";

        public static string StafftitleAdded = "Unvan eklendi";
        public static string StafftitleNameInvalid = "Ürün ismi geçersiz";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string RoomsListed = "Odalar listelendi";



        public static string LocationAlreadyExists = "Bu isimde zaten bina var";

        public static string AuthorizationDenied = "Yetkin yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string AccessTokenCreated = "Token yaratıldı";

        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string RoomNameAlreadyExists = "Bu oda zaten var";
        public static string ThisRoomisNotFound = "Bu oda bulunamadı";
        public static string RoomIsDeleted = "Oda silindi";
        public static string RoomIsUpdated = "Oda güncellendi";
        public static string RoomNotFound= "Oda yok";
        public static List<Room> RoomsWithEquipmentNotFound;
        public static string RoomsWithEquipmentListed = "Ekipmana göre oda listelendi";
        public static List<LocationToRoom> LocationToRoomsNotFound;
        public static string LocationToRoomsListed ="Binadaki odalar listelendi";
        public static string LocationsListed;
        public static string LocationUpdated;
        public static string LocationNotFound;
        public static string StafftiltleNameInvalid;
        public static string StafftitlesListed;
        public static string ThisStaftitleisNotFound;
        public static string StafftitleIsDeleted;
        public static string StafftitleNotFound;
        public static string GendersListed;
        public static string EquipmentAdded;
        public static string EquipmentNameInvalid;
        public static string ThisEquipmentisNotFound;
        public static string EquipmentIsDeleted;
        public static string EquipmentNotFound;
        public static string EquipmentUpdated;
        public static string RolesListed;
        public static string RolesByIdListed;
        public static string ThisUserisNotFound;
        public static string UserIsDeleted;
        public static string ThisUserİsFound;
        public static string UserAdded;
        public static string AllUsersListed;
        public static string ThisUserİsNotFound;
        public static string UserIsUpdated;

        public static string StafftitleUpdated;
        public static string Randevular;
    }
}

