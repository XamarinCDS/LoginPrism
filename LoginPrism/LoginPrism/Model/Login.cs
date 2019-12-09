using System;
using System.Collections.Generic;
using System.Text;

namespace LoginPrism.Model
{
    public class Login:Interface1
    {
        public int id_usuario { get; set; }

        public string usu { get; set; }

        public string passw { get; set; }

        public string nombre { get; set; }

        public string telefono { get; set; }
    }
}
