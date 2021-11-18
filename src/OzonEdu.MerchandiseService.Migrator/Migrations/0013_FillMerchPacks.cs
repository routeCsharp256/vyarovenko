using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(13)]
    public class FillMerchPacks : ForwardOnlyMigration 
    {
        public override void Up()
        {
            Execute.Sql(@"
            INSERT INTO merch_packs
            (id, name)
            VALUES
                (10,'Welcome pack'),
                (20,'Conference Listener Pack'),
                (30,'Conference Speaker Pack'),
                (40,'Probation Period Ending Pack'),
                (50,'Veteran Pack')
            ON CONFLICT DO NOTHING");
        }
    }
}
