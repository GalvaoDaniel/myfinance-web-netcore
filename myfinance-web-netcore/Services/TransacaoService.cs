using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
     public class TransacaoService : ITransacaoService
    {

        private readonly IMapper _mapper;

        private readonly MyFinanceDbContext _myFinanceDbContext;

        public TransacaoService(
            MyFinanceDbContext myFinanceDbContext,
            IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public void Excluir(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First();
            _myFinanceDbContext.Attach(item);
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }

        public List<TransacaoModel> ListarRegistros()
        {
            var listaTransacao = _myFinanceDbContext.Transacao.Include(x => x.PlanoConta).ToList();
            var lista = _mapper.Map<List<TransacaoModel>>(listaTransacao);
            return lista;
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First();
            var registro = _mapper.Map<TransacaoModel>(item);
            return registro;
        }

        public void Salvar(TransacaoModel model)
        {
            model.Data = SetKindUtc(model.Data);
            var dbSet = _myFinanceDbContext.Transacao;
            var item = _mapper.Map<Transacao>(model);

            if (item.Id == 0)
            {
                dbSet.Add(item);
            }
            else
            {
                dbSet.Attach(item);
                _myFinanceDbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
        }

        public DateTime SetKindUtc(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc) 
            { 
                return dateTime; 
            }
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
    }
}