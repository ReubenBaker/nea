@ModelType IEnumerable(Of Nea.Website.Venue)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Venues</h2>

<p>
    @If User.IsInRole("admin") Then
        @Html.ActionLink("Create New", "Create")
    End If
</p>
<Table Class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.NumberOfRows)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SeatsPerRow)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PriceBandAFirstRow)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PriceBandBFirstRow)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PriceBandCFirstRow)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.NumberOfRows)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SeatsPerRow)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PriceBandAFirstRow)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PriceBandBFirstRow)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.PriceBandCFirstRow)
            </td>
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
