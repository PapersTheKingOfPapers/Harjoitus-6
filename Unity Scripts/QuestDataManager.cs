
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;   
// Tietoliikennettä varten
namespace Data
{
    public class QuestDataManager: MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField outputArea;        
        // Yhteys pelihahmon tilatietoihin
        public Quest quest;
        public void GetData()
        {
            outputArea.text = null;
            string uri = "https://localhost:7110/superadventure";
            QuestStat questStat = new QuestStat();
            StartCoroutine(questStat.LoadStaDataFromDatabase(uri, outputArea));
        }
        public void PutData()
        {
            outputArea.text = "Loading ...";
            string uri = "https://localhost:7110/superadventure/1";
            // Luodaan Stat-olio
            QuestStat questStat = new QuestStat(quest.TehtavaID, quest.TehtavaNimi, quest.TehtavaKuvaus, quest.PalkkioMaara, quest.KokemusPisteet, quest.OnkoSuoritettu);            
            // Suoritetaan päivitys
            StartCoroutine(questStat.SaveStatDataToDatabase(uri, outputArea));
        }
    }
}