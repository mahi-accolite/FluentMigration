using FluentMigrator;

namespace Test.Migrations;

[Migration(20240820151500)]
public class AddLogTable : Migration
{
    public override void Up()
    {
        Create
            .Table("Log")
            .WithColumn("Id")
            .AsInt32()
            .PrimaryKey()
            .Identity()
            .WithColumn("Text")
            .AsString();
    }

    public override void Down()
    {
        Delete.Table("Log");
    }
}
