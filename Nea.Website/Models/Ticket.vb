Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Ticket
    Inherits Entity

    <Required>
    Public Property ConcertId As Integer
    <ForeignKey("ConcertId")>
    Public Property Concert As Concert

    <Required>
    Public Property Seat As Seat

    <Required>
    Public Property Price As Decimal
End Class