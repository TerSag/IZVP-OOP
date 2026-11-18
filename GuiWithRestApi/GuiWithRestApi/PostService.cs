using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class PostService
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://jsonplaceholder.typicode.com/posts";

    public async Task<List<Post>> GetPostsAsync()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();

            var posts = JsonSerializer.Deserialize<List<Post>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return posts ?? new List<Post>();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Помилка мережі: {ex.Message}");
        }
        catch (JsonException ex)
        {
            throw new Exception($"Помилка обробки даних (JSON): {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Непередбачена помилка: {ex.Message}");
        }
    }
}