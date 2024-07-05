namespace ktpOtoWithCore.Models.MyModels
{
    public class Kitap
    {
        public int Id { get; set; }

        public int? KategoriId { get; set; }

        public string? KitapAd { get; set; }

        public string? Yazar { get; set; }

        public string? SayfaSayisi { get; set; }

        public bool? Aktiflik { get; set; }
        public string KategoriAd { get; set; }
    }
}
