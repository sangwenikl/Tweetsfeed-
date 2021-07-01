using AG.Domain.Abstracts;
using AG.Domain.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetFeeder;

namespace TweetFeeder.Mvc.Controllers
{
    public class TweetFeedsController : Controller
    {
        IFeedGenerator feedGenerator = new TweetFeedGenerator();
        
        // GET: TweetFeeds
        public ActionResult Index()
        {
            string tweetFeeds = feedGenerator.SimulateFeedEx();

            ViewBag.TweetFeeds = tweetFeeds;

            return View();
        }

        // GET: TweetFeeds/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TweetFeeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TweetFeeds/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: TweetFeeds/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TweetFeeds/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: TweetFeeds/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TweetFeeds/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
