using SwapiAPI.Components.Models;

namespace SwapiAPI.Components.Services;

// Interface for interacting with the Star Wars API (SWAPI)
public interface ISwapiService
{
    // Asynchronously retrieves a list of people
    Task<IEnumerable<Person>> GetPerson();
    // Asynchronously retrieves a list of vehicles
    Task<IEnumerable<Vehicle>> GetVehicle();
    // Asynchronously retrieves a list of planets
    Task<IEnumerable<Planet>> GetPlanet();
    // Asynchronously retrieves a list of films
    Task<IEnumerable<FilmResult>> GetFilms();
}

public class SwapiService : ISwapiService
{
    
    private readonly HttpClient _httpClient;   // HttpClient for making HTTP requests

    public SwapiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    // get the list of People
    public async Task<IEnumerable<Person>> GetPerson()
    {
        var response = await _httpClient.GetFromJsonAsync<GetSwapiPeople>("https://swapi.tech/api/people");

        if (response == null)
        {
            return [];
        }
        
        var list = new List<Person>();
        list.AddRange((response.People));

        await GetAllPersonPages(response, list);
        
        return list;
    }

    // getting all the pages of people taking the nextPageUrl from the current page
    private async Task GetAllPersonPages(GetSwapiPeople nextPeople, List<Person> list)
    {
        var url = nextPeople.Next;

        nextPeople = await _httpClient.GetFromJsonAsync<GetSwapiPeople>(url);
        
        list.AddRange(nextPeople.People);

        if (nextPeople.Next != null)
        {
            await GetAllPersonPages(nextPeople, list);
        }
    }

    // get the list of Vehicle
    public async Task<IEnumerable<Vehicle>> GetVehicle()
    {
        var response = await _httpClient.GetFromJsonAsync<GetSwapiVehicles>("https://swapi.tech/api/vehicles");

        if (response == null)
        {
            return [];
        }
        
        var list = new List<Vehicle>();
        list.AddRange((response.Vehicles));

        await GetAllVehiclesPages(response, list);
        
        return list;
    }
    
    // getting all the pages of Vehicles
    private async Task GetAllVehiclesPages(GetSwapiVehicles nextVehicles, List<Vehicle> list)
    {
        var url = nextVehicles.Next;

        nextVehicles = await _httpClient.GetFromJsonAsync<GetSwapiVehicles>(url);
        
        if(nextVehicles.Vehicles != null)
            list.AddRange(nextVehicles.Vehicles);

        if (nextVehicles.Next != null)
        {
            await GetAllVehiclesPages(nextVehicles, list);
        }
    }
    
    // get the list of Planet
    public async Task<IEnumerable<Planet>> GetPlanet()
    {
        var response = await _httpClient.GetFromJsonAsync<GetSwapiPlanets>("https://swapi.tech/api/planets");

        if (response == null)
        {
            return [];
        }
        
        var list = new List<Planet>();
        list.AddRange((response.Planets));

        await GetAllVehiclesPages(response, list);
        
        return list;
    }
    
    // getting all the pages of Planets
    private async Task GetAllVehiclesPages(GetSwapiPlanets nextVehicles, List<Planet> list)
    {
        var url = nextVehicles.Next;

        nextVehicles = await _httpClient.GetFromJsonAsync<GetSwapiPlanets>(url);
        
        if(nextVehicles.Planets != null)
            list.AddRange(nextVehicles.Planets);

        if (nextVehicles.Next != null)
        {
            await GetAllVehiclesPages(nextVehicles, list);
        }
    }
    
    // get the list of Film
    public async Task<IEnumerable<FilmResult>> GetFilms()
    {
        var response = await _httpClient.GetFromJsonAsync<GetSwapiFilms>("https://swapi.tech/api/films");

        if (response == null)
        {
            return [];
        }

        var list = new List<FilmResult>();   // initializing the instance before adding it to the list
        foreach (var obj in response.Films)
        {
            list.Add(obj);
        }
        
        return list;
    }
    
}