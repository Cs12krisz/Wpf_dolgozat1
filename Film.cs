namespace Wpf_dolgozat1 {
    internal class Film {
        public string Filmazon { get; set; }
        public string Cim { get; set; }
        public int Ev { get; set; }
        public string Szines { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }

        public Film(string filmazon, string cim, int ev, string szines, string mufaj, int hossz) {
            Filmazon = filmazon;
            Cim = cim;
            Ev = ev;
            Szines = szines;
            Mufaj = mufaj;
            Hossz = hossz;
        }
    }
}