using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test03.user
{
    class UserDTO
    {
        private string id;
        private string pw;
        private string name;
        private string age;
        private string phone;

        public UserDTO(string id, string pw, string name, string age, string phone)
        {
            this.id = id;
            this.pw = pw;
            this.name = name;
            this.age = age;
            this.phone = phone;
        }

        public string Id
        {
            get {
                return id;
            }
        }

        public string Pw
        {
            get
            {
                return pw;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
        }

        public string Age
        {
            get
            {
                return age;
            }
        }
    }
}
