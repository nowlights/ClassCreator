using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Entities
{
    public class Table
    {
        public string Guid { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Somente letras e numeros são permitidos")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(3, ErrorMessage = "Minimo de 3 caracteres")]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public List<Props> Entities { get; set; }
    }
}