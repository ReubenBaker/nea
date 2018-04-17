Imports System.ComponentModel.DataAnnotations

Public Class Ticket
    Inherits Entity

    <Required>
    Public Property Seat As Seat
End Class