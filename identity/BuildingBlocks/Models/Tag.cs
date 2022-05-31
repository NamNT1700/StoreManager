using System;

public class Tag
{
    public string name { get; set; }

    public TagColor color { get; set; }
}

public class TagColor
{
    public string color { get; set; }
    public string backgroundColor { get; set; }
    public string borderColor { get; set; }
}