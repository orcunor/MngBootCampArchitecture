using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; } // virtuala ORM araçları bakıyor bu keywordü arıyormuş.

        public Brand()
        {
            if (Models == null)
                Models = new HashSet<Model>(); // unique kendi içinde indeksleme de yapar o yüzden çok hızlı çalışır

        }

        public Brand(int id, string name) : this()
        {
            Id = id; // entity'den gelen Id
            Name = name;
        }



    }
}
