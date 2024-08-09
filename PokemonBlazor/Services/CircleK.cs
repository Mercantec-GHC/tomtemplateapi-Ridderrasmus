namespace PokemonBlazor.Services
{
    public class CircleK
    {
        private readonly HttpClient _httpClient;

        public CircleK(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetBaseURL()
        {
            return _httpClient.BaseAddress.ToString();
        }

        public async Task<T?> GetAsync<T>(string requestUri)
        {
            try
            {
                var response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
