Imports System.Data.Entity
Imports System.Net
Imports System.Security.Cryptography
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

        'Checks that there is a booking id and if the booking is empty
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
        'Creates a booking
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
        'Edits the contents of a booking
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

            Return View("Edit", New BookingViewModel With {
                        .BookingId = booking.Id,
                        .Venue = concert.Venue,
                        .AllocatedSeats = allocatedSeats,
                        .ChosenSeatsCsv = "",
                        .BandAPrice = concert.BandAPrice,
                        .BandBPrice = concert.BandBPrice,
                        .BandCPrice = concert.BandCPrice
                        })
        End Function

        ' POST: Bookings/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        'adds the payment information to the booking
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit2(<Bind(Include:="BookingId,ChosenSeatsCsv,CreditCardNumber,CvvNumber,ExpiryMonth,ExpiryYear,Amount")> ByVal bookingViewModel As BookingViewModel) As ActionResult
            If Not bookingViewModel.ChosenSeatsCsv Is Nothing Then
                Dim chosenSeats As List(Of String) = bookingViewModel.ChosenSeatsCsv.Split(",").ToList()

                If chosenSeats.Any() Then
                    ' Add newly chosen seats to the booking
                    Dim bookingSeats As List(Of BookingSeat) = chosenSeats _
                        .Select(Function(x) x.Split("-")) _
                        .Select(Function(x) New BookingSeat With {
                            .BookingId = bookingViewModel.BookingId,
                            .Row = x(0),
                            .NumberInRow = x(1)
                            }) _
                        .ToList()
                    db.Seats.AddRange(bookingSeats)
                    Dim booking As Booking = db.Bookings.Find(bookingViewModel.BookingId)
                    booking.Payments.Add(New Payment With {
                                         .Amount = bookingViewModel.Amount,
                                         .CreditCardNumber = Encrypt(bookingViewModel.CreditCardNumber),
                                         .CvvNumber = Encrypt(bookingViewModel.CvvNumber),
                                         .ExpiryDate = New DateTime(bookingViewModel.ExpiryYear, bookingViewModel.ExpiryMonth, 1).AddMonths(1).AddDays(-1)
                                         })

                    db.SaveChanges()
                End If
            End If

            Return RedirectToAction("Confirmation", New With {.id = bookingViewModel.BookingId})
        End Function

        ' GET: Bookings/Confirmation/5
        Function Confirmation(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return RedirectToAction("Index", "Concerts")
            End If

            Dim booking As Booking = db.Bookings.Find(id)
            If IsNothing(booking) Then
                Return HttpNotFound()
            End If

            Return View("Confirmation", booking)
        End Function

        Private TripleDes As New TripleDESCryptoServiceProvider

        'From https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/strings/walkthrough-encrypting-and-decrypting-strings
        'An encryption function to be used to encrypt payment information
        Public Function Encrypt(ByVal plaintext As String) As String
            ' Convert the plaintext string to a byte array.
            Dim plaintextBytes() As Byte = Encoding.Unicode.GetBytes(plaintext)

            ' Create the stream.
            Dim ms As New IO.MemoryStream
            ' Create the encoder to write to the stream.
            Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
            encStream.FlushFinalBlock()

            ' Convert the encrypted stream to a printable string.
            Return Convert.ToBase64String(ms.ToArray)
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
