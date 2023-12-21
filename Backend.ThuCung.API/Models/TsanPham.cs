using System;
using System.Collections.Generic;

namespace Backend.ThuCung.API.Models;

public partial class TsanPham
{
    public Guid IdsanPham { get; set; }

    public Guid Idcategory { get; set; }

    public string? ImageUrl { get; set; }

    public string? Title { get; set; }

    public string? SubTitle { get; set; }

    public string? Gender { get; set; }

    public int SoLuong { get; set; }

    public int? DaBan { get; set; }

    public string GiaDung { get; set; } = null!;

    public string GiaGoc { get; set; } = null!;

    public int? PhanTramGiam { get; set; }

    public string? NguonGoc { get; set; }

    public string? MoTaChiTiet { get; set; }

    public string? Type { get; set; }

    public DateTime? CreateAt { get; set; }
}
