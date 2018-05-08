@ModelType Nea.Website.BookingViewModel
@Code
    ViewData("Title") = "Edit"

    Dim months As List(Of Integer) = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}.ToList()
    Dim years As List(Of Integer) = New List(Of Integer)
    For year As Integer = DateTime.Now.Year To DateTime.Now.Year + 3
        years.Add(year)
    Next

End Code

<h2>Edit</h2>

@Using (Html.BeginForm("Edit2", "Bookings"))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Booking</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.BookingId)
        @Html.HiddenFor(Function(model) model.ChosenSeatsCsv)
        @Html.HiddenFor(Function(model) model.Amount)

        <div Class="form-group">
            <table id="seatMap">
                @For row As Integer = 1 To Model.Venue.NumberOfRows
                    @<tr>
                        @For col As Integer = 1 To Model.Venue.SeatsPerRow
                            Dim reserved As Boolean = Model.AllocatedSeats.Any(Function(s) s.Row = row And s.NumberInRow = col)
                            Dim price As Decimal = If(row >= Model.Venue.PriceBandCFirstRow, Model.BandCPrice, If(row >= Model.Venue.PriceBandBFirstRow, Model.BandBPrice, Model.BandAPrice))
                            @<td>
                                <div class="col-md-offset-2@(If(reserved, " reserved", ""))">
                                    <span id="@(row & "-" & col)" price="@(price)" class="btn btn-default@(If(reserved, " reserved", ""))" onclick="@(If(reserved, "", "$(this).toggleClass('chosen'); CollectNewChosenSeats()"))">
                                        @(Chr(Asc("A") + row - 1) & col)<br />
                                        (£@(Int(price)))
                                    </span>
                                </div>
                            </td>
                        Next
                    </tr>
                Next
            </table>
        </div>

        <div Class="form-group">
            <table>
                <tr>
                    <td>
                        Total price:
                    </td>
                    <td>
                        <div class="">
                            <span id="chosenPrice" class="btn btn-default chosen">£0.00</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input id="acceptAndPay" type="button" value="Accept and Pay" Class="btn btn-default" onclick='$("#paymentForm").toggleClass("hidden")' />
                    </td>
                </tr>
            </table>
        </div>

        <div id="paymentForm" Class="form-group hidden">
            <table>
                <tr>
                    <td>Card number:</td>
                    <td>
                        @Html.EditorFor(Function(model) model.CreditCardNumber, New With {.autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.CreditCardNumber)
                    </td>
                </tr>
                <tr>
                    <td>Expiry Date (MM/YYYY):</td>
                    <td>
                        @Html.DropDownListFor(Function(model) model.ExpiryMonth, months.Select(Function(i) New SelectListItem() With {.Text = i.ToString(), .Value = i}))
                        @Html.DropDownListFor(Function(model) model.ExpiryYear, years.Select(Function(i) New SelectListItem() With {.Text = i.ToString(), .Value = i}))
                    </td>
                </tr>
                <tr>
                    <td>Security code:</td>
                    <td>
                        @Html.PasswordFor(Function(model) model.CvvNumber, New With {.autocomplete = "off"})
                        @Html.ValidationMessageFor(Function(model) model.CvvNumber)
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <div Class="">
                            <input type="submit" value="Confirm" Class="btn btn-default" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")

    <script language="javascript">
        function CollectNewChosenSeats() {
            var price = 0.0;
            var chosen = [];
            $("span").each(function () {
                if ($(this).hasClass("chosen") && $(this).attr("price") != null) {
                    chosen.push($(this).attr('id'));
                    price += parseFloat($(this).attr('price'));
                }
            });

            $("#chosenPrice").html("£" + price.toFixed(2));
            $("input[type=hidden][name=ChosenSeatsCsv]").val(chosen.join(","));
            $("input[type=hidden][name=Amount]").val(price.toFixed(2));
            $("#acceptAndPay").prop('disabled', chosen.length == 0);

            if (chosen.length == 0) {
                $("#paymentForm").addClass("hidden");
            }
        }

        CollectNewChosenSeats();
    </script>
End Section
