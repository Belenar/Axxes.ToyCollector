using FluentMigrator;

namespace Axxes.ToyCollector.Plugins.Lego.DataAccess.ModuleMigrations
{
    [Migration(20181111202001)]
    public class AddLegoSetFields : Migration
    {
        public override void Up()
        {
            Alter.Table("Toys").InSchema("dbo")
                .AddColumn("SetNumber").AsAnsiString(15).Nullable()
                .AddColumn("Unopened").AsBoolean().Nullable()
                .AddColumn("FinishedBuildDate").AsDate().Nullable()
                .AddColumn("LimitedEdition").AsBoolean().Nullable();
        }

        public override void Down()
        {
            Delete.Column("LimitedEdition").FromTable("Toys").InSchema("dbo");
            Delete.Column("FinishedBuildDate").FromTable("Toys").InSchema("dbo");
            Delete.Column("Unopened").FromTable("Toys").InSchema("dbo");
            Delete.Column("SetNumber").FromTable("Toys").InSchema("dbo");
        }
    }
}
