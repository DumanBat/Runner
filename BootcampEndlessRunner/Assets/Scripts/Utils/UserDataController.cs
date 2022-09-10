using Eventyr.EndlessRunner.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;
using Newtonsoft.Json;
using Eventyr.EndlessRunner.Scripts.Data;

namespace Eventyr.EndlessRunner.Scripts.Utils
{
    public class UserDataController : IUserDataControllerService
    {
        private const string _userDataJsonName = "userData.json";
        private string _userDataPath;
        [Inject]
        private IUserData _userData;

        public IUserData UserData { get => _userData; }

        public UserDataController()
        {
            _userDataPath = Application.persistentDataPath + "/" + _userDataJsonName;
        }

        public void SetUserData(string name, string email, int maxScore)
        {
            UserData.UserName = string.IsNullOrEmpty(name) ? UserData.UserName : name;
            UserData.UserEmail = string.IsNullOrEmpty(email) ? UserData.UserEmail : email;
            UserData.MaxScore = maxScore > UserData.MaxScore ? maxScore : UserData.MaxScore;
        }

        public bool LoadUserData()
        {
            if (!File.Exists(_userDataPath))
                return false;

            var jsonString = File.ReadAllText(_userDataPath);
            var userDataJson = JsonConvert.DeserializeObject<UserData>(jsonString);

            SetUserData(userDataJson.UserName, userDataJson.UserEmail, userDataJson.MaxScore);
            
            return true;
        }

        public void WriteUserDataToJsonLocal()
        {
            var userDataString = JsonConvert.SerializeObject(UserData);

            File.WriteAllText(_userDataPath, userDataString);
        }
    }
}
