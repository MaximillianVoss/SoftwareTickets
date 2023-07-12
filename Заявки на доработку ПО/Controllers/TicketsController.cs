namespace Заявки_на_доработку_ПО.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using Заявки_на_доработку_ПО.Classes;

    public class TicketsController : Controller
    {
        private readonly SoftwareTicketsContext _context;

        public TicketsController(SoftwareTicketsContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetSoftwareByName(string term)
        {
            var softwareItems = this._context.Software.Where(s => s.Название.Contains(term));
            return this.Json(softwareItems);
        }


        // GET: Tickets
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            //var tickets = this._context.Tickets;
            var tickets = this._context.Tickets.Include(t => t.ПО).AsNoTracking();
            var pagedData = await PaginatedList<Ticket>.CreateAsync(tickets.AsNoTracking(), pageNumber, pageSize);
            return this.View(pagedData);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ticket = await this._context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return this.NotFound();
            }

            return this.View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            var softwareItems = this._context.Software;
            if (softwareItems == null || !softwareItems.Any())
            {
                throw new Exception("No software items found");
            }

            this.ViewBag.IdПО = new SelectList(softwareItems, "Id", "Название");
            return this.View();
        }


        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdПО,Название,Email,Описание,ДатаОкончанияРазработки")] Ticket ticket)
        {
            if (!this.ModelState.IsValid)
            {
                var errors = this.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

                // здесь вы можете просмотреть ошибки, используя отладчик или выводя их в консоль/лог
            }

            if (this.ModelState.IsValid)
            {
                this._context.Add(ticket);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction(nameof(Index));
            }
            this.ViewBag.IdПО = new SelectList(this._context.Software, "Id", "Название", ticket.IdПО);
            return this.View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ticket = await this._context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return this.NotFound();
            }

            // Добавьте следующие две строки
            var softwareItems = this._context.Software;
            this.ViewBag.IdПО = new SelectList(softwareItems, "Id", "Название", ticket.IdПО);

            return this.View(ticket);
        }


        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdПО,Название,Email,Описание,ДатаОкончанияРазработки")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this._context.Update(ticket);
                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.TicketExists(ticket.Id))
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
            this.ViewBag.IdПО = new SelectList(this._context.Software, "Id", "Название", ticket.IdПО);
            return this.View(ticket);
        }


        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ticket = await this._context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return this.NotFound();
            }

            return this.View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await this._context.Tickets.FindAsync(id);
            this._context.Tickets.Remove(ticket);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return this._context.Tickets.Any(e => e.Id == id);
        }
    }

}
