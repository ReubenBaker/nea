Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class BookingSeat
    Inherits Entity

    <Required>
    Public Property BookingId As Integer
    <ForeignKey("BookingId")>
    Public Property Booking As Booking

    <Required>
    Public Property Row As String

    <Required>
    Public Property NumberInRow As Integer
End Class