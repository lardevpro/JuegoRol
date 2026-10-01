using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRol.Entidades
{
    public class Guerrero : Personaje
    {
        public int Fuerza { get; set; }
        public int Precision { get; set; }

        public Guerrero(string? nombre, int vida, int vidaMaxima, 
            int nivel,
            int fuerza, int precision) 
            : base(nombre, vida, vidaMaxima, nivel, TipoPersonaje.Guerrero)
        {
            this.Fuerza = fuerza;
            this.Precision = precision;
        }

        public override void Atacar(Personaje objetivo)
        {
            if (!EstaVivo())
            {
                Console.WriteLine(
                    $"{this.Nombre} no puede atacar porque está derrotado.");
                return;
            }

            if (!objetivo.EstaVivo())
            {
                Console.WriteLine($"{objetivo.Nombre} ya está derrotado.");
                return;
            }

            if (!Acertar(this.Precision))
            {
                Console.WriteLine(
                    $"{this.Nombre} ataca a {objetivo.Nombre}, pero falla.");
                return;
            }

            int danio = this.Fuerza + (this.Nivel * 2);

            objetivo.RecibirDanio(danio);

            Console.WriteLine(
                $"{this.Nombre} ataca a {objetivo.Nombre} " +
                $"y causa {danio} puntos de daño.");

            Console.WriteLine(
                $"Vida de {objetivo.Nombre}: " +
                $"{objetivo.Vida}/{objetivo.VidaMaxima}");

        }

        public void Entrenar()
        {
            this.Fuerza += 5;
            this.Nivel++;

            Console.WriteLine($"{this.Nombre} entrena.");

            Console.WriteLine($"Nivel: {this.Nivel}");

            Console.WriteLine($"Fuerza: {this.Fuerza}");
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();

            Console.WriteLine($"Fuerza: {this.Fuerza}");
            Console.WriteLine($"Precisión: {this.Precision}");
        }
    }
}
