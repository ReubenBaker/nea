Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class VenuesController
        Inherits Controller

        Private db As New ApplicationDbContext

        ' GET: Venues
        Function Index() As ActionResult
            Return View(db.Venues.ToList())
        End Function

        ' GET: Venues/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim venue As Venue = db.Venues.Find(id)
            If IsNothing(venue) Then
                Return HttpNotFound()
            End If
            Return View(venue)
        End Function

        ' GET: Venues/Create
        <Authorize(Roles:="admin")>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Venues/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <Authorize(Roles:="admin")>
        Function Create(<Bind(Include:="Id,NumberOfRows,SeatsPerRow,PriceBandAFirstRow,PriceBandBFirstRow,PriceBandCFirstRow,Name")> ByVal venue As Venue) As ActionResult
            If ModelState.IsValid Then
                db.Venues.Add(venue)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(venue)
        End Function

        ' GET: Venues/Edit/5
        <Authorize(Roles:="admin")>
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim venue As Venue = db.Venues.Find(id)
            If IsNothing(venue) Then
                Return HttpNotFound()
            End If
            Return View(venue)
        End Function

        ' POST: Venues/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <Authorize(Roles:="admin")>
        Function Edit(<Bind(Include:="Id,NumberOfRows,SeatsPerRow,PriceBandAFirstRow,PriceBandBFirstRow,PriceBandCFirstRow,Name")> ByVal venue As Venue) As ActionResult
            If ModelState.IsValid Then
                Dim originalVenue As Venue = db.Venues.Find(venue.Id)
                originalVenue.NumberOfRows = venue.NumberOfRows
                originalVenue.SeatsPerRow = venue.SeatsPerRow
                originalVenue.PriceBandAFirstRow = venue.PriceBandAFirstRow
                originalVenue.PriceBandBFirstRow = venue.PriceBandBFirstRow
                originalVenue.PriceBandCFirstRow = venue.PriceBandCFirstRow
                originalVenue.Name = venue.Name
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(venue)
        End Function

        ' GET: Venues/Delete/5
        <Authorize(Roles:="admin")>
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim venue As Venue = db.Venues.Find(id)
            If IsNothing(venue) Then
                Return HttpNotFound()
            End If
            Return View(venue)
        End Function

        ' POST: Venues/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        <Authorize(Roles:="admin")>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim venue As Venue = db.Venues.Find(id)
            db.Venues.Remove(venue)
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
