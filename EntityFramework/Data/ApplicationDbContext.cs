using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Adresse> Adresses { get; set; }
		public DbSet<Fournisseur> Fournisseurs { get; set; }
		public DbSet<Categorie> Categories { get; set; }
		public DbSet<Produit> Produits { get; set; }
		public DbSet<ProduitCategorie> ProduitCategories { get; set; }
	}
}