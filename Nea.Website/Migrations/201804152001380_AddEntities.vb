Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddEntities
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Bands",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(nullable := False, maxLength := 100),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion")
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .Index(Function(t) t.Name, unique := True)
            
            CreateTable(
                "dbo.Bookings",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .BookingMadeUtc = c.DateTime(nullable := False),
                        .CustomerId = c.Int(nullable := False),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion")
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Customers", Function(t) t.CustomerId, cascadeDelete := True) _
                .Index(Function(t) t.CustomerId)
            
            CreateTable(
                "dbo.Customers",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(nullable := False, maxLength := 100),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion")
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .Index(Function(t) t.Name, unique := True)
            
            CreateTable(
                "dbo.Payments",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Amount = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion"),
                        .Booking_Id = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Bookings", Function(t) t.Booking_Id) _
                .Index(Function(t) t.Booking_Id)
            
            CreateTable(
                "dbo.Refunds",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Amount = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion"),
                        .Booking_Id = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Bookings", Function(t) t.Booking_Id) _
                .Index(Function(t) t.Booking_Id)
            
            CreateTable(
                "dbo.Tickets",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .ConcertId = c.Int(nullable := False),
                        .Seat_Row = c.String(nullable := False),
                        .Seat_NumberInRow = c.Int(nullable := False),
                        .Price = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion"),
                        .Booking_Id = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Concerts", Function(t) t.ConcertId, cascadeDelete := True) _
                .ForeignKey("dbo.Bookings", Function(t) t.Booking_Id) _
                .Index(Function(t) t.ConcertId) _
                .Index(Function(t) t.Booking_Id)
            
            CreateTable(
                "dbo.Concerts",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Time = c.DateTime(nullable := False),
                        .BandId = c.Int(nullable := False),
                        .VenueId = c.Int(nullable := False),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion")
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Bands", Function(t) t.BandId, cascadeDelete := True) _
                .ForeignKey("dbo.Venues", Function(t) t.VenueId, cascadeDelete := True) _
                .Index(Function(t) t.BandId) _
                .Index(Function(t) t.VenueId)
            
            CreateTable(
                "dbo.Venues",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .NumberOfRows = c.Int(nullable := False),
                        .SeatsPerRow = c.Int(nullable := False),
                        .Name = c.String(nullable := False, maxLength := 100),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion")
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .Index(Function(t) t.Name, unique := True)
            
            CreateTable(
                "dbo.Pricings",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Row = c.Int(nullable := False),
                        .Price = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .CreatedUtc = c.DateTime(nullable := False),
                        .Timestamp = c.Binary(nullable := False, fixedLength := true, timestamp := True, storeType := "rowversion")
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Tickets", "Booking_Id", "dbo.Bookings")
            DropForeignKey("dbo.Tickets", "ConcertId", "dbo.Concerts")
            DropForeignKey("dbo.Concerts", "VenueId", "dbo.Venues")
            DropForeignKey("dbo.Concerts", "BandId", "dbo.Bands")
            DropForeignKey("dbo.Refunds", "Booking_Id", "dbo.Bookings")
            DropForeignKey("dbo.Payments", "Booking_Id", "dbo.Bookings")
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers")
            DropIndex("dbo.Venues", New String() { "Name" })
            DropIndex("dbo.Concerts", New String() { "VenueId" })
            DropIndex("dbo.Concerts", New String() { "BandId" })
            DropIndex("dbo.Tickets", New String() { "Booking_Id" })
            DropIndex("dbo.Tickets", New String() { "ConcertId" })
            DropIndex("dbo.Refunds", New String() { "Booking_Id" })
            DropIndex("dbo.Payments", New String() { "Booking_Id" })
            DropIndex("dbo.Customers", New String() { "Name" })
            DropIndex("dbo.Bookings", New String() { "CustomerId" })
            DropIndex("dbo.Bands", New String() { "Name" })
            DropTable("dbo.Pricings")
            DropTable("dbo.Venues")
            DropTable("dbo.Concerts")
            DropTable("dbo.Tickets")
            DropTable("dbo.Refunds")
            DropTable("dbo.Payments")
            DropTable("dbo.Customers")
            DropTable("dbo.Bookings")
            DropTable("dbo.Bands")
        End Sub
    End Class
End Namespace
