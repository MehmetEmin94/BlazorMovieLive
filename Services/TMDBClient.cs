﻿using BlazorMovieLive.Models;
using System.Net.Http.Json;

namespace BlazorMovieLive.Services
{
    public class TMDBClient
    {
        private readonly HttpClient _httpClient;

        public TMDBClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));

            string apiKey = configuration["TMDBKey"] ?? throw new Exception("TMDBKey not found!");
            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", apiKey);
        }

        public Task<PopularMoviePagedResponse?> GetPopularMoviesAsync()
        {
            return _httpClient.GetFromJsonAsync<PopularMoviePagedResponse>("movie/popular");
        }
    }
}
