using JuegoRol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRol.Entidades
{
    public class Mago : Personaje, ICurador
    {
        public int Mana { get; protected set; }
        public int ManaMaximo { get; }
        public int PoderMagico { get; set; }
        public int Precision { get; set; }

        public Mago(string? nombre, int vida, int vidaMaxima, 
            int nivel,
            int mana, int poderMagico, int precision) 
            : base(nombre, vida, vidaMaxima, nivel, TipoPersonaje.Mago)
        {
            this.Mana = mana;
            this.ManaMaximo = mana;
            this.PoderMagico = poderMagico;
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

            if(this.Mana < 10)
            {
                Console.WriteLine(
                    $"{this.Nombre} no tiene suficiente maná");
                return;
            }

            this.Mana -= 10;

            if (!Acertar(this.Precision))
            {
                Console.WriteLine(
                    $"{this.Nombre} lanza un hechizo contra " +
                    $"{objetivo.Nombre}, pero falla");

                Console.WriteLine($"Maná restante: {this.Mana}");
                return;
            }

            int danio = this.PoderMagico + this.Nivel;

            objetivo.RecibirDanio(danio);

            Console.WriteLine(
                $"{this.Nombre} lanza un hechizo contra " +
                $"{objetivo.Nombre} " +
                $"y causa {danio} puntos de daño.");

            Console.WriteLine(
                $"Maná restante: {this.Mana}");

            Console.WriteLine(
                $"Vida de {objetivo.Nombre}: " +
                $"{objetivo.Vida}/{objetivo.VidaMaxima}");
        }

        public void Curar(Personaje objetivo)
        {
            if (!EstaVivo())
            {
                Console.WriteLine(
                    $"{this.Nombre} no puede curar porque está derrotado.");
                return;
            }

            if (!objetivo.EstaVivo())
            {
                Console.WriteLine(
                    $"{objetivo.Nombre} está derrotado. " +
                    $"{this.Nombre} no puede revivirlo.");
                return;
            }

            if (this.Mana < 15) {
                Console.WriteLine(
                    $"{this.Nombre} no tiene suficiente maná para curar.");
            }

            this.Mana -= 15;

            int cantidad = this.PoderMagico;

            int vidaAntes = objetivo.Vida;

            objetivo.RecuperarVida(cantidad);

            int vidaRecuperada = objetivo.Vida - vidaAntes;

            Console.WriteLine(
                $"{this.Nombre} cura a {objetivo.Nombre} " +
                $"y recupera {vidaRecuperada} puntos de vida.");

            Console.WriteLine(
                $"Vida de {objetivo.Nombre} " +
                $"{objetivo.Vida}/{objetivo.VidaMaxima}");

            Console.WriteLine(
                $"Maná restante: {this.Mana}");
        }

        public void RecuperarMana()
        {
            this.Mana += 20;

            if (this.Mana > this.ManaMaximo)
            {
                this.Mana = this.ManaMaximo;
            }

            Console.WriteLine($"{this.Nombre} recupera maná");

            Console.WriteLine($"Maná actual: ´{this.Mana}");
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();

            Console.WriteLine($"Maná: {this.Mana}/{this.ManaMaximo}");
            Console.WriteLine($"Poder mágico: {this.PoderMagico}");
            Console.WriteLine($"Precisión: {this.Precision}");
        }
    }
}
