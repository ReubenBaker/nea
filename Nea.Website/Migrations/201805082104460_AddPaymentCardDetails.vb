Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddPaymentCardDetails
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Payments", "CreditCardNumber", Function(c) c.String())
            AddColumn("dbo.Payments", "CvvNumber", Function(c) c.String())
            AddColumn("dbo.Payments", "ExpiryDate", Function(c) c.DateTime(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Payments", "ExpiryDate")
            DropColumn("dbo.Payments", "CvvNumber")
            DropColumn("dbo.Payments", "CreditCardNumber")
        End Sub
    End Class
End Namespace
