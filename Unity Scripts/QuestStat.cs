using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
namespace Data
{
    [System.Serializable]
    public class QuestStat
    {
        public int tehtavaID;
        public string tehtavaNimi;
        public string tehtavaKuvaus;
        public int palkkioMaara;
        public int kokemusPisteet;
        public bool onkoSuoritettu;
        public QuestStat() 
        {

        }
        public QuestStat(int tehtavaID, string tehtavaNimi, string tehtavaKuvaus, int palkkioMaara, int kokemusPisteet, bool onkoSuoritettu) 
        {
            this.tehtavaID = tehtavaID; 
            this.tehtavaNimi = tehtavaNimi; 
            this.tehtavaKuvaus = tehtavaKuvaus; 
            this.palkkioMaara = palkkioMaara; 
            this.kokemusPisteet = kokemusPisteet; 
            this.onkoSuoritettu = onkoSuoritettu; 
        }
        // Haetaan pelihahmon tilatiedot tietokannasta (JSON)
        public IEnumerator LoadStaDataFromDatabase(string uri, TMP_InputField outputArea)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                // Odotetaan vastausta
                yield return request.SendWebRequest();
                // Tutkitaan onko virheit‰
                if (request.error != null)
                {
                    outputArea.text = $"Nettivirhe: {request.error}";
                }
                else
                {
                    outputArea.text = request.downloadHandler.text;
                }
                // Otetaan JSON tietokannasta ja poistetaan [ ja ] merkit
                string newOutputArea = outputArea.text.Remove(0, 1);
                string newOutputArea2 = newOutputArea.Remove(newOutputArea.Length -1, 1);
                Stat stat = JsonUtility.FromJson<Stat>(newOutputArea2);
            }
        }
        // Tallennetaan pelihahmon tilatiedot tietokantaan (JSON)
        public IEnumerator SaveStatDataToDatabase(string uri, TMP_InputField outputArea)
        {
            // Luodaan tallennusta JSON rakenne
            string tehtavaID = $"\"tehtavaID\":{this.tehtavaID},";
            string tehtavaNimi = $"\"tehtavaNimi\":{this.tehtavaNimi},";
            string tehtavaKuvaus = $"\"tehtavaKuvaus\":{this.tehtavaKuvaus},";
            string palkkioMaara = $"\"palkkioMaara\":{this.palkkioMaara},";
            string kokemusPisteet = $"\"kokemusPisteet\":{this.kokemusPisteet},";
            string onkoSuoritettu = $"\"onkoSuoritettu\":{this.onkoSuoritettu}";
            string bodyData = "{" + tehtavaID + tehtavaNimi + tehtavaKuvaus + palkkioMaara + kokemusPisteet + onkoSuoritettu + "}";

            // Pyydet‰‰n palvelinta p‰ivitt‰m‰‰n (PUT) tilatiedot
            using (UnityWebRequest request = UnityWebRequest.Put(uri, bodyData))
            {
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();
                if (request.error != null)
                {
                    outputArea.text = $"Nettivirhe: {request.error}";
                }
                else
                {
                    outputArea.text = request.downloadHandler.text;
                }
            }
        }
    }
}

