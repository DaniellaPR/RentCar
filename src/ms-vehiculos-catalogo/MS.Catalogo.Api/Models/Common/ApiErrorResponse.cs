using System.Collections.Generic;
namespace MS.Catalogo.Api.Models.Common
{
    public class ApiErrorResponse
    {
        public string TraceId { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
