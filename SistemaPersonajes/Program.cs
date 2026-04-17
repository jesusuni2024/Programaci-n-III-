using System;

// CLASE BASE
public class Personaje
{
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }
    public string Tipo { get; set; }

    public Personaje(string nombre, int vida, int ataque, string tipo)
    {
        Nombre = nombre;
        Vida = vida;
        Ataque = ataque;
        Tipo = tipo;
    }

    public virtual void Atacar()
    {
        Console.WriteLine(Nombre + " realiza un ataque básico de " + Ataque);
    }
}

// CLASE GUERRERO (HERENCIA)
public class Guerrero : Personaje
{
    public Guerrero(string nombre, int vida, int ataque, string tipo)
        : base(nombre, vida, ataque, tipo)
    {
    }

    public override void Atacar()
    {
        Console.WriteLine(Nombre + " ataca con su espada causando " + Ataque + " de daño.");
    }
}

// CLASE MAGO (HERENCIA)
public class Mago : Personaje
{
    public Mago(string nombre, int vida, int ataque, string tipo)
        : base(nombre, vida, ataque, tipo)
    {
    }

    public override void Atacar()
    {
        Console.WriteLine(Nombre + " lanza un hechizo causando " + Ataque + " de daño.");
    }
}

// PROGRAMA PRINCIPAL
class Program
{
    static void Main(string[] args)
    {
        Guerrero guerrero1 = new Guerrero("Thor", 150, 30, "Aliado");
        Mago mago1 = new Mago("Merlin", 100, 40, "Aliado");

        Console.WriteLine("=== SISTEMA DE PERSONAJES ===\n");

        guerrero1.Atacar();
        mago1.Atacar();

        Console.ReadLine();
    }
}