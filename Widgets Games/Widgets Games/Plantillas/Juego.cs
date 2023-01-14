using System.Text.Json.Serialization;

namespace Plantillas
{
    public class Juego
    {
        [JsonPropertyName("type")]
        public string tipo { get; set; }

        [JsonPropertyName("$schema")]
        public string schema { get; set; }

        [JsonPropertyName("version")]
        public string version { get; set; }

        [JsonPropertyName("enlace")]
        public string enlace { get; set; }

        [JsonPropertyName("backgroundImage")]
        public JuegoFondo fondo { get; set; }

        [JsonPropertyName("selectAction")]
        public JuegoAccion accion { get; set; }
    }

    public class JuegoFondo
    {
        [JsonPropertyName("url")]
        public string url { get; set; }
        [JsonPropertyName("horizontalAlignment")]
        public string horizontal { get; set; }
        [JsonPropertyName("verticalAlignment")]
        public string vertical { get; set; }
    }

    public class JuegoAccion
    {
        [JsonPropertyName("type")]
        public string tipo { get; set; }

        [JsonPropertyName("verb")]
        public string verb { get; set; }
    }
}
