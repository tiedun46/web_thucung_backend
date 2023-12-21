using System;
using System.Collections.Generic;

namespace Backend.ThuCung.API.Models;

public partial class Ttopic
{
    public Guid Idtopic { get; set; }

    public string? TopicName { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public bool? IsEvent { get; set; }
}
