﻿@ModelType Nea.Website.Venue
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
            @Html.DisplayNameFor(Function(model) model.PriceBandAFirstRow)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PriceBandAFirstRow)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PriceBandBFirstRow)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PriceBandBFirstRow)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PriceBandCFirstRow)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PriceBandCFirstRow)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
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
