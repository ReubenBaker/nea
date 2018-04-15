Imports System.ComponentModel.DataAnnotations

Public Class Pricing
    Inherits Entity

    <Required>
    Public Property Row As Integer

    <Required>
    Public Property Price As Decimal
End Class
