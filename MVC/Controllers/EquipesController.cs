using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Servicos;

namespace MVC.Controllers
{
    public class EquipesController : Controller
    {
        // GET: Equipes
        public async Task<IActionResult> Index()
        {
            return View(await BuscaEquipe.BuscarTodasEquipes());
        }

        // GET: Equipes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Cidade")] Equipe equipe)
        {

            List<Pessoa> listaPessoa = new List<Pessoa>();

            var cidade = Request.Form["Cidade"].FirstOrDefault(); //recupero o nome da cidade que foi selecionada no dropdown e salco na variavel
            var buscaCidade = await BuscaCidade.BuscarCidadePeloNome(cidade); //busco a cidade selecionada na API de cidade e retorno todas as informações
            var pessoa = Request.Form["VerificaPessoaEquipe"].ToList();//recupero os id das pessoas que foram selecionadas nas checkbox

            foreach (var item in pessoa)
            {
                listaPessoa.Add(await BuscaPessoa.BuscarPessoaPeloId(item));
            }

            if (ModelState.IsValid)
            {

                equipe.Pessoa = listaPessoa;
                equipe.Cidade = buscaCidade;
                BuscaEquipe.CadastrarEquipe(equipe);
                return RedirectToAction(nameof(Index));
            }
            return View(equipe);
        }

        // GET: Equipes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var equipe = await BuscaEquipe.BuscarEquipePeloId(id);

            //List<Pessoa> lista = new List<Pessoa>();
            //for (int i = 0; i < equipe.Pessoa.Count; i++)
            //{
            //    lista.Add(equipe.Pessoa[i]);
            //}

            //ViewBag.Pessoa = lista;


            if (equipe == null)
            {
                return NotFound();
            }
            return View(equipe);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Codigo,Pessoa,Cidade")] Equipe equipe)
        {
            if (id != equipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var pessoaAdd = Request.Form["adicionarPessoa"].ToList();

                if (pessoaAdd.Count > 0)
                {
                    for (int i = 0; i < pessoaAdd.Count; i++)
                    {
                        var buscarPessoa = await BuscaPessoa.BuscarPessoaPeloNome(pessoaAdd[i]);
                        equipe.Pessoa.Add(buscarPessoa);
                    }
                }
                BuscaEquipe.UpdateEquipe(id, equipe);
                return RedirectToAction(nameof(Index));
            }
            return View(equipe);
        }

        // GET: Equipes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await BuscaEquipe.BuscarEquipePeloId(id);

            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var equipe = await BuscaEquipe.BuscarEquipePeloId(id);
            BuscaEquipe.RemoverEquipe(id);
            return RedirectToAction(nameof(Index));
        }


















        //        private readonly MVCContext _context;

        //        public EquipesController(MVCContext context)
        //        {
        //            _context = context;
        //        }

        //        // GET: Equipes
        //        public async Task<IActionResult> Index()
        //        {
        //            return View(await _context.Equipe.ToListAsync());
        //        }

        //        // GET: Equipes/Details/5
        //        public async Task<IActionResult> Details(string id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var equipe = await _context.Equipe
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (equipe == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(equipe);
        //        }

        //        // GET: Equipes/Create
        //        public IActionResult Create()
        //        {
        //            return View();
        //        }

        //        // POST: Equipes/Create
        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Create([Bind("Id,Codigo")] Equipe equipe)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                _context.Add(equipe);
        //                await _context.SaveChangesAsync();
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(equipe);
        //        }

        //        // GET: Equipes/Edit/5
        //        public async Task<IActionResult> Edit(string id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var equipe = await _context.Equipe.FindAsync(id);
        //            if (equipe == null)
        //            {
        //                return NotFound();
        //            }
        //            return View(equipe);
        //        }

        //        // POST: Equipes/Edit/5
        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(string id, [Bind("Id,Codigo")] Equipe equipe)
        //        {
        //            if (id != equipe.Id)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(equipe);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!EquipeExists(equipe.Id))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(equipe);
        //        }

        //        // GET: Equipes/Delete/5
        //        public async Task<IActionResult> Delete(string id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var equipe = await _context.Equipe
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (equipe == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(equipe);
        //        }

        //        // POST: Equipes/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(string id)
        //        {
        //            var equipe = await _context.Equipe.FindAsync(id);
        //            _context.Equipe.Remove(equipe);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool EquipeExists(string id)
        //        {
        //            return _context.Equipe.Any(e => e.Id == id);
        //        }
    }
}
