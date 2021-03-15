using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BookStore.Services.MessageTypes;

namespace BookStore.Services.Interfaces
{
    [ServiceContract]
    public interface IPurchaseService
    {
        [OperationContract]
        void Rate(BookStore.Services.MessageTypes.Media media, BookStore.Services.MessageTypes.User user, Boolean rating);
        [OperationContract]
        int GetLikes(int id);
        [OperationContract]
        int GetDislikes(int id);
        [OperationContract]
        List<int> GetRecommended(int id, User users);
    }
}
