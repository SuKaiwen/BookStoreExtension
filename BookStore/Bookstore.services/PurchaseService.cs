using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Services.Interfaces;
using BookStore.Business.Components.Interfaces;
using Microsoft.Practices.ServiceLocation;
using BookStore.Services.MessageTypes;

namespace BookStore.Services
{
    public class PurchaseService : IPurchaseService
    {

        private IPurchaseProvider PurchaseProvider
        {
            get
            {
                return ServiceFactory.GetService<IPurchaseProvider>();
            }
        }

        private ICatalogueProvider CatalogueProvider
        {
            get
            {
                return ServiceFactory.GetService<ICatalogueProvider>();
            }
        }

        public int GetLikes(int id)
        {
            BookStore.Business.Entities.Media media = CatalogueProvider.GetMediaById(id);
            var result = PurchaseProvider.GetLikes(media);

            return result;
        }

        public int GetDislikes(int id)
        {
            BookStore.Business.Entities.Media media = CatalogueProvider.GetMediaById(id);
            var result = PurchaseProvider.GetDislikes(media);

            return result;
        }

        public void Rate(BookStore.Services.MessageTypes.Media media, BookStore.Services.MessageTypes.User user, Boolean rating)
        {
            // Convert from message type to business.entities 
            // Converting from serivce layer message type to business entities

            // Vice versa
            var internalMedia = MessageTypeConverter.Instance.Convert<
                BookStore.Services.MessageTypes.Media,
                BookStore.Business.Entities.Media>(media);

            var internalUser = MessageTypeConverter.Instance.Convert<
                BookStore.Services.MessageTypes.User,
                BookStore.Business.Entities.User>(user);

            PurchaseProvider.Rate(internalMedia, internalUser, rating);
        }

        public List<int> GetRecommended(int id, User users)
        {
            BookStore.Business.Entities.Media media = CatalogueProvider.GetMediaById(id);

            var internalUser = MessageTypeConverter.Instance.Convert<
                BookStore.Services.MessageTypes.User,
                BookStore.Business.Entities.User>(users);

            var result = PurchaseProvider.GetRecommended(media, internalUser);

            return result;
        }
    }
}
