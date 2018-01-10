using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/About")]
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return CreateSuccessRequestResult(data: new AboutViewModel
            {
                CompanyNews = _aboutService.GetCompanyNewses().Select(x => new CompanyNewsViewModel
                {
                    Title = x.Title,
                    Article = x.Article,
                    DateTime = x.DateTime
                }).ToList(),
                EventNews = _aboutService.GetEventNews().Select(x => new EventNewsViewModels
                {
                    Title = x.Title,
                    Article = x.Article,
                    DateTime = x.DateTime,
                    EventId = x.EventId
                }).ToList(),
                SalePlaces = _aboutService.GetSalePlaces().Select(x => new SalePlaceViewModel
                {
                    Name = x.Name,
                    Address = x.Address,
                    Phone = x.Phone
                }).ToList()
            });
        }
    }
}
