

using UnityEngine;
//using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int fromIndex = 0;
    public int toIndex = 27;


    [SerializeField]
    //	SiwedwGoogleMobileAds
    //		m_adMob;

    /*	public SiwedwGoogleMobileAds adMob {
            get {
                return m_adMob;
            }
        }*/

    public string loadedLevelNameForAd;
    public float adDelay = 120;
    float curTimePlusDelay;

    bool isTimeUp
    {
        get
        {
            return Time.unscaledTime > curTimePlusDelay;
        }
    }

    public void ResetTime()
    {
        curTimePlusDelay = Time.unscaledTime + adDelay;
    }

    /*void RequestInterstitialAd ()
	{
		adMob.RequestInterstitial (OnIntersLoaded, OnIntersFailed, OnIntersOpening, OnIntersClosed, OnIntersLeaving);
	}

	void OnIntersLoaded (object o, System.EventArgs args)
	{
		Debug.Log (" intersitialnya wes di load");
	}*/

    /*	void OnIntersFailed (object o, AdFailedToLoadEventArgs args)
        {
            Debug.Log (" intersitialnya gak iso di load");
        }
        */
    void OnIntersOpening(object o, System.EventArgs args)
    {
        Debug.Log(" intersitialnya lagi di bukak");
    }

    void OnIntersClosed(object o, System.EventArgs args)
    {
        Debug.Log(" intersitialnya wes di tutup");
    }

    void OnIntersLeaving(object o, System.EventArgs args)
    {
        Debug.Log(" intersitialnya metu soko aplikasi");
    }

    void Start()
    {
        if (Instance != null) { }
        else
            Instance = this;

        //		Sing.gm.adMob.RequestBanner (AdSize.SmartBanner, AdPosition.Bottom);
        //	RequestInterstitialAd ();
        ResetTime();
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log(Application.loadedLevelName + "Telah di load");
        if (Application.loadedLevelName == loadedLevelNameForAd)
        {
            if (isTimeUp)
            {
                //	adMob.ShowInterstitial ();
                //	RequestInterstitialAd ();
                ResetTime();
            }
        }
    }
}
