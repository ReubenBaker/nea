Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class NamedEntity
    Inherits Entity

    <MinLength(2)>
    <MaxLength(100)>
    <Required>
    <Index(IsUnique:=True)>
    Public Property Name As String
End Class