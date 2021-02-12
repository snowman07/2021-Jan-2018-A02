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




//========================//
//===== Feb 12, 2020 =====//
//========================//

// comparing the playlists of Roberto Almeida (AlmeidaR) and Michelle Brooks (BrooksM)
// comparing two lists to each other

// obtain a distinct list of all playlist tracks for Roberto
// the .distinct() can detroy the sort of a query syntax, thus we add 
//		sort after the .Distinct()
var almeida = (from x in PlaylistTracks
				where x.Playlist.UserName.Contains("AlmeidaR")
				select new 
				{
					genre = x.Track.Genre.Name,
					id = x.TrackId,
					song = x.Track.Name,
					artist = x.Track.Album.Artist.Name
				}).Distinct().OrderBy(y => y.song);
almeida.Dump(); // 110	

var brooks = (from x in PlaylistTracks
				where x.Playlist.UserName.Contains("BrooksM")
				select new 
				{
					genre = x.Track.Genre.Name,
					id = x.TrackId,
					song = x.Track.Name,
					artist = x.Track.Album.Artist.Name
				}).Distinct().OrderBy(y => y.song);
//brooks.Dump(); // 88

//list the tracks that both Roberto and Michelle like
//comparing 2 datasets together 
//data in listA that is also in listB

var likes = almeida
			.Where(rob => brooks.Any(mic => mic.id == rob.id))
			.OrderBy(rob => rob.song)
			.Select(rob => rob);
//likes.Dump(); // 1 song in common 


//list the tracks that Roberto likes but Michelle does not listen to 
var almeidadiffs = almeida
			.Where(rob => !brooks.Any(mic => mic.id == rob.id))
			.OrderBy(rob => rob.song)
			.Select(rob => rob);
almeidadiffs.Dump(); // 109

//list the tracks that Roberto likes but Michelle does not listen to 
var brooksdiffsm = brooks
			.Where(mic => almeida.All(rob => mic.id != rob.id))
			.OrderBy(mic => mic.song)
			.Select(mic => mic);
brooksdiffsm.Dump(); // 87

var brooksdiffsq = from mic in brooks
					where almeida.All
					
					
brooksdiffsm.Dump(); // 87



//using multiple statements to solve a problem is not unusual
//What is really the problem
//		you have to do some type of pre-processing to obtain some data
//		and that data is used in the remaining processing

//produce a report (display) where the track is flag as shorter than average,
// 		longer than average or average in play length (milliseconds)

//first what is the average track play time
//THEN on, can compare the average play time to each track

//preprocessing to obtain a value needed for the next query
var resultsavg = Tracks.Average(tr => tr.Milliseconds);
resultsavg.Dump(); //393599

//use the pre-proceed value in another query
var resultsTrackAvgLength = from x in Tracks
							select new
							{
								song = x.Name,
								milliseconds = x.Milliseconds,
								length = x.Milliseconds < resultsavg ? "Shorter";
							}






























