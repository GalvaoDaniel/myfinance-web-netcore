using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Infrastructure;
using AutoMapper;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;
    private readonly IPlanoContaService _planoContaService;

    public PlanoContaController(
        ILogger<PlanoContaController> logger,
        IPlanoContaService planoContaService)
    {
        _logger = logger;
        _planoContaService = planoContaService;
    }

    public IActionResult Index()
    {
        var lista = _planoContaService.ListarRegistros();
        ViewBag.ListaPlanoConta = lista;
        return View();
    }

    [HttpPost]
    [Route("Cadastrar")]
    [Route("Cadastrar/{id}")]
    public IActionResult Cadastrar(PlanoContaModel model, int? id) 
    {
        if (ModelState.IsValid) 
        {
            _planoContaService.Salvar(model);
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
            var registro = _planoContaService.RetornarRegistro((int)id);
            return View(registro);
        } 
        return View();
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _planoContaService.Excluir(id);
        return RedirectToAction("Index");
    }

}
