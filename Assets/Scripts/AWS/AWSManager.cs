using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.IO;
using System;
using Amazon.S3.Util;
using System.Collections.Generic;
using Amazon.CognitoIdentity;
using Amazon;

public class AWSManager : MonoBehaviour {

    private IAmazonS3 _s3Client;
    private AWSCredentials _credentials;

    private AWSCredentials Credentials
    {
        get
        {
            if (_credentials == null)
                _credentials = new CognitoAWSCredentials("us-west-2:92761aff-f26c-4830-9187-ad6f89af6073", RegionEndpoint.USWest2);
            return _credentials;
        }
    }

    private IAmazonS3 Client
    {
        get
        {
            if (_s3Client == null)
            {
                _s3Client = new AmazonS3Client(Credentials, _S3Region);
            }
            //test comment
            return _s3Client;
        }
    }

    private static AWSManager _instance;
    public static AWSManager Instance
    {
        get
        {
            if(_instance == null){
                Debug.Log("AWS Manager is Null");
            }
            return _instance;
        }
    }

    public string S3Region = RegionEndpoint.USWest2.SystemName;
    private RegionEndpoint _S3Region
    {
        get { return RegionEndpoint.GetBySystemName(S3Region); }
    }

    public void GetObjects()
    {
        //ResultText.text = "Fetching all the Objects from " + S3BucketName;

        var request = new ListObjectsRequest()
        {
            BucketName = "jwassetbundles"
        };

        Client.ListObjectsAsync(request, (responseObject) =>
        {
            //ResultText.text += "\n";
            if (responseObject.Exception == null)
            {
                //ResultText.text += "Got Response \nPrinting now \n";
                responseObject.Response.S3Objects.ForEach((o) =>
                {
                    //ResultText.text += string.Format("{0}\n", o.Key);
                    //print(o.Key);
                });
                DownloadBundle();
            }
            else
            {
                print("Got Exception \n");
            }
        });
    }

    public void DownloadBundle(){
        /*
         
          //this code works
        Client.GetObjectAsync("jwassetbundles", "graphicscreens", (responseObj) =>
        {
            string data = null;
            var response = responseObj.Response;
            if (response.ResponseStream != null)
            {
                print("response");
                using (StreamReader reader = new StreamReader(response.ResponseStream))
                {
                    data = reader.ReadToEnd();
                }
                //ResultText.text += "\n";
                //ResultText.text += data;

                //Possible code for accessing image within asset bundle
                //Sprite newSprite =  bundle.LoadAsset<Sprite>("assets/resources/images/snap.png");
            }
        });
        */
        StartCoroutine(BundleRoutine());

    }

    IEnumerator BundleRoutine(){
        string uri = "https://s3-us-west-2.amazonaws.com/jwassetbundles/graphicscreens";
        var request = new WWW(uri);
        yield return request;
        Debug.Log("AssetBundle Bundle Name: " + request.assetBundle.name);

        AssetBundle bundle = request.assetBundle;



        //Sprite newSprite = bundle.LoadAsset<Sprite>("assets/resources/images/JumpWire-Logo.png");


    }

    void Awake()
    {
        _instance = this;

        UnityInitializer.AttachToGameObject(this.gameObject);

        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;

        var request = new ListObjectsRequest()
        {
            BucketName = "jwassetbundles"
        };
        GetObjects();
	}
}