using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Entities
{
    public class Projeto
    {

        public string Guid { get; set; }
        public enum language
        {
            CSharp,
            VB_NET
        }

        [RegularExpression(@"^[a-zà-úA-ZÀ-Ú0-9\._\,\-\s]*$", ErrorMessage = "Somente letras, numeros, pontos, virgulas e traços são permitidos")]
        [MinLength(3, ErrorMessage = "Minimo de 3 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }


        [RegularExpression(@"^[a-zà-úA-ZÀ-Ú0-9_]*$", ErrorMessage = "Somente letras, numeros e underlines são permitidos")]
        [MinLength(2, ErrorMessage = "Minimo de 2 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NameDataBase { get; set; }
        public DateTime Date { get; set; }
        public List<Table> Tables { get; set; }

        [RegularExpression(@"^[a-zà-úA-ZÀ-Ú0-9\._\,\-\s]*$", ErrorMessage = "Somente letras, numeros, pontos, virgulas e traços são permitidos")]
        [Required(ErrorMessage = "Selecione uma opção")]
        public string Language { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [MinLength(4, ErrorMessage = "Minimo de 4 caracteres")]
        public string UsingStyleConnection { get; set; }

    }
}