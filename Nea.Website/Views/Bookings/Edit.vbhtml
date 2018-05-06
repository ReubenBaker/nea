@ModelType Nea.Website.BookingViewModel
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">

        <script language="javascript">
            function CollectNewChosenSeats() {
                var chosen = [];
                $("span").each(function () {
                    if ($(this).hasClass("chosen")) {
                        chosen.push("(" + $(this).attr('id') + ")");
                    }
                });

                $("input[type=hidden][name=ChosenSeatsCsv]").val(chosen.join(","));
            }
        </script>

        <h4>Booking</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.Booking.Id)
        @Html.HiddenFor(Function(model) model.Booking.UserName)
        @Html.HiddenFor(Function(model) model.Booking.BookingMadeUtc)
        @Html.HiddenFor(Function(model) model.ChosenSeatsCsv)

        @* A5,F3 *@

        <div Class="form-group">
            <table>
                @For row As Integer = 1 To Model.Venue.NumberOfRows
                    @<tr>
                        @For col As Integer = 1 To Model.Venue.SeatsPerRow
                            Dim reserved As Boolean = Model.AllocatedSeats.Any(Function(s) s.Row = row And s.NumberInRow = col)
                            @<td>
                                <div class="col-md-offset-2@(If(reserved, " reserved", ""))">
                                    <span id="@(row & "," & col)" class="btn btn-default@(If(reserved, " reserved", ""))" onclick="@(If(reserved, "", "$(this).toggleClass('chosen')"))">
                                        @(Chr(Asc("A") + row - 1) & col)
                                    </span>
                                </div>
                            </td>
                        Next
                    </tr>
                Next
            </table>
        </div>

        <div Class="form-group">
            <div Class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" Class="btn btn-default" onclick="CollectNewChosenSeats(); return true;" />
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
