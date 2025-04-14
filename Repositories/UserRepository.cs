public static class UserRepository
{
    private static List<User> Users = new List<User>();
    public static List<User> GetAll() => Users;
    public static User GetById(int id) => Users.FirstOrDefault(u => u.Id == id);
    public static void Add(User user) => Users.Add(user);
    public static void Update(User user)
    {
        var index = Users.FindIndex(u => u.Id == user.Id);
        if (index >= 0) Users[index] = user;
    }
    public static void Delete(int id) => Users.RemoveAll(u => u.Id == id);
}