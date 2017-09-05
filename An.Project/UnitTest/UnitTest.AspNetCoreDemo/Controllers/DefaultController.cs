using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitTest.AspNetCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using UnitTest.AspNetCoreDemo.Models;

namespace UnitTest.AspNetCoreDemo.Controllers
{
    public class DefaultController : Controller
    {
        private readonly DefaultContext DB;
        public DefaultController(DefaultContext db)
        {
            this.DB = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await DB.Blogs.ToListAsync());
        }
        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogModel model)
        {
            if (ModelState.IsValid)
            {
                DB.Add(model);
                await DB.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model =await DB.Blogs.SingleOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int?id,BlogModel model)
        {
            if (id!=model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    DB.Update(model);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!isExists(model.Id))
                        return NotFound();
                    else throw new DbUpdateConcurrencyException(e.Message.ToString(),null);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await DB.Blogs.SingleOrDefaultAsync(x => x.Id == id);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfim(int? id)
        {
            var model =await DB.Blogs.SingleOrDefaultAsync(x => x.Id == id);
            DB.Blogs.Remove(model);
            await DB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var model = await DB.Blogs.SingleOrDefaultAsync(x => x.Id == id);
            if (model == null) return NotFound();
            return View(model);
        }
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool isExists(int? id)
        {
            return DB.Blogs.Any(e => e.Id == id);
        }
    }
}