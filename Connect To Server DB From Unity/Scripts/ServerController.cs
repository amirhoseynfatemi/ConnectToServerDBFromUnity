
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ServerController : MonoBehaviour
{
    public string Url;
    public GameObject ItemPrefab;
    public Transform Content;

    private void Awake() {
        StartCoroutine("GetUserRequest");
    }
   IEnumerator GetUserRequest()
   {
        #region With using 
        using(UnityWebRequest Request = UnityWebRequest.Get(Url))
        {
            yield return Request.SendWebRequest();

            if (Request.result != UnityWebRequest.Result.Success)
             Debug.Log(Request.error);
            else
            {
                string Data = Request.downloadHandler.text;
                ParsData(Data);
            }
        }
        #endregion

        #region  
        //   UnityWebRequest Request = UnityWebRequest.Get(Url);
        //   yield return Request.SendWebRequest();

        // if (Request.result != UnityWebRequest.Result.Success)
        //     Debug.Log(Request.error);
        // else
        // {
        //     string Data = Request.downloadHandler.text;
        //     ParsData(Data);
        // }
        // Request.Dispose();
        #endregion
   }

   public void ParsData(string Data)
   {
       JSONArray Array = JSON.Parse(Data) as JSONArray;
       JSONObject Object = new JSONObject();

       for (int i = 0; i < Array.Count; i++)
       {
           Object = Array[i].AsObject;
          GameObject Item = Instantiate(ItemPrefab,Content);
          Item.GetComponent<ItemController>().UserNameText.text = Object[1];
       }
   }
}
