using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Data
{
	public class Produit : IdTable
	{
		public string Nom { get; set; }
		public string? Description { get; set; }
		public string Reference { get; set; }

		[ForeignKey("FournisseurID")]
		public Fournisseur? Fournisseur { get; set; }
		public int? FournisseurID { get; set; }
	}
}
