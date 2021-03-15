using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Business.Entities;

namespace BookStore.Business.Components.Interfaces
{
    public interface IPurchaseProvider
    {

        void Rate(BookStore.Business.Entities.Media media, BookStore.Business.Entities.User user, Boolean rating);

        int GetLikes(BookStore.Business.Entities.Media media);

        int GetDislikes(BookStore.Business.Entities.Media media);

        List<int> GetRecommended(BookStore.Business.Entities.Media media, BookStore.Business.Entities.User users);
    }
}
