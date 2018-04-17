@ModelType IEnumerable(Of Nea.Website.Band)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @If User.IsInRole("admin") Then
        @Html.ActionLink("Create New", "Create")
    End If
</p>
<Table Class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Name)
            </td>
            <td>
                @Html.ActionLink("Details", "Details", New With {.id = item.Id})
                @If User.IsInRole("admin") Then
                    @<span>|</span>
                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id})
                    @<span>|</span>
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                End If
            </td>
        </tr>
    Next

</Table>
