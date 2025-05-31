namespace Structlara.Giris.Sekiller
{
    public struct Kare
    {
        public Nokta _solUstKose;
        public Nokta _sagAltKose;
        public Kare(Nokta solUstKose, Nokta sagAltKose)
        {
            _solUstKose = solUstKose;
            _sagAltKose = sagAltKose;
        }
        public double Alan()
        {
            double genislik = _sagAltKose._x - _solUstKose._x;
            double yukseklik = _sagAltKose._y - _solUstKose._y;
            return genislik * yukseklik;
        }
        public double Cevre()
        {
            double genislik = _sagAltKose._x - _solUstKose._x;
            double yukseklik = _sagAltKose._y - _solUstKose._y;
            return 2 * (genislik + yukseklik);
        }
        public string Yazdır()
        {
            return $"Kare: Sol Üst Köşe({_solUstKose._x}, {_solUstKose._y}), Sağ Alt Köşe({_sagAltKose._x}, {_sagAltKose._y})";
        }
    }
}
