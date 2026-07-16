using System.Xml.Serialization;

namespace frontend.Services;

[XmlRoot("Menu")]
public class MenuConfig
{
    [XmlElement("Section")]
    public List<MenuSection> Sections { get; set; } = new();
}

public class MenuSection
{
    /// <summary>
    /// Texto del encabezado de sección (ej. "Apps", "Pages").
    /// Si se omite, la sección se renderiza sin encabezado (caso "Dashboards").
    /// </summary>
    [XmlAttribute("Title")]
    public string? Title { get; set; }

    [XmlElement("Item")]
    public List<MenuItem> Items { get; set; } = new();
}

public class MenuItem
{
    [XmlAttribute("Text")]
    public string Text { get; set; } = string.Empty;

    /// <summary>Clase de ícono Bootstrap Icons, ej. "bi-bag".</summary>
    [XmlAttribute("Icon")]
    public string? Icon { get; set; }

    /// <summary>Ruta de navegación. Se ignora si el item tiene hijos (actúa como toggle).</summary>
    [XmlAttribute("Url")]
    public string? Url { get; set; }

    /// <summary>Texto del badge, ej. "5", "New", "Special". Null = sin badge.</summary>
    [XmlAttribute("Badge")]
    public string? Badge { get; set; }

    /// <summary>Variante visual del badge: primary | info | secondary | success | danger.</summary>
    [XmlAttribute("BadgeVariant")]
    public string BadgeVariant { get; set; } = "primary";

    /// <summary>Si es true, se resalta como el ítem actualmente activo.</summary>
    [XmlAttribute("Active")]
    public bool Active { get; set; }

    /// <summary>Si es true, el submenú arranca expandido al cargar.</summary>
    [XmlAttribute("Expanded")]
    public bool Expanded { get; set; }

    [XmlElement("Item")]
    public List<MenuItem> Children { get; set; } = new();

    [XmlIgnore]
    public bool HasChildren => Children.Count > 0;
}
