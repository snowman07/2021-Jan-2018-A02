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
			select x.Bytes).Min();
ex2q.Dump();

var ex2ms = Tracks
			.Where(x => x.Album.ReleaseYear == 1990)
			.Sum(x => x.Bytes);
ex2m.Dump();


//What is the longest playtime of a track released in 1990.


//What is the average playtime of a track released in 1990.
			
			
			