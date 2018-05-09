Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class BandsController
        Inherits Controller

        Private db As New ApplicationDbContext

        ' GET: Bands
        Function Index() As ActionResult
            Return View(db.Bands.ToList())
        End Function

        ' GET: Bands/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim band As Band = db.Bands.Find(id)
            If IsNothing(band) Then
                Return HttpNotFound()
            End If
            Return View(band)
        End Function

        ' GET: Bands/Create
        <Authorize(Roles:="admin")>
        Function Create() As ActionResult
            Return View()
        End Function

        'Adds a band to the database
        ' POST: Bands/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <Authorize(Roles:="admin")>
        Function Create(<Bind(Include:="Id,Name")> ByVal band As Band) As ActionResult
            If ModelState.IsValid Then
                db.Bands.Add(band)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(band)
        End Function

        'Checks that their is a band id
        <Authorize(Roles:="admin")>
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim band As Band = db.Bands.Find(id)
            If IsNothing(band) Then
                Return HttpNotFound()
            End If
            Return View(band)
        End Function

        ' POST: Bands/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <Authorize(Roles:="admin")>
        Function Edit(<Bind(Include:="Id,Name")> ByVal band As Band) As ActionResult
            If ModelState.IsValid Then
                Dim originalBand As Band = db.Bands.Find(band.Id)
                originalBand.Name = band.Name
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(band)
        End Function

        ' GET: Bands/Delete/5
        <Authorize(Roles:="admin")>
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim band As Band = db.Bands.Find(id)
            If IsNothing(band) Then
                Return HttpNotFound()
            End If
            Return View(band)
        End Function

        ' POST: Bands/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        <Authorize(Roles:="admin")>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim band As Band = db.Bands.Find(id)
            db.Bands.Remove(band)
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
