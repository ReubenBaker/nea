Imports System.ComponentModel.DataAnnotations

Public Class BookingViewModel
    Public Property BookingId As Integer

    Public Property Venue As Venue

    Public Property AllocatedSeats As List(Of BookingSeat)

    Public Property ChosenSeatsCsv As String

    Public Property BandAPrice As Decimal

    Public Property BandBPrice As Decimal

    Public Property BandCPrice As Decimal

    Public Property CreditCardNumber As String

    <MinLength(3)>
    <MaxLength(4)>
    Public Property CvvNumber As String

    <MinLength(2)>
    <MaxLength(2)>
    <Range(1, 12)>
    Public Property ExpiryMonth As Integer

    <MinLength(4)>
    <MaxLength(4)>
    <Range(2018, 2022)>
    Public Property ExpiryYear As Integer
End Class