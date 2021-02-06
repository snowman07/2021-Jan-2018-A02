<Query Kind="Expression">
  <Connection>
    <ID>3173fa56-79ce-4db7-97dd-c44188456839</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

// Method syntax
//Albums
//	.Select(x => x)
//	
////Query syntax
//from x in Albums
//select x


//toggle+R


//filtering
//where clause in query syntax
//.Where() method in method syntax

////Find all albums released in 1990 (using query syntax)
//from x in Albums
//where x.ReleaseYear == 1990
//select x

////(using method syntax)
//Albums
//	.Where(x => x.ReleaseYear == 1990)
//	.Select(x => x)

////Find all Albums rekease in the good old 70'
//from x in Albums
//where ((x.ReleaseYear >= 1970) && (x.ReleaseYear <= 1979)) 
//select x 

////ordering
////List all albums by ascending year of release
////(query syntax)
//from x in Albums
//orderby x.ReleaseYear
//select x

////(method syntax)
//Albums
//	.OrderBy(x => x.ReleaseYear)
//	.Select(x => x)

////List all albums by ascending year of release, in alphabetical order of Title
//from x in Albums
//orderby x.ReleaseYear, x.Title
//select x

////(method syntax)
//Albums
//	.OrderBy(x => x.ReleaseYear)
//	.ThenBy(x => x.Title)
//	.Select(x => x)

////List all albums by desscending year of release, in alphabetical order of Title
////(query syntax)
//from x in Albums
//orderby x.ReleaseYear descending, x.Title 
//select x

////(method syntax)
//Albums
//	.OrderByDescending(x => x.ReleaseYear)
//	.ThenBy(x => x.Title)
//	.Select(x => x)

//What about only certain fields (partial entity records or fields from another table)
// List all records from 1970's showing the title, artist name and year
from x in Albums
where x.ReleaseYear < 1980 && x.ReleaseYear >= 1970
orderby x.ReleaseYear, x.Title
select new
{
	Title = x.Title,
	Artist = x.Artist.Name,
	Year = x.ReleaseYear
}

////(method syntax)
Albums
	.Where(x => x.ReleaseYear < 1980 && x.ReleaseYear >= 1970)
	.OrderBy(x => x.ReleaseYear)
	.ThenBy(x => x.Title)
	.Select(x => new
				{
					Title = x.Title,
					Artist = x.Artist.Name,
					Year = x.ReleaseYear
				})









