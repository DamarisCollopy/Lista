using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListaAmigosClassLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace WebAmigo.Controllers
{
    public class TablesController : Controller
    {
        private readonly ListaAmigosContext _context;
        private readonly IGerenciamentoCookie gCookie;

        public TablesController(ListaAmigosContext context, IGerenciamentoCookie gCookie)
        {
            _context = context;
            this.gCookie = gCookie;
        }

        // GET: Tables

        public async Task<IActionResult> Index()
        {
            return View(await _context.Table.ToListAsync());
        }

        // GET: Tables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // GET: Tables/Create
        public IActionResult Create()
        {
            return RedirectToAction("SalvarInformacao");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Email,DataNascimento")] Table table, bool isPersistent)
        {
            if (ModelState.IsValid)
            {
                gCookie.Create(" Nome", "Sobrenome", "Email ", "data");

                if (isPersistent)
                {
                    _context.Add(table);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("SalvarInformacao");
            }
            return View(table);
        }
        public IActionResult SalvarInformacao()
        {
            string nome = Request.Cookies["Nome"];
            string sobrenome = Request.Cookies["sobrenome"];
            string email = Request.Cookies["Email"];
            string data = Request.Cookies["Data"];
            DateTime dataConverte = DateTime.Parse(data);

            if (nome == null)
            {
                ViewBag.Dados = "No cookie found";
            }
            else
            {
                ViewData["Message"] = new Table()
                {
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Email = email,
                    DataNascimento = dataConverte,
                };

                return View();
            }
            return View();
        }
        // GET: Tables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Email,DataNascimento")] Table table)
        {
            if (id != table.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(table.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        // GET: Tables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .FirstOrDefaultAsync(m => m.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }
       

        // POST: Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table = await _context.Table.FindAsync(id);
            _context.Table.Remove(table);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(int id)
        {
            return _context.Table.Any(e => e.Id == id);
        }
    }

}
