using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.WebClient.ViewModels;
using BookStore.Services.Interfaces;
using BookStore.Services.MessageTypes;

namespace BookStore.WebClient.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        private IPurchaseService PurchaseService
        {
            get
            {
                return ServiceFactory.Instance.PurchaseService;
            }
        }

        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMedia()
        {
            return View(new CatalogueViewModel());
        }

        public ActionResult GetDetails(int id, UserCache pUser)
        {

            return View(new DetailsViewModel(id, pUser.Model));
        }

        public ActionResult Rate(int media, UserCache pUser, Boolean rating)
        {
            Media media2 = ServiceFactory.Instance.CatalogueService.GetMediaById(media);
            PurchaseService.Rate(media2, pUser.Model, rating);

            return View("GetDetails", new DetailsViewModel(media, pUser.Model));
        }

        //public ActionResult GetRecommend(int media, UserCache pUser)
        //{
        //    Media media2 = ServiceFactory.Instance.CatalogueService.GetMediaById(media);

        //    return View("GetDetails", new DetailsViewModel(media, pUser.Model));
        //}
    }
}