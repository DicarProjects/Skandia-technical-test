🏦 Skandia Technical Test – Console Application

C# / .NET – Algorithms, OOP Concepts, and SQL Data Model

Este repositorio contiene la solución completa a la prueba técnica.
La solución está organizada en tres módulos principales, cada uno en una carpeta independiente.
La aplicación principal es una aplicación de consola, desde la cual se ejecutan los algoritmos y se centralizan las demostraciones de la prueba.

📁 Estructura del Repositorio
/
│── Basic Concepts/
│── Algorithms/
│── Data Models/
│── Program.cs
│── README.md

1️⃣ Basic Concepts

Esta carpeta contiene las preguntas y respuestas relacionadas con Programación Orientada a Objetos (POO).

### 1. ¿Qué es la Programación Orientada a Objetos (POO)?
**Respuesta:**  
Es una forma de construir/implementar código a traves de objetos, definiendo por medio de clases sus propiedades y comportamientos (Métodos).

---

### 2. ¿Cuál es la diferencia entre una Clase y una Interfaz?
**Respuesta:**  
La clase es un "molde" para crear objetos; Define la estructura; propiedades y métodos con implementación.  
La interfaz define un contrato; establece métodos solo con su firma y las clases que la implementen deben añadir la implementación (código).

---

### 3. ¿Cuál es la diferencia entre un método estático y uno no estático?
**Respuesta:**  
Un método estático no requiere una instancia de la clase para ser llamado (pertenece a la clase); un metodo no estático sí depende de una instancia (pertenece a la instancia/Objeto).

---

### 4. ¿Qué es un ciclo de vida de Software?
**Respuesta:**  
Es el conjunto de fases por las que pasa un software desde la idea hasta el retiro pasando por planificación de requerimientos, diseño, implementación, pruebas, despliegue y mantenimiento.

---

### 5. ¿Cuál es la diferencia entre Throw y Throw ex dentro de un catch?
**Respuesta:**  
Ambos son formar de relanzar una excepción, Throw mantiene la traza de la pila original (se registra toda la ruta del error), Throw ex interrumpe la traza original y crea una traza nueva a partir del punto en que ocurrio el error (sin pasos anteriores).


Nota:
Las respuestas también se encuentran documentadas aquí

2️⃣ Algorithms

Esta carpeta contiene la implementación de los algoritmos solicitados.
Cada algoritmo está implementado como un método estático y es invocado desde la clase Program.cs.


3️⃣ Data Models

Esta carpeta contiene toda la parte de base de datos del proyecto.

Incluye:

✔ Diagrama ER

Diagrama entidad–relación del modelo relacional.

<img width="2718" height="2142" alt="SkandiaModelFinal drawio" src="https://github.com/user-attachments/assets/95644726-3f61-4171-84ad-703b3da4c363" />


(La imagen también aparecerá dentro de esta carpeta para evitar problemas de visualización.)


✔ Consultas solicitadas

  Nombre del Archivo: Validate ACME Model.sql



Cuando subas la imagen, usa la siguiente referencia en Markdown:

![ERD](DataModels/erd.png)
