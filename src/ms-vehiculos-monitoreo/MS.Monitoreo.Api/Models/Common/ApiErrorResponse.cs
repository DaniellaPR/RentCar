using System.Collections.Generic;

namespace MS.Monitoreo.Api.Models.Common
{
    public class ApiErrorResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string TraceId { get; set; }
    }
}
