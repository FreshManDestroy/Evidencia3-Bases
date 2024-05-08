using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Resena
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("usuario")]
    public string Usuario { get; set; }

    [BsonElement("puntuacion")]
    public int Puntuacion { get; set; }

    [BsonElement("comentario")]
    public string Comentario { get; set; }
    public int VideojuegoId { get; set; }  // Nueva propiedad
}