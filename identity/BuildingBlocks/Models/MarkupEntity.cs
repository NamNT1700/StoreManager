
using System;

public class MarkupEntity
{
    public Guid uniqueId { get; set; } = Guid.NewGuid();

    public string title { get; set; } = "Rdl Markup";

    public string uniqueViewId { get; set; }

    public double type { get; set; }

    public double createdDate { get; set; } = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds;

    public string uniqueGroupId { get; set; }

    public object originData { get; set; }

    public double modeMarkup { get; set; }
}