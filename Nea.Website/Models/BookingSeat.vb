Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
'Defines data types
Public Class BookingSeat
    Inherits Entity

    <Required>
    Public Property BookingId As Integer
    <ForeignKey("BookingId")>
    Public Property Booking As Booking

    <Required>
    Public Property Row As Integer

    <Required>
    Public Property NumberInRow As Integer
End Class