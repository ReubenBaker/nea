Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class MoveConcertFromTicketToBooking
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Tickets", "ConcertId", "dbo.Concerts")
            DropIndex("dbo.Tickets", New String() { "ConcertId" })
            AddColumn("dbo.Bookings", "ConcertId", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.Bookings", "ConcertId")
            AddForeignKey("dbo.Bookings", "ConcertId", "dbo.Concerts", "Id", cascadeDelete := True)
            DropColumn("dbo.Tickets", "ConcertId")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Tickets", "ConcertId", Function(c) c.Int(nullable := False))
            DropForeignKey("dbo.Bookings", "ConcertId", "dbo.Concerts")
            DropIndex("dbo.Bookings", New String() { "ConcertId" })
            DropColumn("dbo.Bookings", "ConcertId")
            CreateIndex("dbo.Tickets", "ConcertId")
            AddForeignKey("dbo.Tickets", "ConcertId", "dbo.Concerts", "Id", cascadeDelete := True)
        End Sub
    End Class
End Namespace
