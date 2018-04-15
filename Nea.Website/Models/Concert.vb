Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Concert
    Inherits Entity

    <Required>
    Public Property Time As DateTime

    <Required>
    Public Property BandId As Integer
    <ForeignKey("BandId")>
    Public Property Band As Band

    <Required>
    Public Property VenueId As Integer
    <ForeignKey("VenueId")>
    Public Property Venue As Venue

    <Required>
    <Range(1, Integer.MaxValue)>
    Public Property BandAPrice As Decimal

    <Required>
    <Range(1, Integer.MaxValue)>
    Public Property BandBPrice As Decimal

    <Required>
    <Range(1, Integer.MaxValue)>
    Public Property BandCPrice As Decimal
End Class