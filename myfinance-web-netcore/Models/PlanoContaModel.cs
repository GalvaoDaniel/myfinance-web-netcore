using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição do item de Plano de Conta!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o tipo do item de Plano de Conta!")]
        public string Tipo { get; set; }
    }
}