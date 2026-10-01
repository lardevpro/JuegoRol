using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRol.Entidades
{
    public abstract class Personaje
    {
        public string? Nombre { get; set; }
        public int Vida { get; set; }
        public int VidaMaxima { get; set; }
        public int Nivel { get; set; }
        public TipoPersonaje Tipo { get; }

        protected Personaje(string? nombre, int vida, int vidaMaxima, 
            int nivel, TipoPersonaje tipo)
        {
            Nombre = nombre;
            Vida = vida;
            VidaMaxima = vidaMaxima;
            Nivel = nivel;
            Tipo = tipo;
        }

        public bool EstaVivo()
        {
            return this.Vida > 0;
        }

        public void RecibirDanio(int danio)
        {
            this.Vida -= danio;

            if(this.Vida < 0)
            {
                this.Vida = 0;
            }

            if (!EstaVivo())
            {
                Console.WriteLine($"{this.Nombre} ha sido derrotado");
            }
        }

        public void RecuperarVida(int cantidad)
        {
            if (!EstaVivo())
            {
                return;
            }

            this.Vida += cantidad;

            if(this.Vida > this.VidaMaxima)
            {
                this.Vida = this.VidaMaxima;
            }
        }

        public void Revivir(int vidaInicial)
        {
            if (EstaVivo())
            {
                return;
            }

            this.Vida = vidaInicial;

            if (this.Vida > this.VidaMaxima){
                this.Vida = this.VidaMaxima;
            }

            if (this.Vida < 0)
            {
                this.Vida = 0;
            }
        }

        public bool Acertar(int precision)
        {
            int tirada = Random.Shared.Next(1,101);
            return tirada <= precision;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Tipo: {this.Tipo}");
            Console.WriteLine($"Vida: {this.Vida}/{this.VidaMaxima}");
            Console.WriteLine($"Nivel: {this.Nivel}");
        }

        public abstract void Atacar(Personaje objetivo);
    }
}
