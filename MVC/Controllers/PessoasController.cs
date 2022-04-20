﻿//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace MVC.Controllers
//{
//    public class PessoasController : Controller
//    {
//        private readonly MVCContext _context;

//        public PessoasController(MVCContext context)
//        {
//            _context = context;
//        }

//        // GET: Pessoas
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Pessoa.ToListAsync());
//        }

//        // GET: Pessoas/Details/5
//        public async Task<IActionResult> Details(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var pessoa = await _context.Pessoa
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (pessoa == null)
//            {
//                return NotFound();
//            }

//            return View(pessoa);
//        }

//        // GET: Pessoas/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Pessoas/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Nome")] Pessoa pessoa)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(pessoa);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(pessoa);
//        }

//        // GET: Pessoas/Edit/5
//        public async Task<IActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var pessoa = await _context.Pessoa.FindAsync(id);
//            if (pessoa == null)
//            {
//                return NotFound();
//            }
//            return View(pessoa);
//        }

//        // POST: Pessoas/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome")] Pessoa pessoa)
//        {
//            if (id != pessoa.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(pessoa);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PessoaExists(pessoa.Id))
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
//            return View(pessoa);
//        }

//        // GET: Pessoas/Delete/5
//        public async Task<IActionResult> Delete(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var pessoa = await _context.Pessoa
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (pessoa == null)
//            {
//                return NotFound();
//            }

//            return View(pessoa);
//        }

//        // POST: Pessoas/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(string id)
//        {
//            var pessoa = await _context.Pessoa.FindAsync(id);
//            _context.Pessoa.Remove(pessoa);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool PessoaExists(string id)
//        {
//            return _context.Pessoa.Any(e => e.Id == id);
//        }
//    }
//}
