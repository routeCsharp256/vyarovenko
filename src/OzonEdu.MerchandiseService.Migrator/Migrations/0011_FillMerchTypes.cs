using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(11)]
    public class FillMerchTypes : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO item_types (id, name)
                VALUES 
                    (1, 'TShirt'),
                    (2, 'Sweatshirt'),
                    (3, 'Notepad'),
                    (4, 'Bag'),
                    (5, 'Pen'),
                    (6, 'Socks')
                ON CONFLICT DO NOTHING
            ");
        }
    }
}
