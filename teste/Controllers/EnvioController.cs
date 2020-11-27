using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using teste.Data;
using teste.Models;
using teste.Services;

namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EnvioController : ControllerBase
    {
        private readonly ILogger<EnvioController> _logger;
        private readonly EnvioContext context;

        public EnvioController(ILogger<EnvioController> logger, EnvioContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet]
        [ActionName("")]
        public IEnumerable<Cliente> Get()
        {
            var clientes = context.clientes.Where(opt => opt.Nome != null).ToList();
            return clientes;
        }

        [HttpGet]
        [ActionName("set")]
        public Cliente Setar()
        {
            Console.WriteLine("entrou");
            Cliente cliente = new Cliente
            {
                Nome = "Patrick",
                Email = "patrick.campos55@gmail.com"
            };
            context.clientes.Add(cliente);
            context.SaveChanges();
            var patrick = context.clientes.Where(opt => opt.Nome == "Patrick").FirstOrDefault();
            return patrick;
        }

        [HttpPost]
        [ActionName("cliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ContentResult> EnviarTrabalho([FromBody] payload json)
        {

             Cliente cliente = new Cliente(json.cliente.Nome, json.cliente.Email);
            List<links> linkes = new List<links>();
            
            foreach(var item in json.cliente.Links)
            {
                links link = new links(item.link, cliente);
                linkes.Add(item); ;
            };
            cliente.AddLink(linkes);
            await context.clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
            MailService servicoEmail = new MailService();
            var response = await servicoEmail.EnviarEmail(cliente.Nome, cliente.Email, linkes);
            return Content(response.Body.ToString());
        }
    }
}
