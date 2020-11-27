using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public List<links> Links { get; set; }

        public Cliente(String nome,String email)
        {
            this.Nome = nome;
            this.Email = email;
        }
        public Cliente()
        {

        }
        public void AddLink(List<links> link)
        {
            Links = link;
        }
    }
}
