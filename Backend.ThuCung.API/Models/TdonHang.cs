﻿using System;
using System.Collections.Generic;

namespace Backend.ThuCung.API.Models;

public partial class TdonHang
{
    public Guid IddonHang { get; set; }

    public Guid? Iduser { get; set; }

    public string TongTien { get; set; } = null!;

    public Guid IdhinhThucThanhToan { get; set; }

    public DateTime? CreateAt { get; set; }
}
