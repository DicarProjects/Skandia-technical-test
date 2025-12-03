namespace interview.Basic_Concepts
{
    public class Basic_Concepts
    {
        /// <summary>
        /// 1. ¿Qué es la Programación Orientada a Objetos (POO)?
        /// </summary>
        public const string Q_A = "Es una forma de construir/implementar código a traves de objetos," +
                                  "definiendo por medio de clases sus propiedades y comportamientos (Métodos)";

        /// <summary>
        /// 2. ¿Cuál es la diferencia entre una Clase y una Interfaz?
        /// </summary>
        public const string Q_B = "La clase es un \"molde\" para crear objetos; Define la estructura; propiedades y métodos con implementación." +
                                    " La interfaz define un contrato; establece métodos solo con su firma y las clases que la implementen deben añadir la implementación (código)";

        /// <summary>
        /// 3. ¿Cuál es la diferencia entre un método estático y uno no estático?
        /// </summary>
        public const string Q_C = "Un método estático no requiere una instancia de la clase para ser llamado (pertenece a la clase); " +
                                  "un metodo no estático sí depende de una instancia (pertenece a la instancia/Objeto)";

        /// <summary>
        /// 4. ¿Qué es un ciclo de vida de Software?
        /// </summary>
        public const string Q_D = "Es el conjunto de fases por las que pasa un software desde la idea hasta el retiro" +
                                    "pasando por planificación de requerimientos, diseño, implementación, pruebas, despliegue y mantenimiento";

        /// <summary>
        /// 5. ¿Cuál es la diferencia entre Throw y Throw ex; dentro de un catch?
        /// </summary>
        public const string Q_E = "Ambos son formar de relanzar una excepción, Throw mantiene la traza de la pila original (se registra toda la ruta del error)," +
            "Throw ex interrumpe la traza original y crea una traza nueva a partir del punto en que ocurrio el error (sin pasos anteriores)";
    }
}