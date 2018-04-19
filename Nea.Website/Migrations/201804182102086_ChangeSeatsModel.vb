Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ChangeSeatsModel
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.BookingSeats",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .BookingId = c.Int(nullable := False),
                        .Row = c.String(nullable := False),
                        .NumberInRow = c.Int(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion")
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Bookings", Function(t) t.BookingId, cascadeDelete := True) _
                .Index(Function(t) t.BookingId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.BookingSeats", "BookingId", "dbo.Bookings")
            DropIndex("dbo.BookingSeats", New String() { "BookingId" })
            DropTable("dbo.BookingSeats")
        End Sub
    End Class
End Namespace
