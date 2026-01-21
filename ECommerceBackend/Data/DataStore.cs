using System.Text.Json;

namespace ECommerceBackend.Data;

public static class DataStore
{
    public static void Save<T>(string fileName, T data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(fileName, json);
    }

    public static T Load<T>(string fileName) where T : new()
    {
        if (!File.Exists(fileName))
            return new T();

        var json = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<T>(json) ?? new T();
    }
}
