
using System;
using System.Collections.Generic;

public class MarkupGroup
{
	

    public Guid uniqueId { get; set; }

    public string title { get; set; }

    public double createdDate { get; set; }

    public UserDTO createdBy { get; set; }

    public string description { get; set; }

    public double status { get; set; }

    public string ModelFileId { get; set; }

    public List<Tag> tags { get; set; }
	
}