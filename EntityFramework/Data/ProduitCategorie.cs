using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Data
{
	[PrimaryKey("ProduitId", "CategorieId")]
	public class ProduitCategorie
	{
		[ForeignKey("ProduitId")]
		public Produit Produit { get; set; }
		public int ProduitId { get; set; }

		[ForeignKey("CategorieId")]
		public Categorie Categorie { get; set; }
		public int CategorieId { get; set; }
	}

}
