using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/EventComment")]
    public class EventCommentController : BaseController
    {
        private readonly IEventCommentService _eventCommentService;
        private readonly IUserService _userService;

        public EventCommentController(IEventCommentService eventCommentService, IUserService userService)
        {
            _eventCommentService = eventCommentService;
            _userService = userService;
        }

        [HttpGet("GetComments")]
        public IActionResult GetComments(int eventId)
        {
            var comments = _eventCommentService.GetComments(eventId).Select(x => new EventCommentViewModel
            {
                Username = x.User.Username,
                Comment = x.Comment,
                DateTime = x.DateTime
            });

            return CreateSuccessRequestResult(data: comments);
        }

        [HttpPost("AddComment")]
        public IActionResult AddComment([FromBody] EventCommentViewModel eventCommentViewModel)
        {
            var user = _userService.GetUser(User.Identity.Name);
            _eventCommentService.AddComment(new EventComment
            {
                UserId = user.Id,
                EventId = eventCommentViewModel.EventId,
                Comment = eventCommentViewModel.Comment,
                DateTime = DateTime.Now
            });

            return CreateSuccessRequestResult();
        }
    }
}
