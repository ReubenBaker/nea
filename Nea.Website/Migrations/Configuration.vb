Imports System.Data.Entity.Migrations

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of ApplicationDbContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
            ContextKey = "Nea.Website.ApplicationDbContext"
        End Sub

        Protected Overrides Sub Seed(context As ApplicationDbContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})

            context.Bands.AddOrUpdate(
                Function(c) c.Id,
                New Band() With {.Name = "U2"},
                New Band() With {.Name = "Avenged Sevenfold"},
                New Band() With {.Name = "Muse"})
            context.Venues.AddOrUpdate(
                Function(c) c.Id,
                New Venue() With {.Name = "O2", .NumberOfRows = 26, .SeatsPerRow = 100, .PriceBandAFirstRow = 1, .PriceBandBFirstRow = 10, .PriceBandCFirstRow = 18},
                New Venue() With {.Name = "G-Live", .NumberOfRows = 5, .SeatsPerRow = 22, .PriceBandAFirstRow = 1, .PriceBandBFirstRow = 3, .PriceBandCFirstRow = 5})
        End Sub

    End Class

End Namespace
