using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class QAController : Controller
    {
        // GET: QA
        public ActionResult Index()
        {
            using (var _context = new Entities())
            {
                var sqlQA = _context.cs_qa.Where(qa => qa.qa_no == "10")
                                          .OrderBy(qa => qa.qa_id);
                            
            }

            return View();
        }
    }
}