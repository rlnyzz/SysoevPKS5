using System.Net.Http.Json;
using BlazorClient.Shared;

namespace BlazorClient.Services;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>> GetAll() =>
        await _http.GetFromJsonAsync<List<Product>>("api/products") ?? new();

    public async Task<Product?> GetById(int id) =>
        await _http.GetFromJsonAsync<Product>($"api/products/{id}");

    public async Task Add(Product product) =>
        await _http.PostAsJsonAsync("api/products", product);

    public async Task Update(Product product) =>
        await _http.PutAsJsonAsync($"api/products/{product.Id}", product);

    public async Task Delete(int id) =>
        await _http.DeleteAsync($"api/products/{id}");
}