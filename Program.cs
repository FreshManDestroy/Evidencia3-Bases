using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "mongodb://localhost:27017";
        var client = new MongoClient(connectionString);

        // Obtener o crear la base de datos
        var database = client.GetDatabase("Gamepass");

        // Obtener o crear la colección de Videojuegos
        var videojuegosCollection = database.GetCollection<Videojuego>("Videojuegos");

        // Obtener o crear la colección de Reseñas
        var resenasCollection = database.GetCollection<Resena>("Resenas");

        // Insertar algunos juegos de ejemplo si la colección está vacía
        if (videojuegosCollection.CountDocuments(FilterDefinition<Videojuego>.Empty) == 0)
        {
            List<Videojuego> juegos = new List<Videojuego>
    {
        new Videojuego
        {
            Nombre = "The Witcher 3: Wild Hunt",
            Genero = "RPG",
            PromedioPuntaje = 9.5,
            Sinopsis = "Geralt de Rivia, un cazador de monstruos, emprende un viaje épico en un mundo lleno de peligros y aventuras.",
            Id = 1
        },
        new Videojuego
        {
            Nombre = "Cyberpunk 2077",
            Genero = "RPG",
            PromedioPuntaje = 8.0,
            Sinopsis = "En el mundo abierto de Night City, eres V, un mercenario que persigue un implante único que es la clave para la inmortalidad.",
            Id = 2
        },
        new Videojuego
        {
            Nombre = "Red Dead Redemption 2",
            Genero = "Acción-aventura",
            PromedioPuntaje = 9.7,
            Sinopsis = "Arthur Morgan, un miembro de la pandilla Van der Linde, trata de sobrevivir en el salvaje oeste mientras su pandilla se desmorona.",
            Id = 3
        },
        new Videojuego
        {
            Nombre = "The Last of Us Part II",
            Genero = "Acción-aventura",
            PromedioPuntaje = 9.3,
            Sinopsis = "Ellie y Joel regresan en una nueva aventura post-apocalíptica. Ellie emprende un viaje para buscar justicia y encontrar la paz.",
            Id =4
        },
        new Videojuego
        {
            Nombre = "God of War",
            Genero = "Acción-aventura",
            PromedioPuntaje = 9.8,
            Sinopsis = "Kratos, el dios de la guerra, trata de controlar su furia y ser un buen padre para su hijo Atreus en el mundo de los dioses nórdicos.",
            Id = 5
        },
        new Videojuego
        {
            Nombre = "Uncharted 4: A Thief's End",
            Genero = "Acción-aventura",
            PromedioPuntaje = 9.2,
            Sinopsis = "Nathan Drake sale de su retiro para buscar un tesoro pirata y descubrir la verdad detrás de la conspiración de su hermano.",
            Id = 6
        }
    };

            videojuegosCollection.InsertMany(juegos);
        }

        // Insertar algunas reseñas de ejemplo si la colección está vacía
        if (resenasCollection.CountDocuments(FilterDefinition<Resena>.Empty) == 0)
        {
            List<Resena> resenas = new List<Resena>();

            // Agregar la primera reseña si no existe
            var primeraResenaExistente = resenas.Any(r => r.Usuario == "GamerPro123" && r.Comentario == "¡The Witcher 3 es una obra maestra absoluta! La historia es cautivadora, los personajes son increíblemente bien desarrollados y el mundo abierto es vasto y lleno de vida. ¡No puedo recomendarlo lo suficiente!");
            if (!primeraResenaExistente)
            {
                resenas.Add(new Resena
                {
                    Usuario = "GamerPro123",
                    Puntuacion = 10,
                    Comentario = "¡The Witcher 3 es una obra maestra absoluta! La historia es cautivadora, los personajes son increíblemente bien desarrollados y el mundo abierto es vasto y lleno de vida. ¡No puedo recomendarlo lo suficiente!",
                    VideojuegoId = 1
                });

                resenas.Add(new Resena
                {
                    Usuario = "Aventurero99",
                    Puntuacion = 9,
                    Comentario = "Me encanta perderme en el mundo de The Witcher 3. Cada rincón está lleno de detalles y secretos por descubrir. La diversidad de misiones y la toma de decisiones significativas hacen que cada partida sea única. Definitivamente, uno de los mejores juegos de la última década.",
                    VideojuegoId = 1 // Id del juego "The Witcher 3: Wild Hunt"
                });

                resenas.Add(new Resena
                {
                    Usuario = "CriticoDescontento",
                    Puntuacion = 5,
                    Comentario = "Si bien The Witcher 3 tiene una narrativa impresionante y un mundo bien construido, la mecánica de combate se siente torpe y poco satisfactoria. Me costó mantenerme interesado debido a la repetitividad de las misiones secundarias y la falta de variedad en las mecánicas de juego.",
                    VideojuegoId = 1 // Id del juego "The Witcher 3: Wild Hunt"
                });
                resenas.Add(new Resena
                {
                    Usuario = "Jamesweb",
                    Puntuacion = 3,
                    Comentario = "El juego ni me quiso abrir",
                    VideojuegoId = 2 // Id del juego "Cyberpunk 2077"
                });
                resenas.Add(new Resena
                {
                    Usuario = "Futurista22",
                    Puntuacion = 8,
                    Comentario = "¡Me encanta la ambientación futurista de Cyberpunk 2077! La historia es intrigante y los personajes son fascinantes. A pesar de algunos errores técnicos, sigue siendo una experiencia única.",
                    VideojuegoId = 2 // Id del juego "Cyberpunk 2077"
                });
                resenas.Add(new Resena
                {
                    Usuario = "HackerPro",
                    Puntuacion = 9,
                    Comentario = "Cyberpunk 2077 ofrece una jugabilidad impresionante y una historia envolvente. La personalización es excepcional y la ciudad de Night City se siente viva. Un imprescindible para los amantes de los juegos de rol.",
                    VideojuegoId = 2 // Id del juego "Cyberpunk 2077"
                });
                resenas.Add(new Resena
                {
                    Usuario = "WesternFan",
                    Puntuacion = 10,
                    Comentario = "¡Red Dead Redemption 2 captura perfectamente la esencia del salvaje oeste! La atención al detalle es asombrosa y la historia es épica. Me encanta perderme en este mundo lleno de aventuras.",
                    VideojuegoId = 3 // Id del juego "Red Dead Redemption 2"
                });
                resenas.Add(new Resena
                {
                    Usuario = "CowboyBebop",
                    Puntuacion = 9,
                    Comentario = "Red Dead Redemption 2 es simplemente increíble. Los gráficos, la jugabilidad, la historia, todo está en su lugar. Pasé horas explorando el mundo y cada vez descubro algo nuevo.",
                    VideojuegoId = 3 // Id del juego "Red Dead Redemption 2"
                });
                resenas.Add(new Resena
                {
                    Usuario = "Arthur morgan",
                    Puntuacion = 10,
                    Comentario = "He jugado a muchos juegos de vaqueros, pero ninguno se compara con Red Dead Redemption 2. La calidad y la inmersión son incomparables. Este juego establece un nuevo estándar para el género.",
                    VideojuegoId = 3 // Id del juego "Red Dead Redemption 2"
                });
                resenas.Add(new Resena
                {
                    Usuario = "SurvivorEllie",
                    Puntuacion = 10,
                    Comentario = "The Last of Us Part II es una obra maestra del storytelling. La narrativa emocionante y los personajes bien desarrollados hacen que esta experiencia sea inolvidable. ¡No puedo esperar para jugarlo de nuevo!",
                    VideojuegoId = 4 // Id del juego "The Last of Us Part II"
                });
                resenas.Add(new Resena
                {
                    Usuario = "ZombieHunter",
                    Puntuacion = 9,
                    Comentario = "The Last of Us Part II supera todas las expectativas. La jugabilidad es intensa, los gráficos son impresionantes y la historia te mantiene enganchado desde el principio hasta el final. ¡Una experiencia épica!",
                    VideojuegoId = 4 // Id del juego "The Last of Us Part II"
                });
                resenas.Add(new Resena
                {
                    Usuario = "DisappointedGamer",
                    Puntuacion = 5,
                    Comentario = "The Last of Us Part II fue una gran decepción. La trama carece de coherencia y los nuevos personajes no logran conectarse con el jugador. Esperaba mucho más después del primer juego.",
                    VideojuegoId = 4 // Id del juego "The Last of Us Part II"
                });
                resenas.Add(new Resena
                {
                    Usuario = "WarriorKratos",
                    Puntuacion = 10,
                    Comentario = "God of War es un juego impresionante. La historia es épica, los gráficos son asombrosos y la jugabilidad es adictiva. Me encantó cada momento de esta aventura con Kratos y Atreus.",
                    VideojuegoId = 5 // Id del juego "God of War"
                });
                resenas.Add(new Resena
                {
                    Usuario = "MythologyFan",
                    Puntuacion = 9,
                    Comentario = "God of War es una obra maestra que reinventa la serie. La mitología nórdica, combinada con una narrativa poderosa y una jugabilidad pulida, crea una experiencia inolvidable. ¡Kratos ha vuelto con estilo!",
                    VideojuegoId = 5 // Id del juego "God of War"
                });
                resenas.Add(new Resena
                {
                    Usuario = "DisappointedSpartan",
                    Puntuacion = 6,
                    Comentario = "God of War no cumplió mis expectativas. Si bien los gráficos son impresionantes, encontré la jugabilidad repetitiva y la historia poco interesante. Esperaba más de esta nueva entrega.",
                    VideojuegoId = 5 // Id del juego "God of War"
                });
                resenas.Add(new Resena
                {
                    Usuario = "TreasureHunter",
                    Puntuacion = 9,
                    Comentario = "Uncharted 4 es el mejor juego de la serie. La jugabilidad es sólida, los gráficos son de primera categoría y la historia es cautivadora. Nathan Drake nunca decepciona.",
                    VideojuegoId = 6 // Id del juego "Uncharted 4: A Thief's End"
                });
                resenas.Add(new Resena
                {
                    Usuario = "AdventureSeeker",
                    Puntuacion = 9,
                    Comentario = "Uncharted 4 es una aventura emocionante llena de acción y misterio. Los gráficos son impresionantes y la historia te atrapa desde el principio hasta el final. ¡Una experiencia inolvidable!",
                    VideojuegoId = 6 // Id del juego "Uncharted 4: A Thief's End"
                });
                resenas.Add(new Resena
                {
                    Usuario = "LostInterestGamer",
                    Puntuacion = 6,
                    Comentario = "A pesar de los impresionantes gráficos, me decepcionó la jugabilidad repetitiva de Uncharted 4. Además, la trama carece de la originalidad y emoción que esperaba de este último juego de la serie.",
                    VideojuegoId = 6 // Id del juego "Uncharted 4: A Thief's End"
                });

            }

            resenasCollection.InsertMany(resenas);
        }

        // Menú principal
        while (true)
        {
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("1. Consultar videojuegos");
            Console.WriteLine("2. Agregar videojuego");
            Console.WriteLine("3. Dejar reseña");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuConsultarVideojuegos(videojuegosCollection, resenasCollection);
                    break;
                case "2":
                    AgregarVideojuego(videojuegosCollection);
                    break;
                case "3":
                    DejarResena(resenasCollection, videojuegosCollection);
                    break;
                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void MenuConsultarVideojuegos(IMongoCollection<Videojuego> videojuegosCollection, IMongoCollection<Resena> resenasCollection)
    {
        // Submenú de consultar videojuegos
        while (true)
        {
            Console.WriteLine("CONSULTAR VIDEOJUEGOS");
            Console.WriteLine("1. Ver todo el listado de videojuegos");
            Console.WriteLine("2. Filtrar por nombre de videojuego");
            Console.WriteLine("3. Filtrar por género de videojuego");
            Console.WriteLine("4. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string opcionConsulta = Console.ReadLine();

            switch (opcionConsulta)
            {
                case "1":
                    ConsultarVideojuegos(videojuegosCollection, resenasCollection);
                    break;
                case "2":
                    FiltrarPorNombre(videojuegosCollection);
                    break;
                case "3":
                    FiltrarPorGenero(videojuegosCollection);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void ConsultarVideojuegos(IMongoCollection<Videojuego> videojuegosCollection, IMongoCollection<Resena> resenasCollection)
    {
        var videojuegos = videojuegosCollection.Find(_ => true).ToList();
        MostrarVideojuegosConResenas(videojuegos, resenasCollection);
    }

    static void FiltrarPorNombre(IMongoCollection<Videojuego> videojuegosCollection)
    {
        Console.Write("Ingrese el nombre del videojuego (puede ser similar): ");
        string nombre = Console.ReadLine();
        var filter = Builders<Videojuego>.Filter.Regex(v => v.Nombre, new MongoDB.Bson.BsonRegularExpression(nombre, "i"));
        var videojuegos = videojuegosCollection.Find(filter).ToList();
        MostrarVideojuegos(videojuegos);
    }

    static void FiltrarPorGenero(IMongoCollection<Videojuego> videojuegosCollection)
    {
        Console.Write("Ingrese el género del videojuego: ");
        string genero = Console.ReadLine();
        var filter = Builders<Videojuego>.Filter.Eq(v => v.Genero, genero);
        var videojuegos = videojuegosCollection.Find(filter).ToList();
        MostrarVideojuegos(videojuegos);
    }

    static void MostrarVideojuegosConResenas(List<Videojuego> videojuegos, IMongoCollection<Resena> resenasCollection)
    {
        foreach (var videojuego in videojuegos)
        {
            Console.WriteLine($"Nombre: {videojuego.Nombre}");
            Console.WriteLine($"Género: {videojuego.Genero}");
            Console.WriteLine($"Promedio de Puntuación: {videojuego.PromedioPuntaje}");

            var resenas = resenasCollection.Find(r => r.VideojuegoId == videojuego.Id).ToList();
            if (resenas.Any())
            {
                Console.WriteLine("Reseñas:");
                foreach (var resena in resenas)
                {
                    Console.WriteLine($"- Usuario: {resena.Usuario}");
                    Console.WriteLine($"  Puntuación: {resena.Puntuacion}");
                    Console.WriteLine($"  Comentario: {resena.Comentario}");
                }
            }
            else
            {
                Console.WriteLine("No hay reseñas para este videojuego.");
            }

            Console.WriteLine();
        }
    }

    static void MostrarVideojuegos(List<Videojuego> videojuegos)
    {
        foreach (var videojuego in videojuegos)
        {
            Console.WriteLine($"Nombre: {videojuego.Nombre}");
            Console.WriteLine($"Género: {videojuego.Genero}");
            Console.WriteLine($"Promedio de Puntuación: {videojuego.PromedioPuntaje}");
            Console.WriteLine();
        }
    }

    static void AgregarVideojuego(IMongoCollection<Videojuego> videojuegosCollection)
    {
        Console.Write("Ingrese el nombre del videojuego: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el género del videojuego: ");
        string genero = Console.ReadLine();
        Console.Write("Ingrese el promedio de puntaje del videojuego: ");
        double promedioPuntaje = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese una breve descripción del videojuego: ");
        string descripcion = Console.ReadLine();
        Console.Write("Ingrese el ID del videojuego: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Videojuego videojuego = new Videojuego
        {
            Nombre = nombre,
            Genero = genero,
            PromedioPuntaje = promedioPuntaje,
            Sinopsis = descripcion,
            Id = id
        };

        videojuegosCollection.InsertOne(videojuego);
        Console.WriteLine("El videojuego ha sido agregado correctamente.");
    }

    static void DejarResena(IMongoCollection<Resena> resenasCollection, IMongoCollection<Videojuego> videojuegosCollection)
    {
        Console.Write("Ingrese el nombre del videojuego al que desea dejar una reseña: ");
        string nombreVideojuego = Console.ReadLine();

        var filter = Builders<Videojuego>.Filter.Eq(v => v.Nombre, nombreVideojuego);
        var videojuegoExistente = videojuegosCollection.Find(filter).FirstOrDefault();

        if (videojuegoExistente == null)
        {
            Console.WriteLine("El videojuego no se encontró en la base de datos.");
            return;
        }

        Console.Write("Ingrese su nombre de usuario: ");
        string usuario = Console.ReadLine();
        Console.Write("Ingrese el puntaje (del 1 al 10): ");
        int puntaje;
        while (!int.TryParse(Console.ReadLine(), out puntaje) || puntaje < 1 || puntaje > 10)
        {
            Console.WriteLine("Por favor, ingrese un puntaje válido (del 1 al 10).");
        }
        Console.Write("Ingrese su comentario: ");
        string comentario = Console.ReadLine();

        Resena nuevaResena = new Resena
        {
            Usuario = usuario,
            Puntuacion = puntaje,
            Comentario = comentario,
            VideojuegoId = videojuegoExistente.Id
        };

        // Insertar la nueva reseña en la colección de reseñas
        resenasCollection.InsertOne(nuevaResena);

        // Calcular el nuevo promedio de puntaje
        var resenas = resenasCollection.Find(r => r.VideojuegoId == videojuegoExistente.Id).ToList();
        double nuevoPromedioPuntaje = resenas.Average(r => r.Puntuacion);

        // Actualizar el promedio de puntaje del videojuego en la base de datos
        var update = Builders<Videojuego>.Update.Set(v => v.PromedioPuntaje, nuevoPromedioPuntaje);
        videojuegosCollection.UpdateOne(filter, update);

        Console.WriteLine("Reseña agregada correctamente al videojuego.");
    }
}
