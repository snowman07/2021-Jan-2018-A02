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

////Customers
////list all customers in alphabetic order by last name then first name who 
////	live in the US and have an email of uahoo. List their fullname, email, city and state.
//
////query syntax
from x in Customers
where x.Country.Contains("USA") && x.Email.Contains("yahoo")
orderby x.LastName, x.FirstName
select new	
{
	Name = x.LastName + ", " + x.FirstName,
	Email = x.Email,
	City = x.City,
	State = x.State,
	Country = x.Country
}
//
////method syntax
//Customers
//	.Where(x => x.Country.Contains("USA") && x.Email.Contains("yahoo"))
//	.OrderBy(x => x.LastName)
//	.ThenBy(x => x.FirstName)
//	.Select(x => new 
//	{
//		Name = x.LastName + ", " + x.FirstName,
//		Email = x.Email,
//		City = x.City,
//		State = x.State,
//		Country = x.Country	
//	})

//==============================//

//create an alphabetic list of Albums by ReleaseLabel.
//	Show the Title  and ReleaseLabel 
//	Missing album labels will be listed as "Unknown"
// Note: ReleaseLabel is nullable
//from x in Albums
//orderby x.ReleaseLabel
//select new
//{
//	Title = x.Title,
//	Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel
//}

////method Syntax
//Albums
//	.OrderBy(x => x.ReleaseLabel)
//	.Select(x => new
//			{
//				Title = x.Title,
//				Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel
//			})

//============================

//Create an alphabetic list of Albums stating the 
//	album decade for the 70's, 80's and 90's
//List the Title, Year, and its decade

//query syntax
from x in Albums

where x.ReleaseYear >= 1970 && x.ReleaseYear < 2000 
orderby x.Title
select new
{
	Title = x.Title,
	Year = x.ReleaseYear,
	Decade = 	x.ReleaseYear >= 1970 && x.ReleaseYear < 1980  ? "70's" : 
				(x.ReleaseYear >= 1980 && x.ReleaseYear < 1990  ? "80's" : "90's")
}


//method syntax


//======================================================//
//==================== C# STATEMENT ====================//
//======================================================//

////list all customers in alphabetic order by last name then first name who 
////	live in the US and have an email of uahoo. List their fullname, email, city and state.
//
////query syntax

// the code inside the new {....} is called the initializer list

string country = "USA";
string email = "yahoo";
var results = from x in Customers
				where x.Country.Contains(country) && x.Email.Contains(email)
				orderby x.LastName, x.FirstName
				select new	
				{
					Name = x.LastName + ", " + x.FirstName,
					Email = x.Email,
					City = x.City,
					State = x.State,
					Country = x.Country
				};
//within linqpad, to see the contents of a variable,
//	you will use the Linqpad method .Dump()
results.Dump();

////method syntax
var resultsB = Customers
	.Where(x => x.Country.Contains("USA") && x.Email.Contains("yahoo"))
	.OrderBy(x => x.LastName)
	.ThenBy(x => x.FirstName)
	.Select(x => new 
	{
		Name = x.LastName + ", " + x.FirstName,
		Email = x.Email,
		City = x.City,
		State = x.State,
		Country = x.Country	
	});
resultsB.Dump();



//====================================================//
//==================== C# PROGRAM ====================//
//====================================================//


// You can define other methods, fields, classes and namespaces here

//classes are strongly specified developer-defined datatypes
public class CustomersOfCountryEmail
{
	public string Name{get; set;}
	public string Email{get;set;}
	public string City{get;set;}
	public string State{get;set;}
	public string Country{get;set;}
}
















