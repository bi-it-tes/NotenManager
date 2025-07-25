using NotenManager.Components;
using NotenManager.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<SemesterRepository>(ServiceProvider =>  // SemesterRepository 
    new SemesterRepository(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddScoped<SubjectRepository>(ServiceProvider =>  //SubjectRepository
    new SubjectRepository(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddScoped<GradeRepository>(ServiceProvider => //GradeRepository
    new GradeRepository(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
