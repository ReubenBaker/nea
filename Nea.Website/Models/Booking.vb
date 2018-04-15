Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Booking
    Inherits Entity

    <Required>
    Public Property BookingMadeUtc As DateTime

    <Required>
    Public Property CustomerId As Integer
    <ForeignKey("CustomerId")>
    Public Property Customer As Customer

    Public Overridable Property Tickets As List(Of Ticket)

    Public Overridable Property Payments As List(Of Payment)

    Public Overridable Property Refunds As List(Of Refund)
End Class