using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VirtualButtonsHandler : MonoBehaviour
{
    public List<GameObject> menus;
    public List<VideoPlayer> videos;
    public VirtualButtonBehaviour vbBack, vbNext, vbVideo;
    public static int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {   
        vbBack.RegisterOnButtonPressed(OnButtonPressedVbBack);
        vbNext.RegisterOnButtonPressed(OnButtonPressedVbNext);
        vbVideo.RegisterOnButtonPressed(VideoToggle);

        //Always set menu to active
        menus[0].SetActive(true);

        //Always hide another menu
        for(var i=1; i<menus.Count; ++i)
        {
            if(menus[i].activeInHierarchy)
            {
                menus[i].SetActive(false);
            }
        }
    }

    void OnButtonPressedVbNext(VirtualButtonBehaviour vb){   
        int max = menus.Count;     
        menus[counter].SetActive(false);
        counter += 1;
        if(counter > max-1)
        {
            counter = 0;
        }
        menus[counter].SetActive(true);
    }

    void OnButtonPressedVbBack(VirtualButtonBehaviour vb){
        int max = menus.Count;
        menus[counter].SetActive(false);
        counter -= 1;
        if(counter < 0)
        {
            counter = max-1;
        }
        menus[counter].SetActive(true);
    }

    void VideoToggle(VirtualButtonBehaviour vb){
        // Debug.Log("BUTTON PRESSED");
        if(counter == 3)
        {
            VideoToggler(videos[0]);
        } 
        else if (counter == 4)
        {
            VideoToggler(videos[1]);
        }
        else if (counter == 5)
        {
            VideoToggler(videos[2]);
        }
        else if (counter == 6)
        {
            VideoToggler(videos[3]);
        }
    }

    void VideoToggler(VideoPlayer video) {
        if(video.isPlaying) {
            // Debug.Log("Pause Video");
            video.Pause();
        }
        else {
            // Debug.Log("Play Video");
            video.Play();
        }
    }
}
