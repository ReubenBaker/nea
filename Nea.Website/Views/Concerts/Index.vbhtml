@ModelType IEnumerable(Of Nea.Website.Concert)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Currently available concerts</h2>

<p>
    @If User.IsInRole("admin") Then
        @Html.ActionLink("Create New", "Create")
    End If
</p>
<Table Class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Band.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Venue.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Time)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BandAPrice)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BandBPrice)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.BandCPrice)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Band.Name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Venue.Name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Time)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.BandAPrice)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.BandBPrice)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.BandCPrice)
            </td>
            <td>
                @Html.ActionLink("Details", "Details", New With {.id = item.Id})
                @If User.IsInRole("admin") Then
                    @<span>|</span>
                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id})
                    @<span>|</span>
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                End If
                <span>|</span>
                @Html.ActionLink("Book", "Book", New With {.id = item.Id})
            </td>
        </tr>
    Next

</Table>
