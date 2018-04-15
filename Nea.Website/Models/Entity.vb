Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class Entity
    <Key>
    <Required>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property Id As Integer

    <Required>
    <HiddenInput(DisplayValue:=False)>
    Public Property CreatedUtc As DateTime

    <Timestamp>
    Public Property Timestamp As Byte()

    Public Sub New()
        CreatedUtc = DateTime.UtcNow
    End Sub
End Class
