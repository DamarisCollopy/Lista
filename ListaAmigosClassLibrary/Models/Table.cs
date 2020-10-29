using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListaAmigosClassLibrary.Models
{
    public partial class Table
    {
        public string Name;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
