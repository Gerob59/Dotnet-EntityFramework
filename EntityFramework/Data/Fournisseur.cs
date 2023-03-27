using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Data
{
	public class Fournisseur : IdTable
	{
		public string Nom { get; set; }

		[ForeignKey("AdresseID")]
		public Adresse? Adresse { get; set; }
		public int? AdresseID { get; set; }
	}
}