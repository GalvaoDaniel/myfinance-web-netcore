namespace myfinance_web_netcore.Domain
{
    public class Transacao
    {
        private int Id { get; set; }
        private string? Historico { get; set; }
        private DateTime Data { get; set; }
        private decimal Valor { get; set; }
        private int PlanoContaId { get; set; }
        private PlanoConta PlanoConta { get; set; }
    }
}