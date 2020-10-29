using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaAmigosClassLibrary.Models
{
    public class GerenciamentoCookie : IGerenciamentoCookie
    {
        private readonly HttpContextAccessor httpContextAccessor;

        public GerenciamentoCookie(HttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Create(string nome, string sobrenome, string email, string data)
        {
            Table table;

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(10);

            httpContextAccessor.HttpContext.Response.Cookies.Append("Nome", table.Nome, option);
            httpContextAccessor.HttpContext.Response.Cookies.Append("Sobrenome", table.Sobrenome, option);
            httpContextAccessor.HttpContext.Response.Cookies.Append("Email", table.Email, option);
            httpContextAccessor.HttpContext.Response.Cookies.Append("Data", table.DataNascimento.ToString("dd/MM/yyyy HH:mm:ss"), option);
        }

        public void Remove()
        {
            httpContextAccessor.HttpContext.Response.Cookies.Delete("Nome");
            httpContextAccessor.HttpContext.Response.Cookies.Delete("Sobrenome");
            httpContextAccessor.HttpContext.Response.Cookies.Delete("Email");
            httpContextAccessor.HttpContext.Response.Cookies.Delete("Data");
        }


    }
}
