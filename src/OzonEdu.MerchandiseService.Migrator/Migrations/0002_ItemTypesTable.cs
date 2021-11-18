using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class ItemTypesTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("item_types")
                .WithColumn("id").AsInt64().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("item_types");
        }

    }
}
