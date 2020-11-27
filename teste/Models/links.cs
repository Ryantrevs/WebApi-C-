using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
    public class links
    {
        public int id { get; set; }
        public String link { get; set; }
        public Cliente Cliente { get; set; }

        public links()
        {
        }

        public links(string link, Cliente cliente)
        {
            this.link = link;
            Cliente = cliente;
        }
    }

}
