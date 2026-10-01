using JuegoRol.Entidades;
using JuegoRol.Interfaces;

namespace JuegoRol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Guerrero guerrero = new Guerrero(
                "Thorin",
                120, // vida
                120, // vida máxima
                5,   // nivel
                30,  // fuerza
                85); // precisión

            Mago mago = new Mago(
                "Elara",
                90,  // vida
                90,  // vida máxima
                7,   // nivel
                60,  // maná
                25,  // poder mágico
                90); // precisión

            Arquero arquero = new Arquero(
                "Robin",
                100, // vida
                100, // vida máxima
                6,   // nivel
                10,  // flechas
                70,  // precisión
                25); // daño

            Sanador sanador = new Sanador(
                "Luna",
                85,  // vida
                85,  // vida máxima
                4,   // nivel
                30); // poder de curación

            Personaje[] personajes = new Personaje[]
            {
                guerrero,
                mago,
                arquero,
                sanador
            };

            Console.WriteLine("==========================================");
            Console.WriteLine("          SIMULADOR DE COMBATE");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            Console.WriteLine("========== ESTADO INICIAL ==========");
            Console.WriteLine();

            foreach (Personaje personaje in personajes)
            {
                personaje.MostrarInformacion();
                Console.WriteLine();
            }

            Console.WriteLine("========== PRIMER COMBATE ==========");
            Console.WriteLine();

            guerrero.Atacar(mago);

            Console.WriteLine();

            mago.Atacar(guerrero);

            Console.WriteLine();

            arquero.Atacar(mago);

            Console.WriteLine();

            Console.WriteLine("========== CURACIÓN ==========");
            Console.WriteLine();

            guerrero.RecibirDanio(30);

            Console.WriteLine(
                $"Vida de {guerrero.Nombre}: " +
                $"{guerrero.Vida}/{guerrero.VidaMaxima}");

            Console.WriteLine();

            mago.Curar(guerrero);

            Console.WriteLine();

            Console.WriteLine("========== ENTRENAMIENTO ==========");
            Console.WriteLine();

            guerrero.Entrenar();

            Console.WriteLine();

            Console.WriteLine("========== COMBATE HASTA LA DERROTA ==========");
            Console.WriteLine();

            Console.WriteLine(
                $"{guerrero.Nombre} atacará a {mago.Nombre} " +
                $"hasta derrotarlo.");

            Console.WriteLine();

            while (mago.EstaVivo())
            {
                guerrero.Atacar(mago);

                Console.WriteLine();
            }

            Console.WriteLine(
                $"Estado de {mago.Nombre}: " +
                $"{mago.Vida}/{mago.VidaMaxima}");

            Console.WriteLine();

            Console.WriteLine("========== PERSONAJE DERROTADO ==========");
            Console.WriteLine();

            mago.Atacar(guerrero);

            Console.WriteLine();

            Console.WriteLine("========== REVIVIR ==========");
            Console.WriteLine();

            sanador.Revivir(mago);

            Console.WriteLine();

            Console.WriteLine("========== CURAR AL REVIVIDO ==========");
            Console.WriteLine();

            sanador.Curar(mago);

            Console.WriteLine();

            Console.WriteLine("========== POLIMORFISMO ==========");
            Console.WriteLine();

            foreach (Personaje personaje in personajes)
            {
                Console.WriteLine(
                    $"{personaje.Nombre} realiza su ataque:");

                personaje.Atacar(guerrero);

                Console.WriteLine();
            }

            Console.WriteLine("========== CAPACIDADES ==========");
            Console.WriteLine();

            foreach (Personaje personaje in personajes)
            {
                if (personaje is ICurador curador)
                {
                    Console.WriteLine(
                        $"{personaje.Nombre} puede curar.");
                }

                if (personaje is IRevividor revividor)
                {
                    Console.WriteLine(
                        $"{personaje.Nombre} puede revivir.");
                }
            }

            Console.WriteLine();

            Console.WriteLine("========== ESTADO FINAL ==========");
            Console.WriteLine();

            foreach (Personaje personaje in personajes)
            {
                string estado;

                if (personaje.EstaVivo())
                {
                    estado = "VIVO";
                }
                else
                {
                    estado = "DERROTADO";
                }

                Console.WriteLine(
                    $"{personaje.Nombre} → " +
                    $"Vida: {personaje.Vida}/{personaje.VidaMaxima} → " +
                    estado);
            }
        }
    }
}