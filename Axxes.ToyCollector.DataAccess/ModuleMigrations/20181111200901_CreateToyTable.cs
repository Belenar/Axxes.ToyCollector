using FluentMigrator;

namespace Axxes.ToyCollector.DataAccess.ModuleMigrations
{
    [Migration(20181111200901)]
    public class CreateToyTable : Migration
    {
        public override void Up()
        {
            Create.Table("Toys").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Description").AsAnsiString(250).Nullable()
                .WithColumn("Discriminator").AsString(int.MaxValue).NotNullable()
                .WithColumn("AcquiredDate").AsDate().NotNullable()
                .WithColumn("AcquiredCondition").AsInt32().NotNullable()
                .WithColumn("CurrentCondition").AsInt32().NotNullable()
                .WithColumn("DiscontinuedDate").AsDateTime2().Nullable()
                .WithColumn("Msrp").AsDecimal(18, 2).Nullable();
        }

        public override void Down()
        {
            Delete.Table("Toys").InSchema("dbo");
        }
    }
}
