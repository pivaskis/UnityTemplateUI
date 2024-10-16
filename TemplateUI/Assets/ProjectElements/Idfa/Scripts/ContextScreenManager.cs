﻿using Unity.Advertisement.IosSupport.Components;
using UnityEngine;
using System.Collections;

namespace Unity.Advertisement.IosSupport.Samples
{
  
    public class ContextScreenManager : MonoBehaviour
    {
  
        public ContextScreenView contextScreen;

        void Start()
        {
#if UNITY_IOS
            var status = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
 
            if (status == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                //contextScreen.sentTrackingAuthorizationRequest += () => Destroy(contextScreen.gameObject);
                contextScreen.RequestAuthorizationTracking();
            }
#else
            Debug.Log("Unity iOS Support: App Tracking Transparency status not checked, because the platform is not iOS.");
#endif
            StartCoroutine(OpenGameScene());

        }

        private IEnumerator OpenGameScene()
        {
#if UNITY_IOS && !UNITY_EDITOR
            var status = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
 
            while (status == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                status = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
                if (status == ATTrackingStatusBinding.AuthorizationTrackingStatus.AUTHORIZED)
                    PlayerPrefs.SetInt("autorizet", 1);
                yield return null;
            }
#endif

            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
            yield return null;
        }
    }
}