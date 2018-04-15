@ModelType Nea.Website.Concert
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Concert</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Band.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Band.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Venue.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Venue.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Time)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Time)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreatedUtc)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreatedUtc)
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
