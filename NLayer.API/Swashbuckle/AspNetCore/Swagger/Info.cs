using Microsoft.OpenApi.Models;

namespace Swashbuckle.AspNetCore.Swagger
{
    internal class Info : OpenApiInfo
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public OpenApiContact Contact { get; set; }
        public OpenApiLicense License { get; set; }
    }
}