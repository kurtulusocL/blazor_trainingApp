using Blazored.LocalStorage;
using BlazorTraining.Server.Entities.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Core.Auth
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storageService;
        public LocalAuthenticationStateProvider(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _storageService.ContainKeyAsync("User"))
            {
                var userInfo = await _storageService.GetItemAsync<UserInfo>("User");
                var claims = new[]
                {
                    new Claim("Email",userInfo.Email),
                    new Claim("FirstName",userInfo.FirstName),
                    new Claim("LastName",userInfo.LastName),
                    new Claim("AccessToken",userInfo.AccessToken),
                    new Claim(ClaimTypes.NameIdentifier,userInfo.Id)
                };
                var identity = new ClaimsIdentity(claims, "AppUserToken");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }
            return new AuthenticationState(new ClaimsPrincipal());
        }
        public async Task LogoutAsync()
        {
            await _storageService.RemoveItemAsync("User");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
