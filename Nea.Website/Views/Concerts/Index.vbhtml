@ModelType IEnumerable(Of Nea.Website.Concert)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
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
            @Html.DisplayNameFor(Function(model) model.CreatedUtc)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Timestamp)
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
            @Html.DisplayFor(Function(modelItem) item.CreatedUtc)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Timestamp)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
