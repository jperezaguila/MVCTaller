using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTaller.Models
{
	
        public partial class Usuario
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public string login { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public int rolId { get; set; }

            public virtual Rol Rol { get; set; }
        }
    }
