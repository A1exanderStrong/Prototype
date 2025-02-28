using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;
using Prototype.Entities;
using Prototype.Properties;
using Prototype.Entities.Handbooks;

namespace Prototype
{
    public static class Connection
    {
        public const string host = "localhost";
        public const string database = "prototype";
        public const string usr = "root";
        public const string pwd = "root";
        public static string conString = $"host={host};uid={usr};pwd={pwd};database={database}";


        /// <summary>
        /// Проверяет возможность подключения к БД
        /// </summary>
        public static bool Test()
        {
            try
            {
                using (var con = new MySqlConnection(conString))
                {
                    con.Open();
                }
                return true;
            }
            catch {
                //throw; }
                return false; }
        }

        /// <summary>
        /// Проверяет наличие пользователя в БД. Необходимо предварительно проверить возможность подключения методом test()
        /// </summary>
        public static User Auth(string login, string password)
        {
            string sql = "SELECT * FROM `users` WHERE Login=@Login AND Password=@Password;";
            var user = new User();

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);
                try
                {
                    password = std.sha256(password);
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) { return null; }

                        while (reader.Read())
                        {
                            user.Id = reader.GetInt32("id");
                            user.Login = reader.GetString("login");
                            user.Email = reader.GetString("email");
                            user.Name = reader.GetString("name");
                            user.RoleId = reader.GetInt32("role");
                            user.RegistrationDate = reader.GetDateTime("registration_date");
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            return user;
        }

        public static User GetUser(int id)
        {
            using(var con = new MySqlConnection(conString))
            {
                con.Open();
                var user = new User();
                string sql = $"SELECT * FROM `users` WHERE id={id}";
                var cmd = new MySqlCommand(sql, con);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    reader.Read();
                    return new User
                    {
                        Id = reader.GetInt32("id"),
                        Login = reader.GetString("login"),
                        Email = reader.GetString("email"),
                        Name = reader.GetString("name"),
                        RoleId = reader.GetInt32("role"),
                        RegistrationDate = reader.GetDateTime("registration_date")
                    };
                }
            }
        }

