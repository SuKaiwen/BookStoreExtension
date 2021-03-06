Kevin Su
This project is completed as part of the university assignment.
It is an extension of the original BookStore code provided.

1.1 How to run:
1)	Right click on BookStore.Process inside the BookStore.Application Folder.
2)	Go to Debug and then Start new instance.
3)	Do the same 2 steps for BookStore.WebClient.
1.2 Implementing Details cshtml page
In ListMedia.cshtml I placed an ActionLink that takes in a media id named (item.Id). The action is linked to the GetDetails function in the StoreController.
In the StoreController I created an ActionResult called GetDetails that takes in an integer id (referring to the media id) and a UserCache to get the user. It returns a new view model named DetailsViewModel. 
In the DetailsViewModel it has the variable type of Media and User and in the constructor it sets the media to the given media returned by passing the id into CatalogueService.GetMediaById and it sets the user to the user in the parameters.
In the GetDetails.cshtml itself, it uses those variables in DetailsViewModel to display the information to the user (for example: @Model.media.Title). 
1.3 Implementing the Like/Dislike functionality
I first created two new classes named PurchaseProvider and IPurchaseProvider under the BookStore business components. The PurchaseProvider class has 3 functions relating to like/dislike:
1.	Rate function taking in Media, User and a Boolean rating as parameters. It finds the PurchaseHistory item that matches the user and media id. Then it sets that item’s rating to the given Boolean value (true for like and false for dislike).
 
2.	GetLike and GetDislike function taking in a media item. The function gets the total amount of times a PurchaseHistory has been liked (p.Rating == true) or dislike (vice versa) where the PurchaseHistory’s media is equal to the media given in the parameters. 
These values are passed to the front end via PurchaseService where it is called in the DetailsViewModel constructor (For example: media.LikeCount = ServiceFactory.Instance.PurchaseService.GetLikes(id)). Since the Details cshtml page is made using the DetailsViewModel, it is simply displayed using @Model.media.LikeCount. 
1.4 Implementing Recommended Books functionality
In the PurchaseProvider I made a function named GetRecommeded which takes in a media item and user as parameters and returns a list of integers representing media ids. Firstly it gets every user that has liked this media item (passed in the parameter). Then for every user, get the id of the books that they have liked and add it to the list of media ids (Ensuring that the id added is unique and it is not the id of the current media).
 
The list of ids is then passed onto the PurchaseService which passes it into the DetailsViewModel. Then in the DetailsViewModel constructor it loops through all the ids and uses CatalogueService to get the media item and add it into a List<Media> named recommends. In the GetDetails cshtml I loop through each media item in the recommends list and display the title.
