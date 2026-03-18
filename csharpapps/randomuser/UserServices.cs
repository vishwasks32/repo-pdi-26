namespace randomuser;

public interface IRandomUserService
{
    Task<UserResult?> GetRandomUserAsync();
}

public class RandomUserService : IRandomUserService
{
    private readonly HttpClient _httpClient;

    public RandomUserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserResult?> GetRandomUserAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<RandomUserResponse>("todos/3");
        Console.WriteLine("Inside GetRandomeUserAsync");

        return response?.Results.FirstOrDefault();
    }
}