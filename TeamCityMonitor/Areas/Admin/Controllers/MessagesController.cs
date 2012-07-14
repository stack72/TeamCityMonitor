using System.Web.Mvc;
using BuildMonitor.Models;
using BuildMonitor.Models.Repository;

namespace BuildMonitor.Areas.Admin.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public ActionResult Index()
        {
            var messages = _messageRepository.GetAllMessages();
            return View(messages);
        }

        public ActionResult Details(int id)
        {
            var message = _messageRepository.GetMessage(id);
            return View(message);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Message message)
        {
            _messageRepository.Create(message);
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            var message = _messageRepository.GetMessage(id);
            return View(message);
        }

        [HttpPost]
        public ActionResult Edit(Message message)
        {
            _messageRepository.Update(message);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var message = _messageRepository.GetMessage(id);
            return View(message);
        }

        [HttpPost]
        public ActionResult Delete(Message message)
        {
            _messageRepository.Delete(message);
            return RedirectToAction("Index");
        }
    }
}
