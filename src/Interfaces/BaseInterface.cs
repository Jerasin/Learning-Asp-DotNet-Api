using Microsoft.AspNetCore.Mvc;
using RestApiSample.src.Services;

namespace RestApiSample.src.Interfaces
{
    public interface IFormatResponseService
    {
        public TFormatResponseService getObject();

        public IActionResult GetActionResult();

    }
}