        public async static Task<List<User>> GetUsers(string name = "", int role = 0, string sort = "", int limit = -1, int offset = -1, bool sort_reverse = false)
        {
            string select = $"SELECT * FROM `users`";
            string _search = $"WHERE `login` LIKE '%{name}%'";
            string _role01 = $"AND `role`={role}";
            string _role02 = $"WHERE `role`={role}";
            string _sort = $"ORDER BY {sort}";
            string _limit = $"LIMIT {limit}";
            string _offset = $"OFFSET {offset}";

            string sql = select;

            bool name_not_empty = !name.Equals(string.Empty);
            bool sort_not_empty = !sort.Equals(string.Empty);

            if (name_not_empty) sql += $" {_search}";

            if (name_not_empty && role != 0) sql += $" {_role01}";
            else if (role != 0) sql += $" {_role02}";

            if (sort_not_empty && sort_reverse) sql += $" {_sort} DESC";
            else if (sort_not_empty) sql += $" {_sort}";

            if (limit != -1) sql += $" {_limit}";
            if (offset != -1) sql += $" {_offset}";

            var users = new List<User>();
            using (var con = new MySqlConnection(conString))
            {
                con.Open();

                var cmd = new MySqlCommand(sql, con);
                await Task.Run(() =>
                {
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = reader.GetInt32("id"),
                                Login = reader.GetString("login"),
                                Email = reader.GetString("email"),
                                Name = reader.GetString("name"),
                                RoleId = reader.GetInt32("role"),
                                RegistrationDate = reader.GetDateTime("registration_date")
                            });
                        }
                });
            }
            return users;
        } 
        
        /// <summary>
        /// Параметры поиска ресурсов.
        /// Необходимо предварительно проверить возможность подключения методом test()
        /// </summary>
        /// <param name="name">Поиск по имени / названию ресурса</param>
        /// <param name="sort">Сортировка по ...</param>
        /// <param name="limit">Количество ресурсов, на странице</param>
        /// <param name="offset">Количество пропускаемых ресурсов</param>
        /// <returns></returns>
        public static List<Resource> SearchResources(string name = "", string category = "", string sort = "", int limit = -1, int offset = -1, bool reverse_sort = false)
        {
            string select = $"SELECT * FROM `resources`";
            string _search = $"WHERE `name` LIKE '{name}%'";
            string _category01 = $"AND `category`={category}";
            string _category02 = $"WHERE `category`={category}";
            string _sort = $"ORDER BY {sort}";
            string _limit = $"LIMIT {limit}";
            string _offset = $"OFFSET {offset}";

            string sql = select;

            bool name_not_empty = !name.Equals(string.Empty);
            bool category_not_empty = !category.Equals(string.Empty);
            bool sort_not_empty = !sort.Equals(string.Empty);

            if (name_not_empty)                         sql += $" {_search}";

            if (name_not_empty && category_not_empty)     sql += $" {_category01}";
            else if (category_not_empty)                  sql += $" {_category02}";

            if (sort_not_empty && reverse_sort)         sql += $" {_sort} DESC";
            else if (sort_not_empty)                    sql += $" {_sort}";

            if (limit != -1)                            sql += $" {_limit}";
            if (offset != -1)                           sql += $" {_offset}";

            // string sql = $"{select} {_search} {_category} {_sort} {limits};";
            List<Resource> resources = new List<Resource>();

            using (var con = new MySqlConnection(conString)) 
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                        var resource = new Resource
                        {
                            Name = reader.GetString("name"),
                            Description = reader.GetString("description"),
                            CategoryId = reader.GetInt32("category"),
                            Price = reader.GetFloat("price"),
                            PublicationDate = reader.GetDateTime("publication_date"),
                            CreatedByUserId = reader.GetInt32("created_by"),
                            Picture = std.GetWebImage(reader.GetString("picture"))
                        };

                        resources.Add(resource);
                }
            }
            return resources;
        }

        public async static Task<List<Resource>> SearchResourcesAsync(string name = "", string category = "", string sort = "", int limit = -1, int offset = -1, bool reverse_sort = false)
        {
            string select = $"SELECT * FROM `resources`";
            string _search = $"WHERE `name` LIKE '%{name}%'";
            string _category01 = $"AND `category`={category}";
            string _category02 = $"WHERE `category`={category}";
            string _sort = $"ORDER BY {sort}";
            string _limit = $"LIMIT {limit}";
            string _offset = $"OFFSET {offset}";

            string sql = select;

            bool name_not_empty = !name.Equals(string.Empty);
            bool category_not_empty = !category.Equals(string.Empty);
            bool sort_not_empty = !sort.Equals(string.Empty);

            if (name_not_empty) sql += $" {_search}";

            if (name_not_empty && category_not_empty) sql += $" {_category01}";
            else if (category_not_empty) sql += $" {_category02}";

            if (sort_not_empty && reverse_sort) sql += $" {_sort} DESC";
            else if (sort_not_empty) sql += $" {_sort}";

            if (limit != -1) sql += $" {_limit}";
            if (offset != -1) sql += $" {_offset}";

            // string sql = $"{select} {_search} {_category} {_sort} {limits};";
            List<Resource> resources = new List<Resource>();

            using (var con = new MySqlConnection(conString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var resource = new Resource
                        {
                            Name = reader.GetString("name"),
                            Description = reader.GetString("description"),
                            CategoryId = reader.GetInt32("category"),
                            Price = reader.GetFloat("price"),
                            PublicationDate = reader.GetDateTime("publication_date"),
                            CreatedByUserId = reader.GetInt32("created_by"),
                            Picture = await std.GetWebImageAsync(reader.GetString("picture"))
                        };

                        resources.Add(resource);
                    }
            }
            return resources;
        }

        public static long GetRecordsCount(string table)
        {
            using (var con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = $"SELECT COUNT(*) FROM {table}";

                var cmd = new MySqlCommand(sql, con);
                return cmd.ExecuteNonQuery();
            }
        }

        public static List<Category> GetCategories()
        {
            var categories = new List<Category>();
            using (var con = new MySqlConnection(conString))
            {
                con.Open();

                string sql = "SELECT * FROM `categories`";
                var cmd = new MySqlCommand(sql, con);
                using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                        var category = new Category
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name")
                        };

                    categories.Add(category);
                }
            }
            return categories;
        }

        public static List<Role> GetRoles()
        {
            var roles = new List<Role>();
            using (var con = new MySqlConnection(conString))
            {
                con.Open();

                string sql = "SELECT * FROM `roles`";
                var cmd = new MySqlCommand(sql, con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name")
                        });
                    }
            }
            return roles;
        }


        /// <summary>
        /// Получает наименования из указанного в параметре справочника. Справочник - таблица содержащая только id и name
        /// </summary>
        /// <param name="handbook"></param>
        /// <returns></returns>
        public static List<Handbook> GetHandbookData(string handbook)
        {
            List<Handbook> data = new List<Handbook>();
            using (var con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = $"SELECT * FROM {handbook}";
                var cmd = new MySqlCommand(sql, con);
                using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    {
                        data.Add(new Handbook
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name")
                        });
                    }
            }
            return data;
        }

        /// <summary>
        /// Создаёт в базе данных запись из объекта справочника.
        /// </summary>
        /// <param name="handbook"></param>
        public static void CreateHandbookItem(string handbook, Handbook item)
        {
            using (var con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = $"INSERT INTO {handbook} (name) VALUES (@Name)";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("Name", item.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateHandbookItem(string handbook, Handbook item)
        {
            using (var con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = $"UPDATE {handbook} SET name=@Name";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("Name", item.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public async static Task<List<Resource>> GetOwningResources(int user_id)
        {
            List<Resource> resources = new List<Resource>(); 
            using (var con = new MySqlConnection(conString))
            {
                con.Open();
                // IDEA: use innerjoin somwhere here
                string sql = $"SELECT * FROM `resources_owners` WHERE `user_id`={user_id}";
                var cmd = new MySqlCommand(sql, con); // получаем id всех ресурсов, которыми владеет пользователь
                await Task.Run(() =>
                {
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            int resource_id = reader.GetInt32("resource_id");
                            string sql2 = $"SELECT * FROM `resources` WHERE id={resource_id}";
                            var cmd2 = new MySqlCommand(sql2, con); // получаем подробную инфу о ресурсе
                            var reader2 = cmd2.ExecuteReader();
                            reader2.Read();
                            var resImageUrl = reader.GetString("picture");
                            resources.Add(new Resource
                            {
                                Id = resource_id,
                                Name = reader2.GetString("name"),
                                Description = reader2.GetString("description"),
                                Picture = std.GetWebImage(resImageUrl),
                                Price = reader2.GetFloat("price"),
                                CategoryId = reader2.GetInt32("category"),
                                CreatedByUserId = reader2.GetInt32("created_by"),
                                PublicationDate = reader2.GetDateTime("publication_date")
                            });
                            reader2.Close();
                        }
                });
            }
            return resources;
        }
    }
}