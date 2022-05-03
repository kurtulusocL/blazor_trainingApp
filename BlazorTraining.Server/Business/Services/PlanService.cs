using AKSoftware.WebApi.Client;
using BlazorTraining.Server.Entities.Concrete;
using BlazorTraining.Server.Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Server.Business.Services
{
    public class PlanService
    {
        private readonly string _baseUrl;
        ServiceClient client = new ServiceClient();
        public PlanService(string url)
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
        public async Task<PlansCollectionPagingResponse> GetAllPlansByPageAsync(int page = 1)
        {
            var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans?page={page}");
            return response.Result;
        }
        public async Task<PlansCollectionPagingResponse> SearchPlansByPageAsync(string query, int page = 1)
        {
            var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans/search?query={query}&page={page}");
            return response.Result;
        }
        public async Task<SinglePlanResponse> CreatePlanAsync(PlanRequest model)
        {
            var formKeyValues = new List<FormKeyValue>()
            {
                new StringFormKeyValue("Title", model.Title), new StringFormKeyValue("Description", model.Description)
            };

            if (model.CoverFile != null)
                formKeyValues.Add(new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));

            var response = await client.SendFormProtectedAsync<SinglePlanResponse>($"{_baseUrl}/api/plans", ActionType.POST, formKeyValues.ToArray());

            return response.Result;
        }
        public async Task<SinglePlanResponse> GetPlanByIdAsync(string id)
        {
            var response = await client.GetProtectedAsync<SinglePlanResponse>($"{_baseUrl}/api/plans/{id}");
            return response.Result;
        }
        public async Task<SinglePlanResponse> EditPlanAsync(PlanRequest model)
        {
            var formKeyValues = new List<FormKeyValue>()
            {
                new StringFormKeyValue("Id", model.Id), new StringFormKeyValue("Title", model.Title), new StringFormKeyValue("Description", model.Description)
            };

            if (model.CoverFile != null)
                formKeyValues.Add(new FileFormKeyValue("CoverFile", model.CoverFile, model.FileName));

            var response = await client.SendFormProtectedAsync<SinglePlanResponse>($"{_baseUrl}/api/plans", ActionType.PUT, formKeyValues.ToArray());
            return response.Result;
        }
        public async Task<SinglePlanResponse> DeletePlanAsync(string id)
        {
            var response = await client.DeleteProtectedAsync<SinglePlanResponse>($"{_baseUrl}/api/plans/{id}");
            return response.Result;
        }
    }
}
