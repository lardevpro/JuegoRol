# ⚔️ JuegoRol

¡Bienvenido a **JuegoRol**! Este repositorio es un proyecto de desarrollo de software enfocado en la práctica de programación orientada a objetos (POO), patrones de diseño y lógica de videojuegos utilizando **C#**.

---

## 📋 Índice
- [Características Principales](#-características-principales)
- [Tecnologías Utilizadas](#%EF%B8%8F-tecnologías-utilizadas)
- [Estructura del Proyecto](#%EF%B8%8F-estructura-del-proyecto)
- [Requisitos Previos](#-requisitos-previos)
- [Instalación y Ejecución](#%EF%B8%8F-instalación-y-ejecución)
- [Contribución](#-contribución)

---

## ✨ Características Principales
* **Arquitectura Limpia:** Separación de conceptos mediante el uso explícito de entidades e interfaces.
* **Modelo de Datos Sólido:** Estructura modular para gestionar los diferentes elementos, personajes o sistemas que componen el juego de rol.
* **Práctica de C# Avanzado:** Implementación de herencia, polimorfismo, abstracción y encapsulamiento.

---

## 🛠️ Tecnologías Utilizadas
* **Lenguaje:** [C#](https://microsoft.com)
* **Plataforma:** [.NET 10.0 SDK](https://microsoft.com)

---

## 🏗️ Estructura del Proyecto

El código está organizado de la siguiente manera dentro del repositorio:

```text
├── Entidades/        # Clases principales del juego (Personajes, Enemigos, Items, etc.)
├── Interfaces/       # Contratos y abstracciones para desacoplar el código
├── JuegoRol.csproj   # Archivo de configuración del proyecto de .NET
└── Program.cs        # Punto de entrada principal y flujo lógico del programa
```

---

## 📌 Requisitos Previos
Para compilar y ejecutar este proyecto necesitas tener instalado:
* **.NET 10.0 SDK** (o la versión correspondiente en tu entorno de desarrollo)
* Un IDE o editor de código compatible (como **Visual Studio 2022**, **Visual Studio Code** o **JetBrains Rider**)

---

## ⚙️ Instalación y Ejecución

Sigue estos pasos para probar el proyecto localmente de manera rápida:

1. **Clona este repositorio:**
   ```bash
   git clone https://github.com
   cd JuegoRol
   ```

2. **Restaura las dependencias del proyecto:**
   ```bash
   dotnet restore
   ```

3. **Compila y ejecuta la aplicación:**
   ```bash
   dotnet run
   ```

---

## 🤝 Contribución
Las sugerencias y mejoras son siempre bienvenidas:
1. Haz un **Fork** de este repositorio.
2. Crea una rama para tu mejora (`git checkout -b feature/NuevaMejora`).
3. Realiza tus cambios y haz un commit descriptivo (`git commit -m 'Añade nueva funcionalidad al combate'`).
4. Sube la rama (`git push origin feature/NuevaMejora`).
5. Abre un **Pull Request**.
