using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel.News;
using PagedList;

namespace WebApplication1.Controllers
{
    public class NewsController : Controller
    {
        private Entities db = new Entities();

        // GET: News
        public ActionResult Index(string Sorting_Order, string SearchTitle, string SearchContent, string SearchDate, string SearchKind)
        {
            ViewData["SortingTitle"] = Sorting_Order == "Title_Enroll" ? "Title_Description" : "Title_Enroll";
            ViewData["SortingDate"] = String.IsNullOrEmpty(Sorting_Order) ? "Date_Enroll" : "";

            //(n.end_date == null || DateTime.Now < n.end_date)

            var sqlNews1 = db.cs_news.Where(n => n.enabled == "Y" && n.begin_date <= DateTime.Now && n.top_news =="Y")
                                     .Select(n => new NewsListViewModel.News
                                                                    {
                                                                     news_id = n.news_id,
                                                                     title = n.title,
                                                                     content = n.content,
                                                                     begin_date = n.begin_date,
                                                                     end_date = n.end_date,
                                                                     top_news = n.top_news,
                                                                     kind = n.news_kind
                                                                    }).AsEnumerable();

            var sqlNews2 = db.cs_news.Where(n => n.enabled == "Y" && n.begin_date <= DateTime.Now && n.top_news != "Y")
                                     .Select(n => new NewsListViewModel.News
                                                                     {
                                                                        news_id = n.news_id,
                                                                        title = n.title,
                                                                        content = n.content,
                                                                        begin_date = n.begin_date,
                                                                        end_date = n.end_date,
                                                                        top_news = n.top_news,
                                                                        kind = n.news_kind
                                                                    }).AsEnumerable();

            if (String.IsNullOrEmpty(SearchTitle) == false)
            {
                sqlNews1 = sqlNews1.Where(n => n.title.Contains(SearchTitle));
                sqlNews2 = sqlNews2.Where(n => n.title.Contains(SearchTitle));
            }

            if (String.IsNullOrEmpty(SearchContent) == false)
            {
                sqlNews1 = sqlNews1.Where(n => n.content.Contains(SearchContent));
                sqlNews2 = sqlNews2.Where(n => n.content.Contains(SearchContent));
            }

            if (String.IsNullOrEmpty(SearchDate) == false)
            {
                DateTime dteSearch;
                if (DateTime.TryParse(SearchDate, out dteSearch))
                {
                    sqlNews1 = sqlNews1.Where(n => DateTime.Compare(dteSearch, n.begin_date) >= 0 &&
                                                   (n.end_date is null || DateTime.Compare((DateTime) n.end_date,dteSearch) >= 0));

                    sqlNews2 = sqlNews2.Where(n => DateTime.Compare(dteSearch, n.begin_date) >= 0 &&
                                                   (n.end_date is null || DateTime.Compare((DateTime)n.end_date, dteSearch) >= 0));
                }
            }

            if (String.IsNullOrEmpty(SearchKind) == false)
            {
                sqlNews1 = sqlNews1.Where(n => n.kind == SearchKind);
                sqlNews2 = sqlNews2.Where(n => n.kind == SearchKind);
            }

            switch (Sorting_Order)
            {
                case "Title_Description":
                    sqlNews1 = sqlNews1.OrderByDescending(n => n.title);
                    sqlNews2 = sqlNews2.OrderByDescending(n => n.title);
                    break;
                case "Title_Enroll":
                    sqlNews1 = sqlNews1.OrderBy(n => n.title);
                    sqlNews2 = sqlNews2.OrderBy(n => n.title);
                    break;
                case "Date_Enroll":
                    sqlNews1 = sqlNews1.OrderBy(n => n.begin_date);
                    sqlNews2 = sqlNews2.OrderBy(n => n.begin_date);
                    break;
                default:
                    sqlNews1 = sqlNews1.OrderByDescending(n => n.begin_date);
                    sqlNews2 = sqlNews2.OrderByDescending(n => n.begin_date);
                    break;
            }

            var lstNews = sqlNews1.Concat(sqlNews2).ToList();

            lstNews.ForEach(
                n => {
                    if (n.top_news == "Y")
                    {
                        n.top_news = "v";
                    }
                    else 
                    {
                        n.top_news = "";
                    }

                    n.begin_end_date = n.begin_date.ToString("yyyy/MM/dd");
                    if (n.end_date != null)
                    {
                        n.begin_end_date += " ~ " + n.end_date.Value.ToString("yyyy/MM/dd");
                    }
                }
            );

            //var lstNewsList = db.cs_news.Join(db.cs_news_file, n => n.news_id, f => f.news_id,
            //                                                   (c,s) => new ViewModel.News.NewsListViewModel
            //                                                   {
            //                                                       title = c.title,
            //                                                       content = c.content,
            //                                                       begin_date = c.begin_date,
            //                                                       end_date = c.end_date,
            //                                                       top_news = c.top_news,
            //                                                       file_list = new List<ViewModel.News.NewsListViewModel.NewsFile> ViewModel.News.NewsListViewModel.NewsFile { display_name =  s.display_name,
            //                                                                                                                    serial_no = s.serial_no }
            //                                                   }).ToList();

            var objNews = new NewsListViewModel();
            objNews.news_list = lstNews;

            List<SelectListItem> lstItem = new List<SelectListItem>();

            lstItem.Add(new SelectListItem()
            {
                Value = "1",
                Text = "即時新聞"
            });

            lstItem.Add(new SelectListItem()
            {
                Value = "2",
                Text = "重大政策"
            });

            lstItem.Add(new SelectListItem()
            {
                Value = "3",
                Text = "業務新訊"
            });

            lstItem.Add(new SelectListItem()
            {
                Value = "4",
                Text = "活動快訊"
            });

            lstItem.Add(new SelectListItem()
            {
                Value = "5",
                Text = "就業資訊"
            });

            objNews.kind_list = lstItem.AsEnumerable();

            return View(objNews);
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cs_news cs_news = db.cs_news.Find(id);
            if (cs_news == null)
            {
                return HttpNotFound();
            }
            return View(cs_news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "news_id,news_kind,depart_code,title,content,enabled,begin_date,end_date,top_news,meta1,meta2,meta3,news_count,update_user_id,update_date,maintainer,maintainer_tel,new_begin_date,new_end_date,new_icon,tag_text,keyword")] cs_news cs_news)
        {
            if (ModelState.IsValid)
            {
                db.cs_news.Add(cs_news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cs_news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cs_news cs_news = db.cs_news.Find(id);
            if (cs_news == null)
            {
                return HttpNotFound();
            }
            return View(cs_news);
        }

        // POST: News/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "news_id,news_kind,depart_code,title,content,enabled,begin_date,end_date,top_news,meta1,meta2,meta3,news_count,update_user_id,update_date,maintainer,maintainer_tel,new_begin_date,new_end_date,new_icon,tag_text,keyword")] cs_news cs_news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cs_news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cs_news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cs_news cs_news = db.cs_news.Find(id);
            if (cs_news == null)
            {
                return HttpNotFound();
            }
            return View(cs_news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cs_news cs_news = db.cs_news.Find(id);
            db.cs_news.Remove(cs_news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
