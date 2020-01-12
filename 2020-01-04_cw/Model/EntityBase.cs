using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_01_04_cw.Model
{
    public class EntityBase
    {
        private static int id;
        public int Id { get; }
        public bool IsNew { get; set; }

        public EntityBase()
        {
            this.IsNew = true;
            this.Id = EntityBase.id++;
        }

        public void Save()
        {
            this.IsNew = false;
        }
    }
}
