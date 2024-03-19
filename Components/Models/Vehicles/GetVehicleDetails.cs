using System.Text.Json.Serialization;

namespace SwapiAPI.Components.Models;

public class GetVehicleDetails
{
    public string? Message { get; set; }
    [JsonPropertyName("result")] 
    public VehicleResult VehicleResult { get; set; } = new VehicleResult();
}

public class VehicleResult
{
    [JsonPropertyName("properties")] 
    public VehicleProperties VehicleProperties { get; set; } = new VehicleProperties();
    public string? Description { get; set; }
}

public class VehicleProperties
{
    public string? Model { get; set; }
    [JsonPropertyName("vehicle_class")] 
    public string? Vehicleclass { get; set; }
    public string? Manufacturer { get; set; }
    [JsonPropertyName("cost_in_credits")] 
    public string? CostInCredits { get; set; }
    public string? Length { get; set; }
    public string? Crew { get; set; }
    public string? Passengers { get; set; }
    [JsonPropertyName("max_atmosphering_speed")] 
    public string? MaxAtmospheringSpeed { get; set; }
    [JsonPropertyName("cargo_capacity")] 
    public string? CargoCapacity { get; set; }
    public string? Consumables { get; set; }
    public string? Created { get; set; }
    public string? Edited { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
}

