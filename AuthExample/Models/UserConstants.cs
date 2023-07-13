namespace AuthExample.Models{
    public class UserConstants{
        public static List<UserModel> Users = new List<UserModel>(){
            new UserModel(){Username = "jason_admin", EmailAddress = "jason.admin@gmail.com", Password = "MyPass_word",
            GivenName = "Jason", Surname = "Bryant", Role = "Administrator"},
            new UserModel(){Username = "elyse_seller", EmailAddress = "elyse.seller@gmail.com", Password = "MyPass_word",
            GivenName = "Elyse", Surname = "Lambert", Role = "Seller"},
        };
    }
}