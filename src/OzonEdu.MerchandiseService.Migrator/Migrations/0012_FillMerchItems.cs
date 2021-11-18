using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(12)]
    public class FillMerchItems : ForwardOnlyMigration
    {
        public override void Up()
        {
            // add TShirts
            Execute.Sql(@"
                INSERT INTO merch_items (id, name, item_type_id, clouthing_size_id, sku_id)
                VALUES 
                    (1, 'TShirt XS', 1, 1, 1),
                    (2, 'TShirt S', 1, 2, 2),
                    (3, 'TShirt M', 1, 3, 3),
                    (4, 'TShirt L', 1, 4, 4),
                    (5, 'TShirt XL', 1, 5, 5),
                    (6, 'TShirt XXL', 1, 6, 6)
                ON CONFLICT DO NOTHING
            ");
            // add Sweatshirt
            Execute.Sql(@"
                INSERT INTO merch_items (id, name, item_type_id, clouthing_size_id, sku_id)
                VALUES 
                    (7, 'Sweatshirt XS', 2, 1, 7),
                    (8, 'Sweatshirt S', 2, 2, 8),
                    (9, 'Sweatshirt M', 2, 3, 9),
                    (10, 'Sweatshirt L', 2, 4, 10),
                    (11, 'Sweatshirt XL', 2, 5, 11),
                    (12, 'Sweatshirt XXL', 2, 6, 12)
                ON CONFLICT DO NOTHING
            ");
            // add Other
            Execute.Sql(@"
                INSERT INTO merch_items (id, name, item_type_id, clouthing_size_id, sku_id)
                VALUES 
                    (13, 'Notepad', 3, 0, 13),
                    (14, 'Bag', 4, 0, 14),
                    (15, 'Pen', 5, 0, 15),
                    (16, 'Socks', 6, 0, 16)
                ON CONFLICT DO NOTHING
            ");
        }
    }
}
//(1, 'TShirt'),
//(2, 'Sweatshirt'),
//(3, 'Notepad'),
//(4, 'Bag'),
//(5, 'Pen'),
//(6, 'Socks')

//(1, 'XS'),
//(2, 'S'),
//(3, 'M'),
//(4, 'L'),
//(5, 'XL'),
//(6, 'XXL')
