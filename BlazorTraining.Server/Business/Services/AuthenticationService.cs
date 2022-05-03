using AKSoftware.WebApi.Client;
using BlazorTraining.Server.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Business.Services
{
    public class AuthenticationService
    {
        private readonly string _baseUrl;
        ServiceClient client = new ServiceClient(); 
        public AuthenticationService(string url)
        {
            _baseUrl = url;
        }
        public async Task<UserManagerDto> RegisterUserAsync(RegisterDto request)
        {
            var response = await client.PostAsync<UserManagerDto>($"{_baseUrl}/api/auth/register", request);
            return response.Result;
        }
        public async Task<UserManagerDto> LoginUserAsync(LoginDto request)
        {
            var response = await client.PostAsync<UserManagerDto>($"{_baseUrl}/api/auth/login", request);
            return response.Result;
        }
    }
}
