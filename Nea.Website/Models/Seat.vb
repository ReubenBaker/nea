Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<ComplexType>
Public Class Seat
    <Required>
    Public Property Row As String

    <Required>
    Public Property NumberInRow As Integer
End Class