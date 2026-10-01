using JuegoRol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRol.Entidades
{
    public class Sanador : Personaje, ICurador, IRevividor
    {

        public int PoderCuracion { get; set; }

        public Sanador(string? nombre, int vida, int vidaMaxima, 
            int nivel, int poderCuracion) 
            : base(nombre, vida, vidaMaxima, nivel, TipoPersonaje.Sanador)
        {
            this.PoderCuracion = poderCuracion;
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

            int danio = Nivel;

            objetivo.RecibirDanio(danio);

            Console.WriteLine(
                $"{Nombre} realiza un ataque contra " +
                $"{objetivo.Nombre} y causa {danio} puntos de daño.");

            Console.WriteLine(
                $"Vida de {objetivo.Nombre}: " +
                $"{objetivo.Vida}/{objetivo.VidaMaxima}");
        }

        public void Curar(Personaje objetivo)
        {
            if (!EstaVivo())
            {
                Console.WriteLine(
                    $"{Nombre} no puede curar porque está derrotado.");

                return;
            }

            if (!objetivo.EstaVivo())
            {
                Console.WriteLine(
                    $"{objetivo.Nombre} está derrotado. " +
                    $"Debes utilizar Revivir().");

                return;
            }

            int cantidad = PoderCuracion + Nivel;

            int vidaAntes = objetivo.Vida;

            objetivo.RecuperarVida(cantidad);

            int vidaRecuperada = objetivo.Vida - vidaAntes;

            Console.WriteLine(
                $"{Nombre} cura a {objetivo.Nombre} " +
                $"y recupera {vidaRecuperada} puntos de vida.");

            Console.WriteLine(
                $"Vida de {objetivo.Nombre}: " +
                $"{objetivo.Vida}/{objetivo.VidaMaxima}");
        }

        public void Revivir(Personaje objetivo)
        {
            if (!EstaVivo())
            {
                Console.WriteLine(
                    $"{Nombre} no puede revivir a nadie " +
                    $"porque está derrotado.");

                return;
            }

            if (objetivo.EstaVivo())
            {
                Console.WriteLine(
                    $"{objetivo.Nombre} sigue vivo. " +
                    $"No necesita ser revivido.");

                return;
            }

            int vidaInicial = objetivo.VidaMaxima / 2;

            objetivo.Revivir(vidaInicial);

            Console.WriteLine(
                $"{Nombre} revive a {objetivo.Nombre}.");

            Console.WriteLine(
                $"{objetivo.Nombre} vuelve con " +
                $"{objetivo.Vida} puntos de vida.");
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();

            Console.WriteLine(
                $"Poder de curación: {PoderCuracion}");
        }
    }
}
