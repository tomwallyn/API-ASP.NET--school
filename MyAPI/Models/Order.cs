using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyAPI.Models;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public Element? starter { get; set; }

    public Element? dish { get; set; }

    public Element? dessert { get; set; }

    public Element? drink { get; set; }

    public String order_status { get; set; } = "en cours";
}

public class Element
{
    public string name { get; set; }
    
    public string status { get; set; }
}