using Acme.Core;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Web;

public class WeatherReportsController : Controller
{
    private readonly IRepository<WeatherReport, Guid> repo;

    public WeatherReportsController(IRepository<WeatherReport, Guid> repo) => this.repo = repo;

    public async Task<IActionResult> Index() => this.View(await this.repo.Get());

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var report = await this.repo.Get(id.Value);

        if (report == null)
        {
            return this.NotFound();
        }

        return this.View(report);
    }

    public IActionResult Create() => this.View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("ID,Date,Temperature,Summary")] WeatherReport weatherReport
    )
    {
        if (!this.ModelState.IsValid)
        {
            return this.View(weatherReport);
        }

        await this.repo.Create(weatherReport);
        return this.RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var weatherReport = await this.repo.Get(id.Value);
        return weatherReport == null ? this.NotFound() : this.View(weatherReport);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        Guid id,
        [Bind("ID,Date,Temperature,Summary")] WeatherReport weatherReport
    )
    {
        if (id != weatherReport.ID)
        {
            return this.NotFound();
        }

        if (!this.ModelState.IsValid)
        {
            return this.View(weatherReport);
        }

        await this.repo.Update(weatherReport);

        return this.RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var weatherReport = await this.repo.Get(id.Value);

        return weatherReport == null ? this.NotFound() : this.View(weatherReport);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await this.repo.Remove(id);

        return this.RedirectToAction(nameof(Index));
    }
}
