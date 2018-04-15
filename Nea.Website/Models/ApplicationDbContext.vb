﻿Imports System.Data.Entity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function

    Public Property Concerts As DbSet(Of Concert)
    Public Property Bands As DbSet(Of Band)
    Public Property Venues As DbSet(Of Venue)
    Public Property Tickets As DbSet(Of Ticket)
    Public Property Customers As DbSet(Of Customer)
    Public Property Bookings As DbSet(Of Booking)
    Public Property Payments As DbSet(Of Payment)
    Public Property Pricings As DbSet(Of Pricing)
    Public Property Refunds As DbSet(Of Refund)
End Class