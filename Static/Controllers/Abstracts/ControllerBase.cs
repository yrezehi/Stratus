using Microsoft.AspNetCore.Mvc;
using Static.Services.Abstracts.Interfaces;

namespace Static.Controllers.Abstracts
{
    public class ControllerBase<IService, T> : Controller where IService : IServiceBase<T> where T : class
    {
        public IService Service { get; set; }

        public ControllerBase(IService service) => 
            Service = service;

        [HttpGet("api/{id}")]
        public virtual async Task<IActionResult> Id(int id) => 
            Ok(await Service.FindById(id));

        [HttpGet("api")]
        public virtual async Task<IActionResult> GetAll() =>
            Ok(await Service.GetAll());

        [HttpGet("api/[action]")]
        public virtual async Task<IActionResult> Search(string property, string value) => 
            Ok(await Service.SearchByProperty<string>(property, value));

    }
}
