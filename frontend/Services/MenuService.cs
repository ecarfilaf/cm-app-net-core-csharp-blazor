using System.Xml.Serialization;

namespace frontend.Services;

public class MenuService
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<MenuService> _logger;
    private MenuConfig? _cached;

    public MenuService(IWebHostEnvironment env, ILogger<MenuService> logger)
    {
        _env = env;
        _logger = logger;
    }

    /// <summary>
    /// Carga Data/menu.xml y lo cachea en memoria. Llamá <see cref="Reload"/>
    /// si necesitás forzar una relectura del archivo sin reiniciar la app.
    /// </summary>
    public MenuConfig Load()
    {
        return _cached ??= ReadFromDisk();
    }

    public MenuConfig Reload()
    {
        _cached = ReadFromDisk();
        return _cached;
    }

    private MenuConfig ReadFromDisk()
    {
        var path = Path.Combine(_env.ContentRootPath, "Data", "menu.xml");

        if (!File.Exists(path))
        {
            _logger.LogWarning("No se encontró {Path}; se devuelve un menú vacío.", path);
            return new MenuConfig();
        }

        using var stream = File.OpenRead(path);
        var serializer = new XmlSerializer(typeof(MenuConfig));
        return (MenuConfig?)serializer.Deserialize(stream) ?? new MenuConfig();
    }
}
