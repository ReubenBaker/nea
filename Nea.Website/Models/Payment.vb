Imports System.ComponentModel.DataAnnotations

Public Class Payment
    Inherits Entity

    <Required>
    Public Property Amount As Decimal

    Public Property CreditCardNumber As String

    Public Property CvvNumber As String

    Public Property ExpiryDate As DateTime
End Class
