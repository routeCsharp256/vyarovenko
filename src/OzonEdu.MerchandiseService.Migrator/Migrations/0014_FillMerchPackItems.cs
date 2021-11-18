using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(14)]
    public class FillMerchPackItems : ForwardOnlyMigration
    {
        public override void Up()
        {
            // add Welcome pack items
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_type_id, quantity)
            VALUES
                (10,1,1),
                (10,3,2),
                (10,5,1)
            ON CONFLICT DO NOTHING");

            // add Conference Listener Pack items
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_type_id, quantity)
            VALUES
                (20,3,1),
                (20,5,1)
            ON CONFLICT DO NOTHING");

            // add Conference Speaker Pack items
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_type_id, quantity)
            VALUES
                (30,1,1),
                (30,2,1),
                (30,3,1),
                (30,5,1)
            ON CONFLICT DO NOTHING");

            // add Probation Period Ending Pack items
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_type_id, quantity)
            VALUES
                (40,1,1),
                (40,3,3),
                (40,4,1),
                (40,5,2),
                (40,6,3)
            ON CONFLICT DO NOTHING");

            // add Veteran Pack items
            Execute.Sql(@"
            INSERT INTO merch_pack_items
            (pack_id, merch_type_id, quantity)
            VALUES
                (50,1,3),
                (50,2,2),
                (50,4,3),
                (50,3,3),
                (50,5,5),
                (50,6,10)
            ON CONFLICT DO NOTHING");
        }
    }
}
//(10, 'Welcome pack'),
//(20, 'Conference Listener Pack'),
//(30, 'Conference Speaker Pack'),
//(40, 'Probation Period Ending Pack'),
//(50, 'Veteran Pack')

//(1, 'TShirt'),
//(2, 'Sweatshirt'),
//(3, 'Notepad'),
//(4, 'Bag'),
//(5, 'Pen'),
//(6, 'Socks')
