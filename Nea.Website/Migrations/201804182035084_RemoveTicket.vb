Imports System.Data.Entity.Migrations

Namespace Migrations
    Partial Public Class RemoveTicket
        Inherits DbMigration

        Public Overrides Sub Up()
            DropForeignKey("dbo.Tickets", "Booking_Id", "dbo.Bookings")
            DropIndex("dbo.Tickets", New String() {"Booking_Id"})
            DropTable("dbo.Tickets")
        End Sub

        Public Overrides Sub Down()
            CreateTable(
                "dbo.Tickets",
                Function(c) New With
                    {
                        .Id = c.Int(nullable:=False, identity:=True),
                        .Seat_Row = c.String(nullable:=False),
                        .Seat_NumberInRow = c.Int(nullable:=False),
                        .Timestamp = c.Binary(nullable:=False, fixedLength:=True, timestamp:=True, storeType:="rowversion"),
                        .Booking_Id = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.Id)

            CreateIndex("dbo.Tickets", "Booking_Id")
            AddForeignKey("dbo.Tickets", "Booking_Id", "dbo.Bookings", "Id")
        End Sub
    End Class
End Namespace
