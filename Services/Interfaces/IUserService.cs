using BlazorApp2.Models.Responses;
using BlazorApp2.Models.Requests;

namespace BlazorApp2.Services.Interfaces
{
  public interface IUserService
  {
    Task<PageItem<User>> GetListUsersAsync();
    Task<UserAddResponse> AddUserAsync(UserAddRequest user);
  }
}
