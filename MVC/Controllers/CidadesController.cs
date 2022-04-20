using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Servicos;

namespace MVC.Controllers
{
    public class CidadesController : Controller
    {
        //    private readonly MVCContext _context;

        //    public CidadesController(MVCContext context)
        //{
        //    _context = context;
        //}



        // GET: Cidades
        public async Task<IActionResult> Index()
        {

           // var retornoCidade = new List<Cidade>();

            //Cidade cidade = await BuscaCidade.BuscarTodasCidades(); //fazer um serviço pra buscar todas as cidades e colocar ele aqui
           // retornoCidade.Add(cidade);
           // return View(retornoCidade.ToList());

            //return View(await _context.Cidade.ToListAsync());  --  esse era o original
            return View(await BuscaCidade.BuscarTodasCidades()); // esse é um possivel jeito de fazer, mas não to certo.

        }

        // GET: Cidades/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cidade = await _context.Cidade
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cidade == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cidade);
        //}

        // GET: Cidades/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                BuscaCidade.CadastrarCidade(cidade);                                                       //criar serviço pra fazer post da cidade e colocar ele aqui
                return RedirectToAction(nameof(Index));
            }
            return View(cidade);
        }

       // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await BuscaCidade.BuscarCidadePeloId(id);                                    //criar serviço pra buscar a cidade pelo id
            if (cidade == null)
            {
                return NotFound();
            }
            return View(cidade);
        }



       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome")] Cidade cidade)
        {
            if (id != cidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var retornoCidade = await BuscaCidade.BuscarCidadePeloId(id);             //mesmo servico que criei pra função de cima
                    BuscaCidade.UpdateCidade(id, cidade);                           //criar serviço de update pra cidade

                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CidadeExists(cidade.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                        throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await BuscaCidade.BuscarCidadePeloId(id);                               //mesmo serviço que usou em cima pra busca por id

            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cidade = await BuscaCidade.BuscarCidadePeloId(id);
            BuscaCidade.RemoverCidade(id);                                           //criar serviço pra remover cidade
            return RedirectToAction(nameof(Index));
        }

        //private bool CidadeExists(string id)
        //{
        //    return _context.Cidade.Any(e => e.Id == id);
        //}
    }
}
