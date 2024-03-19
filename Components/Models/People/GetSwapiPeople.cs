using System.Text.Json.Serialization;

namespace SwapiAPI.Components.Models;

public class GetSwapiPeople
{
    public string? Message { get; set; }
    [JsonPropertyName("total_records")]
    public int TotalRecords { get; set; }
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    public string? Previous { get; set; }
    public string? Next { get; set; }
    [JsonPropertyName("results")]
    public Person[] People { get; set; }
}

public class Person
{
    [JsonPropertyName("uid")]
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
}