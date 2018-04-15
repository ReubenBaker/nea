@ModelType Nea.Website.Venue
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Venue</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.NumberOfRows)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NumberOfRows)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SeatsPerRow)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SeatsPerRow)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
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
