using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Prototype.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Image Picture { get; set; }
        public double Price { get; set; }
        // id пользователя, создавшего запрос на публикацию ресурса
        public int CreatedByUserId { get; set; } 
        public DateTime PublicationDate { get; set; }

        public string GetCategoryName()
        {
            var categories = Connection.GetCategories();
            foreach (var category in categories) 
                if (category.Id == CategoryId) return category.Name;

            return string.Empty;
        }

        public User GetAuthor() => Connection.GetUser(CreatedByUserId);
    }
}
