using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class SkuTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("skus")
                .WithColumn("id").AsInt64().PrimaryKey();
        }

        public override void Down()
        {
            Delete.Table("skus");
        }
    }
}
