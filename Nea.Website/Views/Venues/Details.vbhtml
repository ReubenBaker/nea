﻿@ModelType Nea.Website.Venue
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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
