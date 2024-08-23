using FluentMigrator;

namespace Test.Migrations;

[Migration(20240820193000)]
public class UpdateUserTable2 : Migration
{
    public override void Up()
    {
        Insert
            .IntoTable("Users2")
            .Row(
                new
                {
                    Id = 2,
                    UserName = "Mishra"                 
                }
            );
    }

    public override void Down()
    {
        Delete.FromTable("Users2").AllRows();
    }
}
