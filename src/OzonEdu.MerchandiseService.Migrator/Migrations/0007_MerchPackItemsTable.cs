using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(7)]
    public class MerchPackItemsTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                        CREATE TABLE merch_pack_items
                        (
                            pack_id BIGINT,
                            merch_type_id BIGINT,
                            quantity BIGINT,
                            PRIMARY KEY(pack_id, merch_type_id)
                        );");
        }

        public override void Down()
        {
            Delete.Table("merch_pack_items");
        }
    }
}
