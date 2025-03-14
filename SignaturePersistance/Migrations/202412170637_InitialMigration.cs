using FluentMigrator;

namespace SignaturePersistance.Migrations;

[Migration(202412170637)]
public class _202412170637_InitialMigration : Migration
{
    public override void Up()
    {
        CreateIdentityColumnTable("Files");
        Create.Column("FileName").OnTable("Files").AsString(150).NotNullable();
        Create.Column("Path").OnTable("Files").AsString(1024).NotNullable();
        Create.Column("Size").OnTable("Files").AsInt32().NotNullable();
        Create.Column("Type").OnTable("Files").AsString(50).NotNullable();
        Create.Column("Commentary").OnTable("Files").AsString(1024).Nullable();
        Create.Column("Status").OnTable("Files").AsInt32().NotNullable();
        Create.Column("SignedBy").OnTable("Files").AsInt32().NotNullable();
        CreateAuditableColumns("Files");

        CreateIdentityColumnTable("Users");
        Create.Column("FirstName").OnTable("Users").AsString(50).NotNullable();
        Create.Column("LastName").OnTable("Users").AsString(50).NotNullable();
        Create.Column("Email").OnTable("Users").AsString(50).NotNullable();
        Create.Column("PhoneNumber").OnTable("Users").AsString(8).NotNullable();
        Create.Column("IDNP").OnTable("Users").AsString(14).NotNullable();
        Create.Column("Password").OnTable("Users").AsString(100).NotNullable();
        Create.Column("DateOfBirth").OnTable("Users").AsDateTime2().NotNullable();
        Create.Column("Gender").OnTable("Users").AsInt32().NotNullable();
        Create.Column("Address").OnTable("Users").AsString(50).NotNullable();
        Create.Column("Status").OnTable("Users").AsInt32().NotNullable();
        CreateAuditableColumns("Users");

        Create.Table("SignatureFilesToUsers")
            .WithColumn("UserId").AsGuid().NotNullable()
            .WithColumn("FileId").AsGuid().NotNullable();
        
        Create.ForeignKey("FK_SignatureFilesToUsers_FileId_Files_Id")
            .FromTable("SignatureFilesToUsers").ForeignColumn("FileId")
            .ToTable("Files").PrimaryColumn("Id");
        
        Create.ForeignKey("FK_SignatureFilesToUsers_FileId_Users_Id")
            .FromTable("SignatureFilesToUsers").ForeignColumn("UserId")
            .ToTable("Users").PrimaryColumn("Id");
        
        Insert.IntoTable("Users").Row(new
            { 
                Id = new Guid("89990cf6-e9d9-49c5-a86d-199e815a7739"), 
                FirstName = "Admin", 
                LastName = "Admin", 
                Email = "admin@lvbgroup.com", 
                PhoneNumber = "69000001", 
                IDNP = "0000000000001", 
                Password = "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", 
                DateOfBirth = DateTime.Now, 
                Gender = 0, 
                Address = "Planet Earth", 
                Status = 1, 
                CreateDate = DateTime.Now
            });
        
        Insert.IntoTable("Users").Row(new
            { 
                Id = new Guid("743be124-595f-4880-a2db-d657e5dd86c2"), 
                FirstName = "User", 
                LastName = "User", 
                Email = "user@lvbgroup.com", 
                PhoneNumber = "69000002", 
                IDNP = "0000000000002", 
                Password = "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", 
                DateOfBirth = DateTime.Now, 
                Gender = 0, 
                Address = "Planet Earth", 
                Status = 1, 
                CreateDate = DateTime.Now
            });
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_SignatureFilesToUsers_FileId_Users_Id")
            .OnTable("SignatureFilesToUsers");
        
        Delete.ForeignKey("FK_SignatureFilesToUsers_FileId_Files_Id")
            .OnTable("SignatureFilesToUsers");
        
        Delete.Table("SignatureFilesToUsers");
        Delete.Table("Users");
        Delete.Table("Files");
    }
    
    public void CreateIdentityColumnTable(string Name)
    {
        Create.Table(Name)
            .WithColumn("Id").AsGuid().PrimaryKey();
    }

    public void CreateAuditableColumns(string Name)
    {
        Create.Column("CreateDate").OnTable(Name).AsDateTime().NotNullable();
        Create.Column("LastModified").OnTable(Name).AsDateTime().Nullable();
    }
}