namespace randomuser;

public class RandomUserResponse
{
    public List<UserResult> Results {get;set;}
}

public class UserResult
{
    public NameInfo Name {get; set;}
    public string Email {get; set;}
    public string Gender { get; set;}
}

public class NameInfo
{
    public string FirstName { get; set;}
    public string LastName { get; set;}
}