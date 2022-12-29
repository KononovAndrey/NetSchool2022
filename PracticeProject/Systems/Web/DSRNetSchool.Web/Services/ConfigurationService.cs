namespace DSRNetSchool.Web;

using Blazored.LocalStorage;

public class ConfigurationService : IConfigurationService
{
    private readonly ILocalStorageService _localStorage;

    public ConfigurationService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<bool> GetDarkMode()
    {
        return await _localStorage.GetItemAsync<bool>("darkMode");
    }

    public async Task SetDarkMode(bool value)
    {
        await _localStorage.SetItemAsync("darkMode", value);
    }

    public async Task<bool> GetNavigationMenuVisible()
    {
        return await _localStorage.GetItemAsync<bool>("navigationMenuVisible");
    }

    public async Task SetNavigationMenuVisible(bool value)
    {
        await _localStorage.SetItemAsync("navigationMenuVisible", value);
    }
}
