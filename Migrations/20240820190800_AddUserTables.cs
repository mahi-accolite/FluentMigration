using FluentMigrator;

namespace Test.Migrations;

[Migration(20240820190800)]
public class AddUserTables : Migration
{
    public override void Up()
    {
        Create
            .Table("Users1")
            .WithColumn("Id")
            .AsInt32()
            .PrimaryKey()
            .Identity()
            .WithColumn("Name")
            .AsString(255)
            .NotNullable()
            .WithDefaultValue("Anonymous");

        Create
            .Table("Users2")
            .WithColumn("Id")
            .AsInt32()
            .PrimaryKey()
            .Identity()
            .WithColumn("UserName")
            .AsString(255)
            .NotNullable()
            .WithDefaultValue("Anonymous")            ;
    }

    public override void Down()
    {
        Delete.Table("Users1");
        Delete.Table("Users2");
    }
}
