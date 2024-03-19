using System.Text.Json.Serialization;

namespace SwapiAPI.Components.Models;

public class GetPersonsDetails
{
    public string? Message { get; set; }
    [JsonPropertyName("result")] 
    public PersonResult PersonResult { get; set; } = new PersonResult();

}

public class PersonResult
{
    [JsonPropertyName("properties")] 
    public PersonProperties PersonProperties { get; set; } = new PersonProperties();
    public string? Description { get; set; }
    
}

public class PersonProperties
{
    public string? Height { get; set; }
    public string? Mass { get; set; }
    [JsonPropertyName("hair_color")]
    public string? HairColor { get; set; }
    [JsonPropertyName("skin_color")]
    public string? SkinColor { get; set; }
    [JsonPropertyName("eye_color")]
    public string? EyeColor { get; set; }
    [JsonPropertyName("birth_year")]
    public string? BirthYear { get; set; }
    public string? Gender { get; set; }
    public string? Created { get; set; }
    public string? Edited { get; set; }
    public string? Name { get; set; }
    public string? Homeworld { get; set; }
    public string? Url { get; set; }
}

