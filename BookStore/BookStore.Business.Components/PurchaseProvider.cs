using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Business.Components.Interfaces;
using BookStore.Business.Entities;
using System.Transactions;
using System.ComponentModel.Composition;
using System.Data.Entity;

namespace BookStore.Business.Components
{
    public class PurchaseProvider : IPurchaseProvider
    {
        public void Rate(BookStore.Business.Entities.Media media, BookStore.Business.Entities.User user, Boolean rating)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (BookStoreEntityModelContainer lContainer = new BookStoreEntityModelContainer())
            {
                if (lContainer.PurchaseHistories.Any(s => s.Users.Id == user.Id && s.Media.Id == media.Id))
                { 
                    lContainer.PurchaseHistories.Where(p => p.Users.Id.Equals(user.Id)).Where(p => p.Media.Id.Equals(media.Id)).FirstOrDefault().Rating = rating;
                    lContainer.SaveChanges();
                }
                lScope.Complete();
            }
        }

        public int GetLikes(BookStore.Business.Entities.Media media)
        {
            using (BookStoreEntityModelContainer lContainer = new BookStoreEntityModelContainer())
            {
                return lContainer.PurchaseHistories.Count(p => p.Media.Id.Equals(media.Id) && (p.Rating == true));
            }
        }

        public int GetDislikes(BookStore.Business.Entities.Media media)
        {
            using (BookStoreEntityModelContainer lContainer = new BookStoreEntityModelContainer())
            {
                return lContainer.PurchaseHistories.Count(p => p.Media.Id.Equals(media.Id) && (p.Rating == false));
            }
        }

        public List<int> GetRecommended(BookStore.Business.Entities.Media media, BookStore.Business.Entities.User users)
        {
            List<int> mediaIds = new List<int>();

            using (BookStoreEntityModelContainer lContainer = new BookStoreEntityModelContainer())
            {
                // Get every user that liked this media except for the current logged in user
                var x = lContainer.PurchaseHistories.Where(p => p.Media.Id.Equals(media.Id) && (!p.Users.Id.Equals(users.Id)) 
                && (p.Rating == true)).Select(p => p.Users).ToList();

                // For every user that liked this media 
                // Find the id of the books that they also have liked
                // Add the books to the media id list only if it is not already in the list
                foreach(User user in x)
                {
                    var y = lContainer.PurchaseHistories.Where(u => u.Users.Id.Equals(user.Id) && (u.Rating == true)).Select(u => u.Media.Id);

                    foreach(int id in y)
                    {
                        if(!mediaIds.Contains(id) && id != media.Id)
                        {
                            mediaIds.Add(id);
                        }
                    }
                }
            }

            return mediaIds;
        }
    }
}
