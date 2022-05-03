using AKSoftware.WebApi.Client;
using BlazorTraining.Server.Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Business.Services
{
    public class ToDoItemService
    {
        private readonly string _baseUrl;
        ServiceClient client = new ServiceClient();
        public ToDoItemService(string url)
        {
            _baseUrl = url;
        }
        public string AccessToken
        {
            get => client.AccessToken;
            set
            {
                client.AccessToken = value;
            }
        }
        public async Task<SingleResponseToDoItem> CreateAsync(ToDoItemRequest model)
        {
            var response = await client.PostProtectedAsync<SingleResponseToDoItem>($"{_baseUrl}/api/todoitems", model);
            return response.Result;
        }
        public async Task<SingleResponseToDoItem> EditAsync(ToDoItemRequest model)
        {
            var response = await client.PutProtectedAsync<SingleResponseToDoItem>($"{_baseUrl}/api/todoitems", model);
            return response.Result;
        }
        public async Task<SingleResponseToDoItem> ChangeItemStateAsync(string id)
        {
            var response = await client.PutProtectedAsync<SingleResponseToDoItem>($"{_baseUrl}/api/todoitems/{id}", null);
            return response.Result;
        }
        public async Task<SingleResponseToDoItem> DeleteAsync(string id)
        {
            var response = await client.DeleteProtectedAsync<SingleResponseToDoItem>($"{_baseUrl}/api/todoitems/{id}");
            return response.Result;
        }
    }
}
