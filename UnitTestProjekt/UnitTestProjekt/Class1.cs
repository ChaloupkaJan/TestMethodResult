using System;

namespace UnitTestProjekt
{
    enum Oblicej { VelkyNos, Ushoplesk, Makeup }
    enum Vlasy { Drdol, Culik, Pleska }
    enum BarvaVlasu { Kashtanova, Blond, Cervena }
    enum Prace { Obchodnik, Nepritel, Obyvatel, Farmar, Inzenyr }
    enum Síla { Normalni, Boss }
    class HerniPostava
    {
        private string jmeno;
        private int level;
        private int poziceX;
        private int poziceY;
        public HerniPostava(string jmeno)
        {
            Jmeno = jmeno;
            level = 1;
            poziceX = 0;
            poziceY = 0;
        }
        public string Jmeno
        {
            get { return jmeno; }
            set
            {
                if (value.Length > 10)
                {
                    Console.WriteLine("Upozornìní: Pøíliš dlouhé jméno!");
                }
                else
                {
                    jmeno = value;
                }
            }
        }
        public int Level
        {
            get { return level; }
        }
        public int PoziceX
        {
            get { return poziceX; }
        }
        public int PoziceY
        {
            get { return poziceY; }
        }
        public void ZmenaPozice()
        {
            poziceX += 1;
            poziceY += 1;
        }
        public void ZvysitLevel()
        {
            level++;
        }
        public override string ToString()
        {
            return "Jméno: " + Jmeno + ", Level: " + Level + ", Pozice X: " + PoziceX + ", Pozice Y: " + PoziceY;
        }
    }
    class Hrac : HerniPostava
    {
        private string specializace;
        private Oblicej oblicej;
        private Vlasy vlasy;
        private BarvaVlasu barvaVlasu;
        private int xp;
        public Hrac(string jmeno, string specializace, Oblicej oblicej, Vlasy vlasy, BarvaVlasu barvaVlasu)
            : base(jmeno)
        {
            this.specializace = ValidovatSpecializaci(specializace);
            this.oblicej = oblicej;
            this.vlasy = vlasy;
            this.barvaVlasu = barvaVlasu;
            this.xp = 0;
        }
        public string Specializace
        {
            get
            {
                return specializace;
            }
            set
            {
                specializace = ValidovatSpecializaci(value);
            }
        }
        public override string ToString()
        {
            return base.ToString() + ", Specializace: " + Specializace + ", Oblièej: " + oblicej + ", Vlasy: " + vlasy + ", Barva vlasù: " + barvaVlasu + ", XP: " + xp;
        }
        public void PridatXP(int hodnotaXP)
        {
            xp += hodnotaXP;
            int potrebneXP = 100 * Level;

            while (xp >= potrebneXP)
            {
                xp -= potrebneXP;
                ZvysitLevel();
                potrebneXP = 100 * Level;
            }
        }
        private string ValidovatSpecializaci(string novaSpecializace)
        {
            string[] povoleneSpecializace = { "Kouzelník", "Berserker", "Inženýr", "Cizák" };

            if (Array.Exists(povoleneSpecializace, s => s.Equals(novaSpecializace, StringComparison.OrdinalIgnoreCase)))
            {
                return novaSpecializace;
            }
            else
            {
                Console.WriteLine("Chyba: Neplatná specializace. Zvolte mezi: Kouzelník, Berserker, Inženýr, Cizák.");
                return specializace;
            }
        }
    }
    class NPC : HerniPostava
    {
        public Prace Prace { get; set; }
        public Síla Síla { get; set; }

        public NPC(string jmeno, Prace prace, Síla síla = Síla.Normalni)
            : base(jmeno)
        {
            Prace = prace;
            Síla = síla;
        }
        public NPC(string jmeno, Prace prace)
            : this(jmeno, prace, Síla.Normalni)
        {
        }
        public override string ToString()
        {
            return base.ToString() + ", Práce: " + Prace + ", Síla: " + Síla;
        }
    }
}
