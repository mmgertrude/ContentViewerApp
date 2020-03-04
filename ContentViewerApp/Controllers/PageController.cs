using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using System.Diagnostics;

namespace ContentViewerApp.Controllers
{
    public class PageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Page (gets all pages active and inactive)
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pages.ToListAsync());

        }


        //GET: Page (gets only active pages)
        public async Task<IActionResult> ActivePages()
        {

            var ActiveOnes = await _context.Pages.Where(x => x.PageStatus == Status.Active).ToListAsync();
            return View(ActiveOnes);
          
        }

        //Display active pages one at a time after set time interval
        public async Task<IActionResult> NextPage(int id)
        {   
            var ActiveOnes = await _context.Pages.Where(x => x.PageStatus == Status.Active).OrderBy(x => x.PageId).ToListAsync();
            Page model = null;
            if (id == 0)
            {
                model = ActiveOnes.First();
            } 
            else
            {
                foreach(var ToShow in ActiveOnes)
                {
                    if (ToShow.PageId > id)
                    {
                        model = ToShow;
                        break;
                    }
                }
                if (model == null)
                {
                    model = ActiveOnes.First();
                }
            }
            
            return PartialView(model);
        }

        //GET: Page (gets only active pages)
        public async Task<IActionResult> DisplaySample()
        {

            var ActiveOnes = await _context.Pages.Where(x => x.PageStatus == Status.Active).ToListAsync();
            return View(ActiveOnes);

        }




        // GET: Page/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Page/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Page/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageTitle,PageStatus,PageId,Content")] Page page)
        {
            if (ModelState.IsValid)
            {
                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: Page/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // POST: Page/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( [Bind("PageTitle,PageStatus,PageId,Content")] Page page)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(page);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.PageId))
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
            return View(page);
        }

        // GET: Page/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return _context.Pages.Any(e => e.PageId == id);
        }
    }
}
