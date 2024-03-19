using System.Text.Json.Serialization;

namespace SwapiAPI.Components.Models;

public class GetPlanetDetails
{
    public string? Message { get; set; }
    [JsonPropertyName("result")] 
    public PlanetResult PlanetResult { get; set; } = new PlanetResult();
}

public class PlanetResult
{
    [JsonPropertyName("properties")] 
    public PlanetProperties PlanetProperties { get; set; } = new PlanetProperties();
    public string? Description { get; set; }
}

public class PlanetProperties
{
    public string? Diameter { get; set; }
    [JsonPropertyName("rotation_period")] 
    public string? RotationPeriod { get; set; }
    [JsonPropertyName("orbital_period")] 
    public string? OrbitalPeriod { get; set; }
    public string? Gravity { get; set; }
    public string? Population { get; set; }
    public string? Climate { get; set; }
    public string? Terrain { get; set; }
    [JsonPropertyName("surface_water")] 
    public string? SurfaceWater { get; set; }
    public string? Created { get; set; }
    public string? Edited { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
}

