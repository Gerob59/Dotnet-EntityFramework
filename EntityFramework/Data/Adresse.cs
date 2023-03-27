namespace EntityFramework.Data
{
	public class Adresse : IdTable
	{
		public string Voie { get; set; }
		public string CP { get; set; }
		public string Ville { get; set; }
		public string Pays { get; set; }
	}
}
