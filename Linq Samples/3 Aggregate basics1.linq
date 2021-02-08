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

//Aggregates
//.Count(), .Sum(), .Max(), .Average()

//aggregates operate on collections
//method syntax
var ex1 = Albums.Count();
ex1.Dump();

//query syntax
var ex1q = (from x in Albums
			select x).Count();
ex1q.Dump();

var ex1qLabels = (from x in Albums
			where x.ReleaseLabel != null
			select x).Count();
ex1qLabels.Dump();

//.Sum(), .Min(), .Max() and .Average()
// you need to specify a field to aggregate

//How much room does the music collection on the 
// database take for albums of the 1990

//Tracks table has a numeric field called Bytes
// this field holds the size of the track for the storage
// summing the field gets total track storage

var ex2q = (from x in Tracks
			where x.Album.ReleaseYear == 1990
			select x.Bytes) .Sum();
ex2q.Dump();

var ex2m = Tracks
			.Where(x => x.Album.ReleaseYear == 1990)
			.Sum(x => x.Bytes);
ex2m.Dump();

//What is the shortest playtime of a track released in 1990.
var ex2qs = (from x in Tracks
			where x.Album.ReleaseYear == 1990
			select x.Milliseconds).Min();
ex2qs.Dump();

var ex2ms = Tracks
			.Where(x => x.Album.ReleaseYear == 1990)
			.Min(x => x.Milliseconds);
ex2ms.Dump();


//What is the longest playtime of a track released in 1990.
var ex2qm = (from x in Tracks
			where x.Album.ReleaseYear == 1990
			select x.Milliseconds).Max();
ex2qm.Dump();

var ex2mm = Tracks
			.Where(x => x.Album.ReleaseYear == 1990)
			.Max(x => x.Milliseconds);
ex2mm.Dump();


//What is the average playtime of a track released in 1990.
var ex2qa = (from x in Tracks
			where x.Album.ReleaseYear == 1990
			select x.Milliseconds).Average();
ex2qa.Dump();

var ex2ma = Tracks
			.Where(x => x.Album.ReleaseYear == 1990)
			.Average(x => x.Milliseconds);
ex2ma.Dump();		
			
			