namespace RecipeModels
{
    
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public List<Comment> Comments { get; set; }
        public List<UserFavorites> FavoriteRecipes { get; set; }

        public User()
        {

        }

        public User(int id, string username)
        {
            Id = id;
            UserName = username;
        }
        public User(int id, string userName, string email, bool isAdmin)
        {
            Id = id;
            UserName = userName;
            Email = email;           
            IsAdmin = isAdmin;
            
        }

        public User(string name, string email, string password)
        {
            UserName = name;
            Email = email;
            Password = password;
            
        }

        public User(string username, string email)
        {
            UserName = username;
            Email = email;
            
        }

        public User(int id, List<UserFavorites> favoritesRecipes)
        {
            Id = id;
            FavoriteRecipes = favoritesRecipes;
        }


    }
}