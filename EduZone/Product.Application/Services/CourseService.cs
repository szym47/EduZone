﻿using Product.Domain.Repositories;
using ProductDomain.Models;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Text.Json;


namespace Product.Application.Services;

public class CourseService : ICourseService
{
    private IRepository _repository;
    private readonly IMemoryCache _cache;
    private readonly IDatabase _redisDb;


    public CourseService(IRepository repository, IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
        var redis = ConnectionMultiplexer.Connect("localhost:6379");
        _redisDb = redis.GetDatabase();
    }

    public async Task<List<Course>> GetAllAsync()
    {
        var result = await _repository.GetAllCourseAsync();

        return result;
    }

    public async Task<Course> GetAsync(int id)
    {
        string key = $"Course:{id}";
        var course = JsonSerializer.Deserialize<Course>(await _redisDb.StringGetAsync(key));

        if (course == null)
        {
            course = await _repository.GetCourseAsync(id);
            await _redisDb.StringSetAsync(key, JsonSerializer.Serialize(course), TimeSpan.FromDays(1));
        }

        return course;
    }

    public async Task<Course> UpdateAsync(Course course)
    {
        var result = await _repository.UpdateCourseAsync(course);

        string key = $"Course:{course.Id}";
        await _redisDb.KeyDeleteAsync(key);

        return result;
    }

    public async Task<Course> AddAsync(Course course)
    {
        var result = await _repository.AddCourseAsync(course);

        return result;
    }

    public Course Add(Course course)
    {
        var result = _repository.AddCourseAsync(course).Result;

        return result;
    }

    public async Task<Course> RestoreAsync(int id)
    {
        var course = await _repository.GetCourseAsync(id);
        if (course == null) return null;

        course.Deleted = false;
        return await _repository.UpdateCourseAsync(course);
    }

}