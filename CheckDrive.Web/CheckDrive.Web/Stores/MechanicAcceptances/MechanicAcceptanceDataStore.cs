﻿using CheckDrive.Web.Models;
using CheckDrive.Web.Responses;
using CheckDrive.Web.Service;
using Newtonsoft.Json;
using System.Text;

namespace CheckDrive.Web.Stores.MechanicAcceptances
{
    public class MechanicAcceptanceDataStore : IMechanicAcceptanceDataStore
    {
        private readonly ApiClient _api;

        public MechanicAcceptanceDataStore(ApiClient apiClient)
        {
            _api = apiClient;
        }
        public async Task<GetMechanicAcceptanceResponse> GetMechanicAcceptancesAsync(int? pageNumber)
        {
            StringBuilder query = new("");

            if (pageNumber != null)
            {
                query.Append($"pageNumber={pageNumber}");
            }
            var response = await _api.GetAsync("mechanics/acceptances?" + query.ToString());

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not fetch drivers.");
            }

            var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var result = JsonConvert.DeserializeObject<GetMechanicAcceptanceResponse>(json);

            return result;
        }
        public Task<MechanicAcceptance> CreateMechanicAcceptanceAsync(MechanicAcceptance mechanicAcceptance)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMechanicAcceptanceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MechanicAcceptance> GetMechanicAcceptanceAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<MechanicAcceptance> UpdateMechanicAcceptanceAsync(int id, MechanicAcceptance mechanicAcceptance)
        {
            throw new NotImplementedException();
        }
    }
}