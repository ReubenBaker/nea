@ModelType Nea.Website.Booking
@Code
    ViewData("Title") = "Confirmation"
End Code

<h2>Booking Confirmation</h2>

<div>
    <h4>Thank you for your booking</h4>
    <hr />
    Your booking reference is <strong>@Html.DisplayFor(Function(model) model.Id)</strong>

    <div>
        Your booking includes the following seats:
        @For Each seat As BookingSeat In Model.Seats
            @<div><strong>@(Chr(Asc("A") + seat.Row - 1))@(seat.NumberInRow)</strong></div>
        Next
    </div>
</div>
<p>
    @Html.ActionLink("Continue", "Index", "Home")
</p>
