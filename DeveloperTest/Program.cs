using DeveloperTest;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

string filePath = @"C:\DeveloperTest\Postcodes.txt";

var postcodes = new Postcodes();
var incorrectPostcodes = new Postcodes();

List<string> lines = File.ReadAllLines(filePath).ToList();

foreach (string line in lines)
{
    string shortenedLine = line.Substring(75, 32);
    string[] parts = shortenedLine.Split("','");
    string longitudeString = parts[2];


    //The postcode lengths are either 7 or 8 characters long
    //including the space. If they are 7 characters long,
    //then longitute ends up with one extra character
    //which we remove in this if() statement.

    if (longitudeString.Contains("'"))
    {
        longitudeString = longitudeString.Remove(9, 1);
    }

    decimal latitude = Decimal.Parse(parts[1]);
    decimal longitude = Decimal.Parse(longitudeString);

    PostcodeInfo postcodeInfo = new PostcodeInfo();

    postcodeInfo.Postcode = parts[0];
    postcodeInfo.Latitude = latitude;
    postcodeInfo.Longitude = longitude;

    var validatingPostcode = UnitTesting.ValidatePostcode(postcodeInfo.Postcode.ToString());
    var validatingLatitude = UnitTesting.ValidateLatitude(postcodeInfo.Latitude);
    var validatingLongitude = UnitTesting.ValidateLongitude(postcodeInfo.Longitude);

    if(validatingPostcode == true && validatingLatitude == true & validatingLongitude == true)
    {
        postcodes.postcodesList.Add(postcodeInfo);
    }
    else
    {
        incorrectPostcodes.postcodesList.Add(postcodeInfo);
    }
}

var stream = new FileStream(@"C:\DeveloperTest\Postcodes.xml", FileMode.Create);
new XmlSerializer(typeof(Postcodes)).Serialize(stream, postcodes);

if(incorrectPostcodes != null)
{
    var secondStream = new FileStream(@"C:\DeveloperTest\IncorrectPostcodes.xml", FileMode.Create);
    new XmlSerializer(typeof(Postcodes)).Serialize(secondStream, incorrectPostcodes);
}


Console.WriteLine("Execution Complete");
Console.ReadLine();