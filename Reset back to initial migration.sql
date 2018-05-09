drop table Tickets
drop table Payments
drop table Bookings
drop table Refunds
drop table Pricings
drop table AllocatedSeats
drop table Concerts
drop table Venues
drop table Bands
drop table Customers
delete __MigrationHistory where MigrationId != '201804151554436_InitialCreate'