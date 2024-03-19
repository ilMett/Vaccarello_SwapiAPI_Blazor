using System.Text.Json.Serialization;

namespace SwapiAPI.Components.Models;

public class GetSwapiFilms
{
    public string? Message { get; set; }
    [JsonPropertyName("result")]
    public FilmResult[] Films { get; set; }
}

public class FilmResult
{
    public FilmProperties Properties { get; set; } = new FilmProperties();
    public string? Description { get; set; }
    [JsonPropertyName("uid")]
    public int Id { get; set; }
}

public class FilmProperties
{
    public string? Created { get; set; }
    public string? Edited { get; set; }
    public string? Producer { get; set; }
    public string? Title { get; set; }
    [JsonPropertyName("episode_id")]
    public int EpisodeId { get; set; }
    public string? Director { get; set; }
    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }
    [JsonPropertyName("opening_crawl")]
    public string? OpeningCrawl { get; set; }
    public string? Url { get; set; }
}




