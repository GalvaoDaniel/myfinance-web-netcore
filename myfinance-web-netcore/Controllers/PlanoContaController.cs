using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Infrastructure;
using AutoMapper;

namespace myfinance_web_netcore.Controllers;

public class PlanoContaController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILogger<PlanoContaController> _logger;
    private readonly MyFinanceDbContext _myFinanceDbContext;

    public PlanoContaController(
        ILogger<PlanoContaController> logger,
        MyFinanceDbContext myFinanceDbContext,
        IMapper mapper)
    {
        _logger = logger;
        _myFinanceDbContext = myFinanceDbContext;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var listaPlanoConta = _myFinanceDbContext.PlanoConta.ToList();
        var lista = _mapper.Map<IEnumerable<PlanoContaModel>>(listaPlanoConta);

        ViewBag.ListaPlanoConta = lista;
        return View();
    }

}
