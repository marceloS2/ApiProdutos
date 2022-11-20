using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoop2.Context;
using shoope.Models;

namespace shoop2.Controllers
{
    public class ProdutoController : Controller
    {     
        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {  var produtos = _context.Produtos.ToList();
            return View(produtos);
        }
          public IActionResult Criar()
        {
            return View();
        }
         
         
        [HttpPost]
        public IActionResult Criar (Produto produto)
        {
               if (ModelState.IsValid)
               {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                }
                return View(produto);       
         }
         
          [HttpGet]
          public async Task<IActionResult> Index(string nome)
{
    if (_context.Produtos == null)
    {
        return Problem("is null.");
    }

    var produtos = from m in _context.Produtos
                select m;

    if (!String.IsNullOrEmpty(nome))
    {
        produtos = produtos.Where(s => s.Nome!.Contains(nome));
    }

    return View(await produtos.ToListAsync());
}
             public IActionResult Editar(int id)
           {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
            return RedirectToAction(nameof(Index));

            return View(produto);
           }
            [HttpPost]
          public IActionResult Editar (Produto produto)
          {
            var produtoBanco = _context.Produtos.Find(produto.Id);
            produtoBanco.Nome = produto.Nome;
            produtoBanco.Preco = produto.Preco;
            produtoBanco.Categoria = produto.Categoria;
            produtoBanco.Fabricante = produto.Fabricante;
            
            _context.Produtos.Update(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
          }
             public IActionResult Detalhes(int id)
          {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            
            return RedirectToAction(nameof(Index));
            return View(produto);

          }
           public IActionResult Deletar(int id)
          {
            var produto = _context.Produtos.Find(id);
            if(produto == null)

            return RedirectToAction(nameof(Index));

            return View(produto);
          }
        
         [HttpPost]
        public IActionResult Deletar(Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(produto.Id);

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}