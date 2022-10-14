using System.ComponentModel.DataAnnotations;

namespace Harjoitus_6
{
    /// <summary>
    /// Malliluokka (Entity), joka edustaa tietoja, joita sovelluksella hallinnoidaan.
    /// </summary>
    public class Quest
    {
        [Key]
        public int TehtavaID { get; set; }
        public string TehtavaNimi { get; set; }
        public string TehtavaKuvaus { get; set; }
        public int PalkkioMaara { get; set; }
        public int KokemusPisteet { get; set; }
        public bool OnkoSuoritettu { get; set; }
    }
}
