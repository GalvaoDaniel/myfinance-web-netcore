using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Models
{
    public class TransacaoModel
    {
        public int Id { get; set; }
        public string? Historico { get; set; }
        
        [Required(ErrorMessage = "Imforme a data da Transação!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Informe o valor da Transação!")]
        [Range(0.01, 999999.9, ErrorMessage = "O valor da Transação tem que ser maior que zero e menor que 999999.9")]
        public decimal Valor { get; set; }
        public int? PlanoContaId { get; set; }
        public PlanoContaModel? ItemPlanoConta { get; set; }
        public IEnumerable<SelectListItem>? PlanoContas { get; set; }
    }
}