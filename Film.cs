namespace Wpf_dolgozat1 {
    internal class Film {
        public string Filmazon { get; private set; }
        public string Cim { get; private set; }
        public int Ev { get; private set; }
        public string Szines { get; private set; }
        public string Mufaj { get; private set; }
        public int Hossz { get; private set; }

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