using System;
using System.Collections.Generic;

namespace Backend.ThuCung.API.Models;

public partial class Tmenu
{
    public Guid MenuId { get; set; }

    public Guid? MenuGroupId { get; set; }

    public string? MenuName { get; set; }

    public string? Url { get; set; }

    public int? LevelMenu { get; set; }

    public DateTime? CreateAt { get; set; }
}
