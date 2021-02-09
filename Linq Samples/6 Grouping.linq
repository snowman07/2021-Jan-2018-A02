<Query Kind="Statements">
  <Connection>
    <ID>3173fa56-79ce-4db7-97dd-c44188456839</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Grouping

//a) by a column				groupname.Key
//b) by multiple columns 		groupname.Key.attribute
//c) by an entity				groupname.Key.attribute

//groups have 2 components
//a) key component (group by); reference this component groupname.Key[.attribute]
//b) data (instances in the group)

//process
//start with a "pile" of data
//specify the grouping attribure(s) 
//result is smaller "piles" of data determined by the attributes which can be 
//		"reported" upon

//display albums by ReleaseYear
//order by
var resultsorderby = from x in Albums
						orderby x.ReleaseYear
						select x;
resultsorderby.Dump();

//group by ReleaseYear
var resultsgroupby = from x in Albums
						group x by x.ReleaseYear;
resultsgroupby.Dump();

//group by Artist name and album ReleaseYear
var resultsgroupbycolumns = from x in Albums
							group x by new {x.Artist.Name, x.ReleaseYear};
resultsgroupbycolumns.Dump();

//group tracks by their album
var resultsgroupbyentity = from x in Tracks
							group x by x.Album;
resultsgroupbyentity.Dump();					

//IMPORTANT!!!!!!!!!!
// if you wish to  'report' on groups (AFTER the group by)
//		you must save the grouping in a temporary dataset
//		then you MUST use the temporary dataset to report from

//for quer syntax
//your temporar dataset 







//group by ReleaseYear
var resultsgroupbyReport = from x in Albums
							group x by x.ReleaseYear into gAlbumYear
							select new
							{
								KeyValue = gAlbumYear.Key,
								numberofAlbums = gAlbumYear.Count(),
								albumandartist = from y in gAlbumYear
													select new
													{
														Title = y.Title,
														Year = y.ReleaseYear,
														Artist = y.Artist.Name
													}
							};
resultsgroupbyReport.Dump();

//group by an entity
var groupAlbumsbyArtist = from x in Albums
							group x by x.Artist into gArtistAlbums
							select new
							{
								KeyValue = gArtistAlbums.Key.Name,
								numberofAlbums = gArtistAlbums.Count(),
								albumandartist = from y in gArtistAlbums
													select new
													{
														Title = y.Title,
														Year = y.ReleaseYear
													}
							};
groupAlbumsbyArtist.Dump();




//Create a query which will report the employee and their customer base.
//List the employee's full name (phone), number of customers in their base.
//List the full name, city and state for the customer base.

//how to attack this question
//tips:
//What is the detail of the query? What is reported on most?
// 		Customers base (big pile of data)
//Is the report one complete report or is it in smaller components?
// 		order by vs group by?
//Can I subdivide (group) my details into specific piles? If so, on what?
//		Employee (smaller piles of data on xxxxxxx)
//Is there an association between the Customers and the Employees?
//		nav property SupportRep

var  groupCustomerOfEmployees = from x in Customers
								group x by x.SupportRep into gTemp
								select new
								{
									Employee = gTemp.Key.LastName + ", " + 
												gTemp.Key.FirstName + "(" +
												gTemp.Key.Phone + ")",
									BaseCount = gTemp.Count(),
									CustomerList = from y in gTemp
													select new
													{
														CustName = y.LastName +
																	", " + y.FirstName,
														City = y.City,
														State = y.State
													}
								};
groupCustomerOfEmployees.Dump();




















