using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Entities
{
    public partial class User : Entity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public DateTime RegistrationDate { get; set; }

        // первый элемент пустой, потому что индексы ролей в бд начинаются с 1
        readonly private static string[] databaseRoles = { "", "Администратор", "Менеджер", "Пользователь" };

        public const byte ADMIN = 1;
        public const byte MANAGER = 2;
        public const byte USER = 3;

        public static string GetRole(int role_id) => databaseRoles[role_id];
        public string GetRole() => databaseRoles[RoleId];

        public string GetRegistrationDate()
        {
            string regDate = "";
            if (RegistrationDate.Day < 10) regDate += "0";
            regDate += $"{RegistrationDate.Day}.";
            if (RegistrationDate.Month < 10) regDate += "0";
            regDate += $"{RegistrationDate.Month}.{RegistrationDate.Year}";
            return regDate;
        }
    }
}
