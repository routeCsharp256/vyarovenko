using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(8)]
    public class EmployeeTable : Migration 
    {
        public override void Up()
        {
            Create.Table("employees")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("clouthing_size_id").AsInt32()
                .WithColumn("email").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("employees");
        }
    }
}
