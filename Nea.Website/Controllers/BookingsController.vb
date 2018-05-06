Imports System.Data.Entity
Imports System.Net
Imports System.Web.Http

Namespace Controllers
    <Authorize>
    Public Class BookingsController
        Inherits Controller

        Private db As New ApplicationDbContext

        ' GET: Bookings
        Function Index() As ActionResult
            Dim bookings = db.Bookings
            Return View(bookings.ToList())
        End Function

        ' GET: Bookings/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim booking As Booking = db.Bookings.Find(id)
            If IsNothing(booking) Then
                Return HttpNotFound()
            End If
            Return View(booking)
        End Function

        ' GET: Bookings/Create
        Function Create(ByVal concertId As Integer) As ActionResult
            Dim booking As New Booking With {
                .Id = 0,
                .ConcertId = concertId,
                .BookingMadeUtc = DateTime.UtcNow,
                .UserName = User.Identity.Name
            }

            TryValidateModel(booking)

            If ModelState.IsValid Then
                db.Bookings.Add(booking)
                db.SaveChanges()
                Return RedirectToAction("Edit", New With {booking.Id})
            End If
            Return View(booking)
        End Function

        ' GET: Bookings/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim booking As Booking = db.Bookings.Include(Function(c) c.Seats).First(Function(x) x.Id = id)
            If IsNothing(booking) Then
                Return HttpNotFound()
            End If

            Dim concert As Concert = db.Concerts.Include(Function(c) c.Venue).First(Function(x) x.Id = booking.ConcertId)

            Dim allocatedSeats As List(Of BookingSeat) = db.Seats.Where(Function(x) x.Booking.ConcertId = booking.ConcertId).ToList

            Return View("Edit", New BookingViewModel With {.Booking = booking, .Venue = concert.Venue, .AllocatedSeats = allocatedSeats, .ChosenSeatsCsv = ""})
        End Function

        ' POST: Bookings/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Booking.Id,ChosenSeatsCsv")> ByVal bookingViewModel As BookingViewModel) As ActionResult
            Dim chosenSeats As List(Of String) = bookingViewModel.ChosenSeatsCsv.Split(",").ToList()

            If chosenSeats.Any() Then
                ' Add newly chosen seats to the booking
                Dim bookingSeats As List(Of BookingSeat) = chosenSeats.Select(Function(x) New BookingSeat With {.BookingId = bookingViewModel.Booking.Id, .Row = Asc(x(0)) - Asc("A"), .NumberInRow = Integer.Parse(x.Substring(1))})
                db.Seats.AddRange(bookingSeats)
                db.SaveChanges()
            End If

            Return RedirectToAction("Edit", New With {bookingViewModel.Booking.Id})
        End Function

        ' GET: Bookings/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim booking As Booking = db.Bookings.Find(id)
            If IsNothing(booking) Then
                Return HttpNotFound()
            End If
            Return View(booking)
        End Function

        ' POST: Bookings/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim booking As Booking = db.Bookings.Find(id)
            db.Bookings.Remove(booking)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
