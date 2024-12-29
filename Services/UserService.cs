using BlazorApp2.Models.Requests;
using BlazorApp2.Models.Responses;
using BlazorApp2.Services.Interfaces;

namespace BlazorApp2.Services
{
    public class UserService : IUserService
    {
        private IHttpClientService _httpClientService;
        private const string _url = "https://reqres.in/api";

		public UserService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

		public async Task<PageItem<User>> GetListUsersAsync()
            => await _httpClientService.SendAsync<PageItem<User>, object>($"{_url}/users?page=2", HttpMethod.Get, null);
        public async Task<UserAddResponse> AddUserAsync(UserAddRequest user)
            => await _httpClientService.SendAsync<UserAddResponse, UserAddRequest>($"{_url}/users", HttpMethod.Post, user);
    }
}
