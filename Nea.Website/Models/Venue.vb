Imports System.ComponentModel.DataAnnotations
'Defines data types
Public Class Venue
    Inherits NamedEntity

    <Required>
    <Range(1, 26)>
    Public Property NumberOfRows As Integer

    <Required>
    <Range(1, 100)>
    Public Property SeatsPerRow As Integer

    <Required>
    <Range(1, Integer.MaxValue)>
    Public Property PriceBandAFirstRow As Integer

    <Required>
    <Range(1, Integer.MaxValue)>
    Public Property PriceBandBFirstRow As Integer

    <Required>
    <Range(1, Integer.MaxValue)>
    Public Property PriceBandCFirstRow As Integer
End Class
