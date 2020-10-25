namespace IrisFlowerCharts.Files.Exceptions
{
    /// <summary>
    /// Исключение, бросаемое при попытке открытия несуществующего файла.
    /// </summary>
    public class FileNotFoundException : System.Exception
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public FileNotFoundException() : base() { }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        public FileNotFoundException(System.String message) : base(message) { }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Сообщение исключения.</param>
        /// <param name="inner">Исключение, которое вызвало текущее исключение.</param>
        public FileNotFoundException(System.String message, System.Exception inner) : base(message, inner) { }
    }
}
