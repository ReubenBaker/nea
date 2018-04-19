Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Booking
    Inherits Entity

    <Required>
    Public Property ConcertId As Integer
    <ForeignKey("ConcertId")>
    Public Property Concert As Concert

    <Required>
    Public Property BookingMadeUtc As DateTime

    <Required>
    Public Property UserName As String

    Public Overridable Property Seats As List(Of BookingSeat)

    Public Overridable Property Payments As List(Of Payment)

    Public Overridable Property Refunds As List(Of Refund)
End Class