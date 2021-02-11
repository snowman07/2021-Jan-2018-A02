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

var distinctmq = Customers
				.Select(x => x.Country)
				.Distinct(); // use to display distinct data
distinctmq.Dump();

var distinctsq = (from x in Customers
				select x.Country).Distinct();
distinctsq.Dump();


// Any() and All()

//number of genres
var GenreCount = Genres.Count();
GenreCount.Dump();
// Show genres that have tracks which are not on any playlist
var genreTrackAny = from g in Genres
					where g.Tracks.Any(tr => tr.PlaylistTracks.Count() == 0)
					select g;
genreTrackAny.Dump();		

// show genres that have all the tracks appearing at least once on a playlist
// what are the popular genres?
var genreTrackAll = from g in Genres
					where g.Tracks.All(tr => tr.PlaylistTracks.Count() > 0)
					select g;
genreTrackAll.Dump();	


// show genres that have all the tracks appearing at least once on a playlist
// what are the popular genres?
// show the genre name, and list of genre tracks and number of playlist
var genreTrackAll2 = from g in Genres
					where g.Tracks.All(tr => tr.PlaylistTracks.Count() > 0)
					select new
					{
						name = g.Name,
						thetracks = from y in g.Tracks
									where y.PlaylistTracks.Count() > 0
									select new
									{
										song = y.Name,
										count = y.PlaylistTracks.Count()
									}
					};
genreTrackAll2.Dump();	




