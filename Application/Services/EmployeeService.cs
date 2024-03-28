using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _client;

        public EmployeeService(HttpClient client)
        {
            _client = client;
        }

        public event Action EmployeesChange;

        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            var data = await _client.PostAsJsonAsync("api/employee", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var data = await _client.DeleteAsync($"api/employee/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();        
            return response!;
        }

       

        public async Task<List<Employee>> GetAsync()
            => await _client.GetFromJsonAsync<List<Employee>>("api/employee")!;
        

        public async Task<Employee> GetByIdAsync(int id)
            => await _client.GetFromJsonAsync<Employee>($"api/employee/{id}")!;                 
        
        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            var data = await _client.PutAsJsonAsync("api/employee", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
