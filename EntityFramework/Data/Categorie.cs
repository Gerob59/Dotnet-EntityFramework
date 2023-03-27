using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Data
{
	public class Categorie : IdTable
	{
		public string Nom { get; set; }

		[ForeignKey("CategorieParentID")]
		public Categorie? CategorieParent { get; set; }
		public int? CategorieParentID { get; set; }
	}
}
