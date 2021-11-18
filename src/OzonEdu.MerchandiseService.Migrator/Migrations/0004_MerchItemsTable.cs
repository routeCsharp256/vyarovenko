using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(4)]
    public class MerchItemsTable : Migration 
    {
        public override void Up()
        {
            Create
                .Table("merch_items")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("item_type_id").AsInt32()
                .WithColumn("clouthing_size_id").AsInt32()
                .WithColumn("sku_id").AsInt64();
        }

        public override void Down()
        {
            Delete.Table("merch_items");
        }
    }
}
