@ModelType Nea.Website.Booking
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Booking</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.BookingMadeUtc)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BookingMadeUtc)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Timestamp)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Timestamp)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
