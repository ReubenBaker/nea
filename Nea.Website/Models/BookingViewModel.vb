Imports System.ComponentModel.DataAnnotations

Public Class BookingViewModel
    Public Property BookingId As Integer

    Public Property Venue As Venue

    Public Property AllocatedSeats As List(Of BookingSeat)

    Public Property ChosenSeatsCsv As String

    Public Property BandAPrice As Decimal

    Public Property BandBPrice As Decimal

    Public Property BandCPrice As Decimal

    <CreditCard>
    Public Property CreditCardNumber As String

    <MinLength(3)>
    <MaxLength(4)>
    <RegularExpression("\d{3,4}")>
    Public Property CvvNumber As String

    Public Property ExpiryMonth As Integer

    Public Property ExpiryYear As Integer
End Class