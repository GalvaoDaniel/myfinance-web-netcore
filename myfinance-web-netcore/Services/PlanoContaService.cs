using AutoMapper;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {

        private readonly IMapper _mapper;

        private readonly MyFinanceDbContext _myFinanceDbContext;

        public PlanoContaService(
            MyFinanceDbContext myFinanceDbContext,
            IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public void Excluir(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();
            _myFinanceDbContext.Attach(item);
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public List<PlanoContaModel> ListarRegistros()
        {
            var listaPlanoConta = _myFinanceDbContext.PlanoConta.ToList();
            var lista = _mapper.Map<List<PlanoContaModel>>(listaPlanoConta);
            return lista;
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(PlanoContaModel model)
        {
            throw new NotImplementedException();
        }
    }
}