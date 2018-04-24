@ModelType Nea.Website.BookingViewModel
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">

    <h4>Booking</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.Booking.Id)
    @Html.HiddenFor(Function(model) model.Booking.UserName)
    @Html.HiddenFor(Function(model) model.Booking.BookingMadeUtc)
    @Html.HiddenFor(Function(model) model.ChosenSeatsCsv)

    <div Class="form-group">
        <table>
            @For row As Integer = 1 To Model.Venue.NumberOfRows
                @<tr>
                    @For col As Integer = 1 To Model.Venue.SeatsPerRow
                        @<td>
                            <div Class="col-md-offset-2@(If(Model.AllocatedSeats.Any(Function(s) s.Row = row And s.NumberInRow = col), " reserved", ""))">
                                <span Class="btn btn-default@(If(Model.AllocatedSeats.Any(Function(s) s.Row = row And s.NumberInRow = col), " reserved", ""))"
                                      onclick="$( "input[type=hidden][name=Stuff]" ).val('def');">
                                    @(Chr(Asc("A") + row - 1) & col)
                                </span>
                            </div>
                        </td>
                    Next
                </tr>
            Next
        </table>
    </div>

    @Model.AllocatedSeats.Count


    <div Class="form-group">
        <div Class="col-md-offset-2 col-md-10">
            <input type="submit" value="Save" Class="btn btn-default" />
        </div>
    </div>
</div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
