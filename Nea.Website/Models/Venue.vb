Imports System.ComponentModel.DataAnnotations

Public Class Venue
    Inherits NamedEntity

    <Required>
    <Range(1, 26)>
    Public Property NumberOfRows As Integer

    <Required>
    <Range(1, 100)>
    Public Property SeatsPerRow As Integer
End Class
