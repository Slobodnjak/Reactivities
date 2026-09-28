using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController(AppDbContext context) : BaseApiController
{

    // OVO JE STARI NACIN!
    // private readonly AppDbContext context;               -   Kreiramo polje
    // public ActivitiesController(AppDbContext context)    -   Kreiramo konstruktor i inicijalizujemo polje
    // {
    //     this.context = context;
    // }

    // SADA SE KORISTI PRIMARY CONSTRUCTOR - gore u samom nazivu klase dodajemo parametar - radi isto kao ovo staro!
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null)
        {
            return NotFound();
        }

        return activity;
    }

}
