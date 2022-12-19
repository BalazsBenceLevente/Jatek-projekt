namespace PushToWin
{
	public class Jatekosmozgas
	{
		public static Jatekosmozgas Balra = new Jatekosmozgas(-1, 0);
		public static Jatekosmozgas Jobbra = new Jatekosmozgas(1, 0);
		public static Jatekosmozgas Fel = new Jatekosmozgas(0, 1);
		public static Jatekosmozgas Le = new Jatekosmozgas(0, -1);
		
		public int Sorirany { get; }
		public int Oszlopirany { get; }

		private Jatekosmozgas(int sorirany, int oszlopirany)
        {
			Sorirany = sorirany;
			Oszlopirany = oszlopirany; 
        }

		public Jatekosmozgas Ellentetes()
        {
			return new Jatekosmozgas(-Sorirany, -Oszlopirany);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
