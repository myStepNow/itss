using Microsoft.AspNetCore.Http;
using Domain.Models.RequestFeatures;

namespace Domain.DataTransferObjects
{
    public record LinkParameters
    {
        public BookParameters BookParameters { get; init; }
        public HttpContext HttpContext { get; init; }
    }
}
