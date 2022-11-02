using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPanel : MonoBehaviour
{
    private string shareMsg;

    public void drawerShare()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }



    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();
        new NativeShare().AddFile(shareMsg)
            .SetSubject("Native-Digital-AR").SetText(shareMsg).SetUrl("https://play.google.com/store/apps/details?id=" + Application.identifier)
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }
    public void drawerPrivacyPolicy()
    {
  Application.OpenURL("https://euphoriaxr.com/privacy-policy-2/");
    }
    public void drawerTermsAndCondition()
    {
      Application.OpenURL("https://euphoriaxr.com/about/");
    }
    public void drawerContactUs()
    {
     Application.OpenURL("https://www.ndpa.ch/contacts");
    }
    public void drawerRateUs()
    {
#if UNITY_ANDROID
        //Application.OpenURL("market://details?id=com.DefaultCompany.MeshFlix");
        Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);


#elif UNITY_IPHONE
 Application.OpenURL("itms-apps://itunes.apple.com/app/com.DefaultCompany.MeshFlix");
#endif
    }
}
