using AnalyseText.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.Certificate;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();

var app = builder.Build();
AnalyseTextEndPoints.MapAnalyseTextEndPoints(app);

app.UseAuthentication();
app.Run();
public partial class Program { }