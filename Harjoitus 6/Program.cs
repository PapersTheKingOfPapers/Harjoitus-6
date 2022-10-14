using Harjoitus_6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Web-palvelu
builder.Services.AddDbContext<SuperAdventure>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// API-Kutsu
app.MapGet("/", () => "T‰m‰ on GET API-Kutsu");

// Palauttaa kutsujalle kaikki tilatiedot taulusta Stats
app.MapGet("/superadventure", async(SuperAdventure context) => await context.Quests.ToListAsync());

// Palauttaa kutsujalle (POST ja PUT -kutsut) kaikki tilatiedot
async Task<List<Quest>> GetAllStats(SuperAdventure context) => await context.Quests.ToListAsync();

// P‰ivitt‰‰ kutsujan pyynnˆst‰ tilatiedot Stats -tauluun
app.MapPut("/superadventure/{tehtavaID}", async(SuperAdventure context, Quest quest, int tehtavaID) =>
{
    // Haetaan p‰‰avaimen (id) perusteella tietueen tietokannasta
    var dbStat = await context.Quests.FindAsync(tehtavaID);
    if (dbStat is null) return Results.NotFound("Ei tilatietoja. :/");

    // M‰‰ritell‰‰n p‰ivitett‰v‰t tiedot
    dbStat.TehtavaNimi = quest.TehtavaNimi;
    dbStat.TehtavaKuvaus = quest.TehtavaKuvaus;
    dbStat.PalkkioMaara = quest.PalkkioMaara;
    dbStat.KokemusPisteet = quest.KokemusPisteet;

    // P‰ivitet‰‰n tilatiedot
    dbStat.OnkoSuoritettu = quest.OnkoSuoritettu;
    await context.SaveChangesAsync();

    // Jos tallennus meni hyvin, niin kutustaan metodia GetAllStats().
    return Results.Ok(await GetAllStats(context));
});

app.Run();