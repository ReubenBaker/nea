@ModelType Nea.Website.Concert
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
            @Html.DisplayNameFor(Function(model) model.BandAPrice)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BandAPrice)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BandBPrice)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BandBPrice)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.BandCPrice)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.BandCPrice)
        </dd>
    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
