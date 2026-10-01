using JuegoRol.Entidades;

namespace JuegoRol.Entidades
{
    public class Arquero : Personaje
    {
        public int Flechas { get; protected set; }
        public int Precision { get; set; }
        public int Danio { get; set; }

        public Arquero(string? nombre, int vida, int vidaMaxima, 
            int nivel, int flechas, int precision, int danio) 
            : base(nombre, vida, vidaMaxima, nivel, TipoPersonaje.Arquero)
        {
            this.Flechas = flechas;
            this.Precision = precision;
            this.Danio = danio;
        }
        
        public override void Atacar(Personaje objetivo)
        {
            if (!EstaVivo())
            {
                Console.WriteLine(
                    $"{Nombre} no puede atacar porque está derrotado.");

                return;
            }

            if (!objetivo.EstaVivo())
            {
                Console.WriteLine(
                    $"{objetivo.Nombre} ya está derrotado.");

                return;
            }

            if (Flechas <= 0)
            {
                Console.WriteLine(
                    $"{Nombre} no tiene flechas.");

                return;
            }

            Flechas--;

            if (!Acertar(Precision))
            {
                Console.WriteLine(
                    $"{Nombre} dispara a {objetivo.Nombre}, pero falla.");

                Console.WriteLine(
                    $"Flechas restantes: {Flechas}");

                return;
            }

            int danioTotal = Danio + Nivel;

            objetivo.RecibirDanio(danioTotal);

            Console.WriteLine(
                $"{Nombre} dispara a {objetivo.Nombre} " +
                $"y causa {danioTotal} puntos de daño.");

            Console.WriteLine(
                $"Flechas restantes: {Flechas}");

            Console.WriteLine(
                $"Vida de {objetivo.Nombre}: " +
                $"{objetivo.Vida}/{objetivo.VidaMaxima}");
        }

        public void Recargar()
        {
            Flechas += 5;

            Console.WriteLine(
                $"{Nombre} recarga sus flechas.");

            Console.WriteLine(
                $"Flechas actuales: {Flechas}");
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();

            Console.WriteLine($"Flechas: {Flechas}");
            Console.WriteLine($"Daño: {Danio}");
            Console.WriteLine($"Precisión: {Precision}%");
        }
    }
}
