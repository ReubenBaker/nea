Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ChangeBookingSeatRowFromStringToInteger
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.BookingSeats", "Row", Function(c) c.Int(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.BookingSeats", "Row", Function(c) c.String(nullable := False))
        End Sub
    End Class
End Namespace
