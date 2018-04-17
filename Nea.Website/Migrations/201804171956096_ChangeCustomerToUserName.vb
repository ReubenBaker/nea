Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ChangeCustomerToUserName
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers")
            DropIndex("dbo.Bookings", New String() { "CustomerId" })
            DropIndex("dbo.Customers", New String() { "Name" })
            AddColumn("dbo.Bookings", "UserName", Function(c) c.String(nullable := False))
            DropColumn("dbo.Bookings", "CustomerId")
            DropTable("dbo.Customers")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.Customers",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(nullable := False, maxLength := 100),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion")
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            AddColumn("dbo.Bookings", "CustomerId", Function(c) c.Int(nullable := False))
            DropColumn("dbo.Bookings", "UserName")
            CreateIndex("dbo.Customers", "Name", unique := True)
            CreateIndex("dbo.Bookings", "CustomerId")
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers", "Id", cascadeDelete := True)
        End Sub
    End Class
End Namespace
