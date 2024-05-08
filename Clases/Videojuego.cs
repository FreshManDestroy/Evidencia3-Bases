using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Videojuego
{
    public int Id { get; set; }

    [BsonElement("nombre")]
    public string Nombre { get; set; }

    [BsonElement("genero")]
    public string Genero { get; set; }

    [BsonElement("promedioPuntaje")]
    public double PromedioPuntaje { get; set; }

    [BsonElement("sinopsis")]
    public string Sinopsis { get; set; }
}