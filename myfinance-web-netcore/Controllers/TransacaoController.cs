using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Infrastructure;
using AutoMapper;
using myfinance_web_netcore.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace myfinance_web_netcore.Controllers;

[Route("[controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;
    private readonly ITransacaoService _transacaoService;
    private readonly IPlanoContaService _planoContaService;

    public TransacaoController(
        ILogger<TransacaoController> logger,
        ITransacaoService transacaoService,
        IPlanoContaService planoContaService)
    {
        _logger = logger;
        _transacaoService = transacaoService;
        _planoContaService = planoContaService;
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
            return RedirectToAction("Cadastrar");
        }
        else
        {
            var listaPlanoConta = _planoContaService.ListarRegistros();
            var selectListPlanoContas = new SelectList(listaPlanoConta, "Id", "Descricao");
            model.PlanoContas = selectListPlanoContas;
            return View(model);
        }
    }

    [HttpGet]
    [Route("Cadastrar")]
    [Route("Cadastrar/{id}")]
    public IActionResult Cadastrar(int? id) 
    {
        var listaPlanoConta = _planoContaService.ListarRegistros();
        var selectListPlanoContas = new SelectList(listaPlanoConta, "Id", "Descricao");

        if (id != null)
        {
            var registro = _transacaoService.RetornarRegistro((int)id);
            registro.PlanoContas = selectListPlanoContas;
            return View(registro);
        }
        else
        {
            var model = new TransacaoModel();
            model.PlanoContas = selectListPlanoContas;
            return View(model);
        }
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _transacaoService.Excluir(id);
        return RedirectToAction("Index");
    }

}
