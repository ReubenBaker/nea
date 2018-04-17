@ModelType IEnumerable(Of Nea.Website.Booking)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.BookingMadeUtc)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Timestamp)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.BookingMadeUtc)
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
