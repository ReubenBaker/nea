Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Nea.Website

Namespace Controllers
    Public Class ConcertsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Concerts
        Function Index() As ActionResult
            Dim concerts = db.Concerts.Include(Function(c) c.Band).Include(Function(c) c.Venue)
            Return View(concerts.ToList())
        End Function

        ' GET: Concerts/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim concert As Concert = db.Concerts.Find(id)
            If IsNothing(concert) Then
                Return HttpNotFound()
            End If
            Return View(concert)
        End Function

        ' GET: Concerts/Create
        Function Create() As ActionResult
            ViewBag.BandId = New SelectList(db.Bands, "Id", "Name")
            ViewBag.VenueId = New SelectList(db.Venues, "Id", "Name")
            Return View()
        End Function

        ' POST: Concerts/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Time,BandId,VenueId,BandAPrice,BandBPrice,BandCPrice,Timestamp")> ByVal concert As Concert) As ActionResult
            If ModelState.IsValid Then
                db.Concerts.Add(concert)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.BandId = New SelectList(db.Bands, "Id", "Name", concert.BandId)
            ViewBag.VenueId = New SelectList(db.Venues, "Id", "Name", concert.VenueId)
            Return View(concert)
        End Function

        ' GET: Concerts/Edit/5
        <Authorize(Roles:="admin")>
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim concert As Concert = db.Concerts.Find(id)
            If IsNothing(concert) Then
                Return HttpNotFound()
            End If
            ViewBag.BandId = New SelectList(db.Bands, "Id", "Name", concert.BandId)
            ViewBag.VenueId = New SelectList(db.Venues, "Id", "Name", concert.VenueId)
            Return View(concert)
        End Function

        ' POST: Concerts/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Time,BandId,VenueId,BandAPrice,BandBPrice,BandCPrice,Timestamp")> ByVal concert As Concert) As ActionResult
            If ModelState.IsValid Then
                db.Entry(concert).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.BandId = New SelectList(db.Bands, "Id", "Name", concert.BandId)
            ViewBag.VenueId = New SelectList(db.Venues, "Id", "Name", concert.VenueId)
            Return View(concert)
        End Function

        ' GET: Concerts/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim concert As Concert = db.Concerts.Find(id)
            If IsNothing(concert) Then
                Return HttpNotFound()
            End If
            Return View(concert)
        End Function

        ' POST: Concerts/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim concert As Concert = db.Concerts.Find(id)
            db.Concerts.Remove(concert)
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
