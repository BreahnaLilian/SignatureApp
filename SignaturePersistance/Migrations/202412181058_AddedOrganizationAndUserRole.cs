using FluentMigrator;

namespace SignaturePersistance.Migrations;

[Migration(202412181058)]
public class _202412181058_AddedOrganizationAndUserRole : Migration 
{
    public override void Up()
    {
        Create.Column("Role").OnTable("Users").AsInt32().Nullable();
        Create.Column("OrganizationId").OnTable("Users").AsGuid().Nullable();
        
        CreateIdentityColumnTable("Organizations");
        Create.Column("IDNO").OnTable("Organizations").AsString(13).NotNullable();
        Create.Column("CommercialName").OnTable("Organizations").AsString(50).NotNullable();
        Create.Column("JuridicalName").OnTable("Organizations").AsString(50).NotNullable();
        Create.Column("JuridicalAddress").OnTable("Organizations").AsString(100).NotNullable();
        Create.Column("Status").OnTable("Organizations").AsString().NotNullable();
        Create.Column("PhoneNumber").OnTable("Organizations").AsString(8).NotNullable();
        Create.Column("ApiKey").OnTable("Organizations").AsString().Nullable();
        CreateAuditableColumns("Organizations");
        
        Create.ForeignKey("FK_Users_OrganizationId_Organizations_Id")
            .FromTable("Users").ForeignColumn("OrganizationId")
            .ToTable("Organizations").PrimaryColumn("Id");
        
        Insert.IntoTable("Organizations").Row(new
        { 
            Id = new Guid("38284448-d96a-426f-9088-c5980fcd68e4"), 
            IDNO = "0000000000001", 
            CommercialName = "LVBGroup", 
            JuridicalName = "LVBGroup", 
            JuridicalAddress = "Address1 Ap.1", 
            Status = 1, 
            PhoneNumber = "69000001", 
            CreateDate = DateTime.Now,
        });

        Delete.FromTable("Users").Row(new { Id = new Guid("89990cf6-e9d9-49c5-a86d-199e815a7739") });
        Delete.FromTable("Users").Row(new { Id = new Guid("743be124-595f-4880-a2db-d657e5dd86c2") });
        
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
            CreateDate = DateTime.Now,
            OrganizationId = new Guid("38284448-d96a-426f-9088-c5980fcd68e4")
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
            CreateDate = DateTime.Now,
            OrganizationId = new Guid("38284448-d96a-426f-9088-c5980fcd68e4")
        });
    }

    public override void Down()
    {
        Delete.FromTable("Users").Row(new { Id = new Guid("89990cf6-e9d9-49c5-a86d-199e815a7739") });
        Delete.FromTable("Users").Row(new { Id = new Guid("743be124-595f-4880-a2db-d657e5dd86c2") });

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
        
        Delete.ForeignKey("FK_Users_OrganizationId_Organizations_Id")
            .OnTable("Users");
        
        Delete.Table("Organizations");
        
        Delete.Column("OrganizationId").FromTable("Users");
        Delete.Column("Role").FromTable("Users");
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