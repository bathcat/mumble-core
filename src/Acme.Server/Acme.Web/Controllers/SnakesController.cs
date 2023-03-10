using Acme.Core;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Web;

public class SnakesController : Controller
{
    private readonly IRepository<SnakeInfo, Guid> repo;

    public SnakesController(IRepository<SnakeInfo, Guid> repo) => this.repo = repo;

    // GET: Snakes
    public async Task<IActionResult> Index() => this.View(await this.repo.Get());

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var snake = await this.repo.Get((Guid)id);
        return snake == null ? this.NotFound() : this.View(snake);
    }

    public IActionResult Create() => this.View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Name,Color,MeannessLevel")] SnakeInfo snake)
    {
        if (this.ModelState.IsValid)
        {
            await this.repo.Create(snake);
            return this.RedirectToAction(nameof(Index));
        }
        return this.View(snake);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var snake = await this.repo.Get(id);
        return snake == null ? this.NotFound() : this.View(snake);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        Guid id,
        [Bind("ID,Name,Color,MeannessLevel")] SnakeInfo target
    )
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

        var snake = await this.repo.Get((Guid)id);
        return snake == null ? this.NotFound() : this.View(snake);
    }

    [HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var snake = await this.repo.Remove(id);
        return this.RedirectToAction(nameof(Index));
    }
}
