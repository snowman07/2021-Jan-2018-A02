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

from entityplaceholderrow in Albums
select new
{
	Title = entityplaceholderrow.Title,
	Year = entityplaceholderrow.ReleaseYear,
	ArtistName = entityplaceholderrow.Artist.Name
}