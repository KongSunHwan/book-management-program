using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test03.book1
{
    class bookDTO
    {
        private string id;
        private string boname;

        public bookDTO(string id, string boname)
        {
            this.id = id;
            this.boname = boname;
            
        }

        public string Id
        {
            get
            {
                return id;
            }
        }
        public string Boname
        {
            get
            {
                return boname;
            }
        }


    }
}
