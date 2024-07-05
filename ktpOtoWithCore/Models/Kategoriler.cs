using System;
using System.Collections.Generic;

namespace ktpOtoWithCore.Models;

public partial class Kategoriler
{
    public int Id { get; set; }

    public string? KategoriAd { get; set; }

    public bool? Aktiflik { get; set; }

    public virtual ICollection<Kitaplar> Kitaplars { get; set; } = new List<Kitaplar>();
}
