using Eventyr.EndlessRunner.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eventyr.EndlessRunner.Scripts.Data
{
    [Serializable]
    public class UserData : IUserData
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int MaxScore { get; set; }
    }
}
