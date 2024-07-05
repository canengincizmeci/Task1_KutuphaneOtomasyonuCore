using System;
using System.Collections.Generic;

namespace ktpOtoWithCore.Models;

public partial class Kitaplar
{
    public int Id { get; set; }

    public int? KategoriId { get; set; }

    public string? KitapAd { get; set; }

    public string? Yazar { get; set; }

    public string? SayfaSayisi { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual Kategoriler? Kategori { get; set; }
}
