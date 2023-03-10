using Acme.Core;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Web;

public class BeveragesController : Controller
{
    private readonly IRepository<Beverage, Guid> repo;

    public BeveragesController(IRepository<Beverage, Guid> repo) => this.repo = repo;

    public async Task<IActionResult> Index() => this.View(await this.repo.Get());

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var Beverage = await this.repo.Get((Guid)id);
        return Beverage == null ? this.NotFound() : this.View(Beverage);
    }

    public IActionResult Create() => this.View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Name,Description")] Beverage target)
    {
        if (this.ModelState.IsValid)
        {
            await this.repo.Create(target);
            return this.RedirectToAction(nameof(Index));
        }
        return this.View(target);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var Beverage = await this.repo.Get(id);
        return Beverage == null ? this.NotFound() : this.View(Beverage);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Description")] Beverage target)
    {
        if (id != target.ID)
        {
            return this.NotFound();
        }

        if (!this.ModelState.IsValid)
        {
            return this.View(target);
        }

        await this.repo.Update(target);

        return this.RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var Beverage = await this.repo.Get(id.Value);
        return Beverage == null ? this.NotFound() : this.View(Beverage);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var _ = await this.repo.Remove(id);
        return this.RedirectToAction(nameof(Index));
    }
}
