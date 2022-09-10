using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface IUserDataControllerService
    {
        public IUserData UserData { get; }
        public void SetUserData(string name, string email, int maxScore);
        public void WriteUserDataToJsonLocal();
        public bool LoadUserData();
    }
}
