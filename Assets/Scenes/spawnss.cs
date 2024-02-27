namespace Photon.Pun{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using ExitGames.Client.Photon;
    using Photon.Realtime;
    using Photon.Pun;

    public class spawnss : MonoBehaviourPunCallbacks
    {
        public GameObject prefeb;
        private GameObject o;
        public byte Version = 1;
        public byte MaxPlayers = 4;
        public int playerTTL = -1;

        // Start is called before the first frame update
        void Start()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = "USER_" + Random.Range(0, 100).ToString();
            ConnectNow();
            
        }

        public override void OnJoinedRoom()
        {
            o = PhotonNetwork.Instantiate(prefeb.name,new Vector3(UnityEngine.Random.Range(-4f, 4f),0,0), Quaternion.identity);
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("Lobby connected");
            PhotonNetwork.JoinRandomRoom();
        }
        // Update is called once per frame
        void Update()
        {
        
        }

        void ConnectNow()
        {
            Debug.Log("ConnectAndJoinRandom.ConnectNow() will now call: PhotonNetwork.ConnectUsingSettings().");

            
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = this.Version + "." + SceneManagerHelper.ActiveSceneBuildIndex;
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("OnJoinRandomFailed() was called by PUN. No random room available in region [" + PhotonNetwork.CloudRegion + "], so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");

            RoomOptions roomOptions = new RoomOptions() { MaxPlayers = this.MaxPlayers };
            if (playerTTL >= 0)
                roomOptions.PlayerTtl = playerTTL;

            PhotonNetwork.CreateRoom(null, roomOptions, null);
        }

        public override void OnConnectedToMaster()
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 5;
            PhotonNetwork.JoinOrCreateRoom("Room1", options, null); 
        }
    }
}
