using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ListaAmigosClassLibrary.Models
{
    public class SelectContext
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ListaAmigosContext _context;
        public SelectContext(ListaAmigosContext context, IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
            this._context = context;
        }

        private int? GetId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetId(int Id)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", _);
        }
    }
}
