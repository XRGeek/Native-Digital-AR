using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPanel : MonoBehaviour
{
    private string shareMsg;

    public void drawerShare()
    {
#if UNITY_ANDROID
        
     new NativeShare().AddFile(shareMsg)
			.SetSubject("Native-Digital-AR").SetText(shareMsg).SetUrl("https://play.google.com/store/apps/details?id=" + Application.identifier)
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();


#elif UNITY_IPHONE
        new NativeShare().AddFile(shareMsg)
                   .SetSubject("Native-Digital-AR").SetText(shareMsg).SetUrl("https://apps.apple.com/us/app/native-digital-ar/id6444181283")
                   .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
                   .Share();
#endif
    }



    public void drawerPrivacyPolicy()
    {
  Application.OpenURL("https://www.ndpa.ch/privacy-policy");
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

#endif
        UnityEngine.iOS.Device.RequestStoreReview();
    }
}
