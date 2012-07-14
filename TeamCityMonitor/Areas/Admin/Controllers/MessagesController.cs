using System.Web.Mvc;
using BuildMonitor.Models;
using BuildMonitor.Models.Repository;

namespace BuildMonitor.Areas.Admin.Controllers
{
    public class MessagesController : Controller
    {
        private IMessageRepository _messageRepository;
        public MessagesController()
        {
            _messageRepository = new MessageRepository();
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
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            var message = _messageRepository.GetMessage(id);
            return View(message);
        }

        [HttpPost]
        public ActionResult Edit(Message message)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var message = _messageRepository.GetMessage(id);
            return View(message);
        }

        [HttpPost]
        public ActionResult Delete(Message message)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
