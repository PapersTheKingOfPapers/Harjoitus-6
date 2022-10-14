using Data;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Data
{
    public class Quest : MonoBehaviour
    {
        // Pelihahmon tilatiedot (Stats)
        [SerializeField] private int tehtavaID;
        [SerializeField] private string tehtavaNimi;
        [SerializeField] private string tehtavaKuvaus;
        [SerializeField] private int palkkioMaara;
        [SerializeField] private int kokemusPisteet;
        [SerializeField] private bool onkoSuoritettu;
        public int TehtavaID { get => tehtavaID; set => tehtavaID = value; }
        public string TehtavaNimi { get => tehtavaNimi; set => tehtavaNimi = value; }
        public string TehtavaKuvaus { get => tehtavaKuvaus; set => tehtavaKuvaus = value; }
        public int PalkkioMaara { get => palkkioMaara; set => palkkioMaara = value; }
        public int KokemusPisteet { get => kokemusPisteet; set => kokemusPisteet = value; }
        public bool OnkoSuoritettu { get => onkoSuoritettu; set => onkoSuoritettu = value; }
    }
}