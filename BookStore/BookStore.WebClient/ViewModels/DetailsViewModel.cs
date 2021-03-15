using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Services.Interfaces;
using BookStore.Services.MessageTypes;

namespace BookStore.WebClient.ViewModels
{
    public class DetailsViewModel
    {
        public Media media { get; set; }
        public User user { get; set; }

        public List<Media> recommends { get; set; }

        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }

        private IUserService UserService
        {
            get
            {
                return ServiceFactory.Instance.UserService;
            }
        }

        public DetailsViewModel(int id, User users)
        {
            media = ServiceFactory.Instance.CatalogueService.GetMediaById(id);
            media.LikeCount = ServiceFactory.Instance.PurchaseService.GetLikes(id);
            media.DislikeCount = ServiceFactory.Instance.PurchaseService.GetDislikes(id);
            user = users;
            var ids = ServiceFactory.Instance.PurchaseService.GetRecommended(id, users);

            recommends = new List<Media>();

            if(ids != null)
            {
                foreach (int idd in ids)
                {
                    recommends.Add(ServiceFactory.Instance.CatalogueService.GetMediaById(idd));
                }
            }
            
        }
    }
}