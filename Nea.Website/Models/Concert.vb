Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Concert
    Inherits Entity

    <Required>
    Public Property Time As DateTime

    <Required>
    <DisplayName("Band")>
    Public Property BandId As Integer
    <ForeignKey("BandId")>
    Public Property Band As Band

    <Required>
    <DisplayName("Venue")>
    Public Property VenueId As Integer
    <ForeignKey("VenueId")>
    Public Property Venue As Venue
End Class
