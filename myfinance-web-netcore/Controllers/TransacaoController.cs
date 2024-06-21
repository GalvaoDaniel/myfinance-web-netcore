using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Infrastructure;
using AutoMapper;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;

[Route("[controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;
    private readonly ITransacaoService _transacaoService;

    public TransacaoController(
        ILogger<TransacaoController> logger,
        ITransacaoService transacaoService)
    {
        _logger = logger;
        _transacaoService = transacaoService;
    }

    public IActionResult Index()
    {
        var lista = _transacaoService.ListarRegistros();
        ViewBag.ListaTransacao = lista;
        return View();
    }

    [HttpPost]
    [Route("Cadastrar")]
    [Route("Cadastrar/{id}")]
    public IActionResult Cadastrar(TransacaoModel model, int? id) 
    {
        if (ModelState.IsValid) 
        {
            _transacaoService.Salvar(model);
        }
            
        return View();
    }

    [HttpGet]
    [Route("Cadastrar")]
    [Route("Cadastrar/{id}")]
    public IActionResult Cadastrar(int? id) 
    {
        if (id != null)
        {
            var registro = _transacaoService.RetornarRegistro((int)id);
            return View(registro);
        } 
        return View();
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _transacaoService.Excluir(id);
        return RedirectToAction("Index");
    }

}
