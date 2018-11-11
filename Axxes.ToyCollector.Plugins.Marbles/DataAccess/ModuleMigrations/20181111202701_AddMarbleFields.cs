using FluentMigrator;

namespace Axxes.ToyCollector.Plugins.Marbles.DataAccess.ModuleMigrations
{
    [Migration(20181111202701)]
    public class AddMarbleFields : Migration
    {
        public override void Up()
        {
            Alter.Table("Toys").InSchema("dbo")
                .AddColumn("Diameter").AsInt32().Nullable()
                .AddColumn("Transparent").AsBoolean().Nullable();
        }

        public override void Down()
        {
            Delete.Column("Transparent").FromTable("Toys").InSchema("dbo");
            Delete.Column("Diameter").FromTable("Toys").InSchema("dbo");
        }
    }
}
