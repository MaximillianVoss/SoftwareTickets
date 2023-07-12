﻿using Заявки_на_доработку_ПО.Classes;

namespace Заявки_на_доработку_ПО.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class SoftwareController : Controller
    {
        private readonly SoftwareTicketsContext _context; // замените ApplicationDbContext на ваш DbContext

        public SoftwareController(SoftwareTicketsContext context) // замените ApplicationDbContext на ваш DbContext
        {
            this._context = context;
        }

        // GET: Software
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            var software = this._context.Software.AsQueryable(); // ваша логика может быть здесь

            return this.View(await PaginatedList<Software>.CreateAsync(software, pageNumber, pageSize));
        }


        // GET: Software/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var software = await this._context.Software
                .FirstOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return this.NotFound();
            }

            return this.View(software);
        }

        // GET: Software/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Software/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Название")] Software software)
        {
            if (this.ModelState.IsValid)
            {
                this._context.Add(software);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(software);
        }

        // GET: Software/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var software = await this._context.Software.FindAsync(id);
            if (software == null)
            {
                return this.NotFound();
            }
            return this.View(software);
        }

        // POST: Software/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Название")] Software software)
        {
            if (id != software.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this._context.Update(software);
                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.SoftwareExists(software.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(software);
        }

        // GET: Software/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var software = await this._context.Software
                .FirstOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return this.NotFound();
            }

            return this.View(software);
        }

        // POST: Software/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var software = await this._context.Software.FindAsync(id);
            this._context.Software.Remove(software);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }


        private bool SoftwareExists(int id)
        {
            return this._context.Software.Any(e => e.Id == id);
        }
    }

}
